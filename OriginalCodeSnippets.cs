using System;

public class Class1
{
	public Class1()
	{
        // The original talkBookCompleteDynamic
        // Working perfectly only working towards end chapters was not implemented.
        if (args[0] != null && args[0].Contains("talkBookCompleteDynamic"))
        {
            GetPromptVars.LoadDataGenericPromptVars();
            GetPromptVars.LoadDataDocHtmlPromptVars();
            GetPromptVars.LoadPlotDataDocHtmlPlotVars();

            string appPath = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = "FileTalkBook.txt"; // Replace with your file path
            string filePlot = "FileBookStart.txt"; // Replace with your file path

            // Create the Word document
            string filename = System.DateTime.Now.ToString("yyyyMMddHHmmssfff");
            string chapterTitlesPath = "talkfilebook_" + filename + ".docx";
            string chapterTitlesPathHtml = "talkfilebook_" + filename + ".html";
            string chapterTitlesPathPdf = "talkfilebook_" + filename + ".pdf";
            //string chapterTitlesPath = "talkfile_conversation20250302001811548.docx";
            string outputFilePath = appPath + chapterTitlesPath;
            string outputFilePathHtml = appPath + chapterTitlesPathHtml;
            string outputFilePathPdf = appPath + chapterTitlesPathPdf;
            string cc = GlobalMethods.CreateWordDocument(chapterTitlesPath);

            string sClean, getQuote, sQuote, imagePath, Simage;
            string iimage = "";
            string makingImage = "";
            bool success;
            string _examples = args[1];

            #region Create image For the starter of the book
            // Place this string also in the HTML part
            if (_examples.Contains("dochtml"))
            {
                string FirstImageOfBook = GetPromptVars.MainHtmlImageTop;
                iimage = GlobalMethods.GetSubStringForImages("##" + FirstImageOfBook, "##");
            }
            if (_examples.Contains("doclonghtml"))
            {
                iimage = GlobalMethods.GetSubStringForImages("##Create a mathematical image Artificial Intelligence", "##");
            }
            if (_examples.Contains("doclearn"))
            {
                iimage = GlobalMethods.GetSubStringForImages("##Create a mathematical image Artificial Intelligence", "##");
            }

            sClean = iimage.Replace(":", "-").Replace(",", "").Replace("?", "").Replace("!", "")
                    .Replace("\"", "").Replace(";", "");
            imagePath = "";

            // Do image
            //
            if (_examples.Contains("dochtml"))
            {
                string FirstImageOfBook = GetPromptVars.MainHtmlImageTop;
                makingImage = FirstImageOfBook + " ";
            }
            if (_examples.Contains("doclonghtml"))
            {
                makingImage = "Create an artificial intelligence image on the topic - ";
            }
            if (_examples.Contains("doclearn"))
            {
                makingImage = "Create a mathematical image inspired by artificial intelligence on ";
            }

            Simage = await GetDalleGood(makingImage
                       + iimage);
            if (Simage.Contains("Bad Request")) // Probably from words and length
            {
                Simage = await GetDalleGood(makingImage
                + sClean);
            }
            await GlobalMethods.GetImageFromURL(Simage, outputFilePath, sClean);

            success = false;
            while (!success) // Sometimes this went wrong (time issue), so, while wrong repeat and it worked.
            {
                try
                {
                    await GlobalMethods.ReduceImageSize(Simage, appPath + sClean + ".jpg");
                    success = true; // If the method completes successfully, set success to true to exit the loop
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred JPG IMAGE REDUCTION!!!: {ex.Message}. Retrying...");
                    // Optionally, you can add a delay here before retrying
                    // await Task.Delay(1000); // Delay for 1 second
                }
            }
            #endregion

            HtmlGenerator.CreateHtmlDocument(outputFilePathHtml);

            List<string> lines = new List<string>();

            string allBookTitles = "";
            try
            {
                string bookPlot = "";

                #region Fill some main vars from file
                using (StreamReader readerPlot = new StreamReader(filePlot))
                {
                    string lline;
                    while ((lline = readerPlot.ReadLine()) != null)
                    {
                        // Add each line to the list
                        bookPlot += lline + '\n';
                    }
                }
                string bookTitles = "";
                using (StreamReader readerTitles = new StreamReader(filePath))
                {
                    string lline;
                    while ((lline = readerTitles.ReadLine()) != null)
                    {
                        // Add each line to the list
                        bookTitles += lline + '\n';
                    }
                }
                // Read all lines from the file
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string lline;
                    while ((lline = reader.ReadLine()) != null)
                    {
                        // Add each line to the list
                        lines.Add(lline);
                        allBookTitles += lline + '\n';
                    }
                }
                #endregion

                #region Init Some vars
                int liness = 0;
                int linessResponse = 0;
                string getResponseLiness = "";
                List<string> responseLines = new List<string>();
                string getResponse = "";
                string sFore = "";


                string summaryAnPlotPossibilities = ""; // Detrmine the plot for next chapter.
                string chosenWayForward = "";           // Chosen way forward for the next chapter.
                #endregion


                string sPrevious = "";
                string line = "";
                int chapterCount = 10; // Amount of Chapters we want to make.
                for (int i = 0; i < chapterCount; i++)
                {
                    sFore = DocHtmlVars.foreTitlePrefix;


                    #region Determine the chapters

                    if (_examples.Contains("dochtml"))
                    {

                        if (liness >= 1) // If second chapter and beyond
                        {
                            string foreRunning = "";

                            #region Chapter Stack
                            if (liness <= 3) // Build the first previous chapters stack
                            {
                                responseLines.Add(getResponse);
                                getResponseLiness = "";
                                foreach (string res in responseLines)
                                {
                                    getResponseLiness += res + '\n';
                                }
                            }
                            else // Shift chapter down in the Stack, LIFO principle. top is 
                            {
                                getResponseLiness = "";
                                List<string> resTemp = new List<string>();
                                foreach (string res in responseLines)
                                {
                                    resTemp.Add(res);
                                }
                                responseLines.Clear();
                                for (int iR = 1; iR <= 2; iR++)
                                {
                                    responseLines.Add((string)resTemp[iR]);
                                }
                                responseLines.Add(getResponse);
                                foreach (string res in responseLines)
                                {
                                    getResponseLiness += res + '\n';
                                }
                            }
                            #endregion


                            #region Creative or static prompts

                            bool doCreative = false;
                            if (doCreative)
                            {
                                string changeRunningPrompt = await GetCreativePrompt(getResponseLiness, foreRunning);
                                foreRunning = changeRunningPrompt;
                            }
                            else
                            {
                                foreRunning = GetPromptVars.SecondRunningPrompt;
                            }
                            sFore += " " +
                                foreRunning + " Make SURE THIS CHAPTER IS A NATURAL FIT AND CONTINUATION OF THE PREVIOUS CHAPTER" +
                                " and base the continuation on the plotline and most important elements of the previous chapter:"
                                + responseLines.Last() + " AND ALSO MAKE IT A NATURAL " +
                                "CONTINUATION AND ADDITION TO THE STORYLINE SO FAR that can be found in :" + getResponseLiness;
                        }
                        else
                        {
                            string foreRunning = GetPromptVars.FirstForePrompt;
                            //-------------------------------------------------
                            // Do the creative prompt from the start or not
                            //-------------------------------------------------
                            bool doCreative = false;
                            if (doCreative)
                            {
                                foreRunning = GetPromptVars.FirstForePrompt;
                                string changeRunningPrompt = await GetCreativePrompt(bookPlot, foreRunning);
                                foreRunning = changeRunningPrompt;
                            }
                            else
                            {
                                foreRunning = GetPromptVars.FirstForePrompt;
                            }
                            sFore += " " +
                                foreRunning + " Make it a very elaborative long chapter. Built upon plot - " + GetPromptVars._BookPlotLine;
                        }
                        string ExtraCatch = GetPromptVars.ExtraTouch;
                        sFore += ExtraCatch;

                        #endregion


                    }
                    else
                    {

                    }
                    #endregion

                    #region Create Image in the lines

                    if (_examples.Contains("dochtml"))
                    {
                        if (liness >= 1) // Base title on first in Stack.
                        {
                            summaryAnPlotPossibilities = await LargeGPT.CallLargeChatGPT("Create a detailed summary of the previous chapter " +
                                "with its plot line and most important elements to build further upon on the next chapter." +
                                "Offer the best possible option to continue the story based upon this previous chapter:" + responseLines.Last(), "o3-mini");

                            chosenWayForward = summaryAnPlotPossibilities;

                            iimage = await LargeGPT.CallLargeChatGPT("Create a good title based on the following chapter in max 5 words " +
                                "based on this summary:" + chosenWayForward, "o3-mini");
                        }
                        else // Based title on plot
                        {
                            iimage = await LargeGPT.CallLargeChatGPT("Create a good title based on this chapter in max 5 words:" + GetPromptVars._BookPlotLine, "o3-mini");
                        }
                    }
                    sClean =
                            iimage.Replace(":", "-").Replace(",", "").Replace("?", "").Replace("!", "")
                            .Replace("\"", "").Replace(";", "").TrimEnd().TrimStart(); ;
                    getQuote = await GetChatGPTSmallToken("Create a catchy smart quote on " + sClean);
                    sQuote = GlobalMethods.CleanStringBeforeFirstQuote(getQuote);
                    imagePath = "";

                    if (_examples.Contains("dochtml"))
                    {
                        string TopImage = GetPromptVars.MainHtmlImageTop;
                        makingImage = GetPromptVars.MainHtmlImageTop + " on the title - ";
                    }

                    #region Create Image for chapter
                    Simage = await GetDalleGood(makingImage
                               + iimage);
                    if (Simage.Contains("Bad Request")) // Probably from words and length
                    {
                        Simage = await GetDalleGood(makingImage
                        + sQuote);
                    }
                    await GlobalMethods.GetImageFromURL(Simage, outputFilePath, sClean);

                    success = false;
                    while (!success) // Sometimes this went wrong (time issue), so, while wrong repeat and it worked.
                    {
                        try
                        {
                            await GlobalMethods.ReduceImageSize(Simage, appPath + sClean + ".jpg");
                            success = true; // If the method completes successfully, set success to true to exit the loop
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"An error occurred JPG IMAGE REDUCTION!!!: {ex.Message}. Retrying...");
                            // Optionally, you can add a delay here before retrying
                            // await Task.Delay(1000); // Delay for 1 second
                        }
                    }
                    #endregion // Create Image for Chapter

                    #endregion // Create Image in the lines.

                    #region Append Titles in the lines
                    // Write title of chapter
                    // 
                    if (_examples.Contains("dochtml"))
                    {
                        HtmlGenerator.AppendToBody(outputFilePathHtml, "<div style='page-break-after: always;'></div>", "Quoted text added successfully.");
                        HtmlGenerator.AppendHeaderToHtml(outputFilePathHtml, iimage, "h1", "Tahoma");
                    }
                    else
                    {
                        GlobalMethods.AppendHeaderToWordExtendedWithPageBreak(outputFilePath, iimage, "Heading 1", "Arial");
                    }
                    #endregion

                    #region Write image and quote in lines
                    // Write image and quote
                    // 
                    if (_examples.Contains("dochtml"))
                    {
                        imagePath = appPath + sClean + ".jpg";
                        HtmlGenerator.AppendImageToHtml(outputFilePathHtml, imagePath);
                        getQuote = await GetChatGPTSmallToken("Create a catchy smart intelligent thought provoking quote of ONE LINE on: " + sClean);
                        sQuote = GlobalMethods.CleanStringBeforeFirstQuote(getQuote);
                        HtmlGenerator.InsertQuotedText(outputFilePathHtml, getQuote, true, true, "white", false, "black", "Garamond", 22);
                    }
                    else
                    {
                        imagePath = appPath + sClean + ".jpg";
                        GlobalMethods.AddImageToWordDocument(outputFilePath, imagePath);
                        getQuote = await GetChatGPTSmallToken("Create a catchy smart intelligent thought provoking quote on: " + sClean);
                        sQuote = GlobalMethods.CleanStringBeforeFirstQuote(getQuote);
                        GlobalMethods.InsertQuotedText(outputFilePath, sQuote, true, false, "White", false, "Black"); // Quote with Page Break
                    }
                    #endregion

                    #region Write the chapter content in the lines

                    if (_examples.Contains("dochtml"))
                    {
                        string front = "Make sure the text is put in an easy to read overview. Like this:"
                            + "<p>paragraph</p>"
                            + " but do not mention the chapter number and title at the start of the chapter.";

                        if (liness >= 1)
                        {
                            //sFore += " AND BE SURE IT USES THIS WAY FORWARD IN WRITING THE NEXT CHAPTER:" + chosenWayForward;
                            getResponse = await LargeGPT.CallLargeChatGPT(front + sFore, "o1") + "\n\n";
                        }
                        else
                            getResponse = await LargeGPT.CallLargeChatGPT(front + sFore, "o1") + "\n\n";

                        // Writing text and quote
                        getQuote = await GetChatGPTSmallToken("Create a catchy smart intelligent thought provoking quote on: " + sClean);
                        sQuote = GlobalMethods.CleanStringBeforeFirstQuote(getQuote);
                        HtmlGenerator.InsertQuotedText(outputFilePathHtml, sQuote, false, true, "white", false, "black", "Garamond", 22);

                        HtmlGenerator.AppendTextToHtmlDocument(outputFilePathHtml, getResponse, "Arial", 14);
                    }
                    else
                    {
                        // To be implemented.
                    }
                    #endregion

                    //await writer.WriteLineAsync(getResponse);
                    liness += 1;
                    linessResponse += 1;
                }
                ConvertHmlToPdf.ConvertToPdfAspose(outputFilePathHtml, outputFilePathPdf);
                //ConvertHmlToPdf.ConvertToPdf_Dink(outputFilePathHtml, outputFilePathPdf, appPath);
                byte[] pdfBytes = File.ReadAllBytes(outputFilePathPdf);
                string result = await GlobalMethods.WritePdfToBlobAsync(pdfBytes, "RHODAN - Perry Rhodan Universe - Unpredicted Universe v1.1.pdf", "mindscripted");
                Console.WriteLine("PDF upload to Blob:" + result);
                //HtmlGenerator.AppendClosingHtmlTags("output.html");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:" + ex.Message);
            }

        }
    }
}
