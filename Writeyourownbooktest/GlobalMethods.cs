
using Google.Apis.Auth.OAuth2;
using Google.Cloud.TextToSpeech.V1;
using HtmlAgilityPack;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using NAudio.Wave;
using OpenAI_API.Completions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Python.Runtime;
using DocumentFormat.OpenXml.ExtendedProperties;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models;
using Microsoft.Azure.CognitiveServices.Language.LUIS.Runtime;
using Microsoft.AspNetCore.Http;
using Microsoft.CognitiveServices.Speech.Audio;
using System.Reflection;
using Newtonsoft.Json;
using Google.Cloud.AIPlatform.V1;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml;
using OpenXmlPowerTools;
using System.IO;
using Aspose.Words;
using DinkToPdf;
using DinkToPdf.Contracts;
using Aspose.Pdf;
using PdfSharp.Pdf;
using HtmlRendererCore.PdfSharp;
using PromptConfig;

using DocumentFormat.OpenXml.Drawing;
using A = DocumentFormat.OpenXml.Drawing;
using WP = DocumentFormat.OpenXml.Drawing.Wordprocessing;
using PIC = DocumentFormat.OpenXml.Drawing.Pictures;
using Run = DocumentFormat.OpenXml.Wordprocessing.Run;
using Text = DocumentFormat.OpenXml.Wordprocessing.Text;
using Paragraph = DocumentFormat.OpenXml.Wordprocessing.Paragraph;
using ParagraphProperties = DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties;
using RunProperties = DocumentFormat.OpenXml.Wordprocessing.RunProperties;
using IronPython.Runtime.Operations;
using DocumentFormat.OpenXml.Drawing.Wordprocessing;
using Break = DocumentFormat.OpenXml.Wordprocessing.Break;
using System.Globalization;
using TopBorder = DocumentFormat.OpenXml.Wordprocessing.TopBorder;
using BottomBorder = DocumentFormat.OpenXml.Wordprocessing.BottomBorder;
using LeftBorder = DocumentFormat.OpenXml.Wordprocessing.LeftBorder;
using RightBorder = DocumentFormat.OpenXml.Wordprocessing.RightBorder;
using NonVisualGraphicFrameDrawingProperties = DocumentFormat.OpenXml.Drawing.Wordprocessing.NonVisualGraphicFrameDrawingProperties;
using Outline = DocumentFormat.OpenXml.Drawing.Outline;
using System.Drawing;
using Color = DocumentFormat.OpenXml.Wordprocessing.Color;
using DocumentFormat.OpenXml.Vml;
using Google.Protobuf.Reflection;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using Style = DocumentFormat.OpenXml.Wordprocessing.Style;

using System.Collections.Generic;
using Anchor = DocumentFormat.OpenXml.Drawing.Wordprocessing.Anchor;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Text.Json;
using Aspose.Words;
using Document = DocumentFormat.OpenXml.Wordprocessing.Document;
using Body = DocumentFormat.OpenXml.Wordprocessing.Body;
using Shading = DocumentFormat.OpenXml.Wordprocessing.Shading;
using Inline = DocumentFormat.OpenXml.Drawing.Wordprocessing.Inline;
using static IronPython.Modules._ast;
using Aspose.Words.LowCode;
using Google.Cloud.Translation.V2;
using Aspose.Pdf.Plugins;
using static Community.CsharpSqlite.Sqlite3;


namespace Writeyourownbooktest
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A global methods. </summary>
    ///
    /// <remarks>   Shadow, 4/2/2024. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class GlobalMethods
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Keep specific unicode characters. </summary>
        ///
        /// <remarks>   Shadow, 4/2/2024. </remarks>
        ///
        /// <param name="input">    The input. </param>
        ///
        /// <returns>   A string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string KeepSpecificUnicodeCharacters(string input)
        {
            // Define a StringBuilder to build the result string
            StringBuilder resultBuilder = new StringBuilder();

            // Iterate through each character in the input string
            foreach (char c in input)
            {
                // Get the Unicode code point of the character
                int codePoint = char.ConvertToUtf32(c.ToString(), 0);

                // Check if the code point falls within the range of characters you want to keep
                if (codePoint >= 230 && codePoint <= 239)
                {
                    // Append the character to the result
                    resultBuilder.Append(c);
                }
            }

            // Convert the StringBuilder to a string
            string result = resultBuilder.ToString();

            return result;
        }
        public static string CleanStringAfterLastNumber(string input)
        {
            // Find the last number in the string using a regular expression
            Match match = Regex.Match(input, @"\d+(?!.*\d)");

            // If a match is found, remove everything after the last number
            if (match.Success)
            {
                int lastIndex = match.Index + match.Length;
                return input.Substring(0, lastIndex);
            }

            // If no number is found, return the original string
            return input;
        }
        public static string CleanStringBeforeFirstQuote(string input)
        {
            // Find the index of the first double quote
            int index = input.IndexOf('"');

            // If a double quote is found, return the substring starting from the first quote
            if (index != -1)
            {
                return input.Substring(index);
            }

            // If no double quote is found, return the original string
            return input;
        }
        public static string CleanStringAfterLastQuote(string input)
        {
            // Find the index of the last double quote
            int index = input.LastIndexOf('"');

            // If a double quote is found, return the substring up to and including the last quote
            if (index != -1)
            {
                return input.Substring(0, index + 1);
            }

            // If no double quote is found, return the original string
            return input;
        }

        public static string ReplaceAndCapitalize(string input, string replacer)
        {
            string phrase = replacer;
            int index = input.IndexOf(phrase, StringComparison.OrdinalIgnoreCase);

            // If the phrase is found
            if (index != -1)
            {
                // Remove the phrase from the input string
                input = input.Remove(index, phrase.Length);

                // Capitalize the first letter of the remaining string
                if (index < input.Length)
                {
                    input = input.Substring(0, index) +
                            char.ToUpper(input[index], CultureInfo.InvariantCulture) +
                            input.Substring(index + 1);
                }
            }

            return input;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Appends a text to file. </summary>
        ///
        /// <remarks>   Shadow, 4/2/2024. </remarks>
        ///
        /// <param name="filePath"> Full pathname of the file. </param>
        /// <param name="content">  The content. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void AppendTextToFile(string filePath, string content)
        {
            try
            {
                // Use File.AppendText to open the file in append mode
                using (StreamWriter writer = File.AppendText(filePath))
                {
                    // Write the content to the file
                    writer.WriteLine(content);
                }

                Console.WriteLine("Text appended to the file successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        public static async Task GetImageFromURL(string url, string docLocation, string iimage)
        {
            string imageUrl = url; // Replace with the actual URL of the image
            string fileName = iimage + ".jpg"; // The name you want to save the file as

            try
            {
                await DownloadAndSaveImageAsync(imageUrl, fileName, docLocation);
                Console.WriteLine("Image downloaded and saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
        #region WordDocument
        public static async Task<byte[]> DownloadImageAsByteArrayAsync(string imageUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Send a GET request to the specified URL
                    HttpResponseMessage response = await client.GetAsync(imageUrl);
                    // Ensure we received a successful response.
                    response.EnsureSuccessStatusCode();

                    // Read the response content into a byte array
                    byte[] imageData = await response.Content.ReadAsByteArrayAsync();
                    return imageData;
                }
                catch (Exception ex)
                {
                    // Log or handle exceptions as needed
                    Console.WriteLine("An error occurred while downloading the image: " + ex.Message);
                    return null;
                }
            }
        }
        public static void AddImageFromBytesToDocument(string documentPath, byte[] imageData)
        {
            using (WordprocessingDocument wordDocument = WordprocessingDocument.Open(documentPath, true))
            {
                MainDocumentPart mainPart = wordDocument.MainDocumentPart;
                if (mainPart == null)
                {
                    mainPart = wordDocument.AddMainDocumentPart();
                    mainPart.Document = new Document(new Body());
                }

                ImagePart imagePart = mainPart.AddImagePart(ImagePartType.Jpeg);

                // Feed the image data directly into the image part
                using (MemoryStream stream = new MemoryStream(imageData))
                {
                    imagePart.FeedData(stream);
                }

                string relationshipId = mainPart.GetIdOfPart(imagePart);

                // Define the reference of the image
                Drawing imageElement = CreateImageElement(relationshipId);

                // Append the image to the body of the document
                Body body = mainPart.Document.Body;
                Paragraph paragraph = new Paragraph(new Run(imageElement));
                body.Append(paragraph);

                mainPart.Document.Save();
            }
        }

        private static Drawing CreateImageElement(string relationshipId)
        {
            // Define the reference of the image.
            return new Drawing(
                new WP.Inline(
                    new WP.Extent() { Cx = 990000L, Cy = 792000L }, // Define your desired image size here
                    new WP.EffectExtent { LeftEdge = 0, TopEdge = 0, RightEdge = 0, BottomEdge = 0 },
                    new WP.DocProperties { Id = 1U, Name = "Picture" },
                    new WP.NonVisualGraphicFrameDrawingProperties(new A.GraphicFrameLocks { NoChangeAspect = true }),
                    new A.Graphic(
                        new A.GraphicData(
                            new PIC.Picture(
                                new PIC.NonVisualPictureProperties(
                                    new PIC.NonVisualDrawingProperties { Id = 0U, Name = "New Image" },
                                    new PIC.NonVisualPictureDrawingProperties()
                                ),
                                new PIC.BlipFill(
                                    new A.Blip { Embed = relationshipId, CompressionState = A.BlipCompressionValues.Print },
                                    new A.Stretch(new A.FillRectangle())
                                ),
                                new PIC.ShapeProperties(
                                    new A.Transform2D(new A.Offset { X = 0L, Y = 0L }, new A.Extents { Cx = 990000L, Cy = 792000L })
                                )
                            )
                        )
                        { Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture" }
                    )
                )
                { DistanceFromTop = 0U, DistanceFromBottom = 0U, DistanceFromLeft = 0U, DistanceFromRight = 0U }
            );
        }

        private static async Task DownloadAndSaveImageAsync(string url, string fileName, string docLocation)
        {
            string appPath = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = System.IO.Path.Combine(appPath, fileName.Replace(":", "").Replace(",", ""));

            using (HttpClient client = new HttpClient())
            {
                // Send GET request to fetch the image
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                // Get the absolute path of the running application


                // Read the response stream
                using (var stream = await response.Content.ReadAsStreamAsync())
                using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    // Save the stream to the file
                    await stream.CopyToAsync(fileStream);
                }
            }
            //AddImageToExistingDocument(docLocation, filePath);
        }

        public static string GetSubStringForImages(string subber, string questionFront)
        {

            // Example input string
            string input = subber;

            // Define the start marker
            string startMarker = questionFront;

            // Find the start index
            int startIndex = input.IndexOf(startMarker);
            if (startIndex == -1)
            {
                Console.WriteLine("Start marker not found.");
                return "starter not found";
            }

            // Adjust start index to get the substring after the start marker
            startIndex += startMarker.Length;

            // Extract the substring from the start index to the end of the string
            string result = input.Substring(startIndex);

            // Print the result
            Console.WriteLine(result);
            return result;

        }

        public static void AppendHeaderToWordDocument(string filePath, string headerText)
        {
            try
            {
                // Open the Word document in edit mode
                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(filePath, true))
                {
                    // Get the main document part
                    MainDocumentPart mainPart = wordDoc.MainDocumentPart;

                    // If the document is empty, add a new main document part
                    if (mainPart == null)
                    {
                        mainPart = wordDoc.AddMainDocumentPart();
                        mainPart.Document = new Document();
                        mainPart.Document.AppendChild(new Body());
                    }

                    // Create a new paragraph with the specified header style
                    Paragraph para = new Paragraph();
                    ParagraphProperties paraProperties = new ParagraphProperties();
                    paraProperties.ParagraphStyleId = new ParagraphStyleId() { Val = "Heading1" };
                    para.Append(paraProperties);
                    para.Append(new Run(new Text(headerText)));

                    // Append the paragraph to the document body
                    mainPart.Document.Body.AppendChild(para);

                    // Save changes to the document
                    mainPart.Document.Save();
                }

                Console.WriteLine("Header added to the Word document successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        public static void AppendHeaderTotWordExtended(string filePath, string headerText, string headerlevel)
        {
            try
            {
                // Open the Word document in edit mode
                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(filePath, true))
                {
                    // Get the main document part
                    MainDocumentPart mainPart = wordDoc.MainDocumentPart;

                    // If the document is empty, add a new main document part
                    if (mainPart == null)
                    {
                        mainPart = wordDoc.AddMainDocumentPart();
                        mainPart.Document = new Document(new Body());
                    }

                    // Ensure styles part exists; if not, add one
                    StyleDefinitionsPart stylePart = mainPart.StyleDefinitionsPart;
                    if (stylePart == null)
                    {
                        stylePart = mainPart.AddNewPart<StyleDefinitionsPart>();
                        stylePart.Styles = new Styles();
                        stylePart.Styles.Save();
                    }

                    // Check if "Heading1" style exists, and create if not
                    Style style = stylePart.Styles.Descendants<Style>()
                        .FirstOrDefault(s => s.StyleId == "Heading1" && s.Type == StyleValues.Paragraph);
                    if (style == null)
                    {
                        style = new Style()
                        {
                            StyleId = "Heading1",
                            Type = StyleValues.Paragraph
                        };
                        style.Append(new DocumentFormat.OpenXml.Wordprocessing.Name() { Val = headerlevel });
                        style.Append(new BasedOn() { Val = "Normal" });
                        style.Append(new NextParagraphStyle() { Val = "Normal" });
                        style.Append(new UIPriority() { Val = 9 });
                        style.Append(new PrimaryStyle());
                        StyleRunProperties styleRunProps = new StyleRunProperties();
                        styleRunProps.Append(new Bold());
                        styleRunProps.Append(new FontSize() { Val = "32" });  // Font size in half-points, 36 is 18pt
                        style.Append(styleRunProps);
                        style.Append(new StyleParagraphProperties(new SpacingBetweenLines() { After = "200" }));
                        stylePart.Styles.Append(style);
                        stylePart.Styles.Save();
                    }

                    // Create a new paragraph with the specified header style
                    Paragraph para = new Paragraph();
                    ParagraphProperties paraProperties = new ParagraphProperties();
                    paraProperties.ParagraphStyleId = new ParagraphStyleId() { Val = "Heading1" };
                    para.Append(paraProperties);
                    para.Append(new Run(new Text(headerText)));

                    // Append the paragraph to the document body
                    mainPart.Document.Body.AppendChild(para);

                    // Save changes to the document
                    mainPart.Document.Save();
                }

                Console.WriteLine("Header added to the Word document successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        public static void AddPageBreak(string filePath)
        {
            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(filePath, true))
            {
                // Get the main document part
                MainDocumentPart mainPart = wordDoc.MainDocumentPart;
                if (mainPart != null && mainPart.Document != null && mainPart.Document.Body != null)
                {
                    // Create a new paragraph with a page break
                    Paragraph pageBreakParagraph = new Paragraph(new Run(new Break() { Type = BreakValues.Page }));

                    // Append the new paragraph to the body
                    mainPart.Document.Body.AppendChild(pageBreakParagraph);

                    // Save the changes to the document
                    mainPart.Document.Save();
                }
            }
        }
        public static void AppendHeaderToWordExtendedWithPageBreak(string filePath, string headerText, string headerLevel, string fontType = "Old English Text MT")
        {
            try
            {
                // Open the Word document in edit mode
                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(filePath, true))
                {
                    // Get the main document part
                    MainDocumentPart mainPart = wordDoc.MainDocumentPart;

                    // If the document is empty, add a new main document part
                    if (mainPart == null)
                    {
                        mainPart = wordDoc.AddMainDocumentPart();
                        mainPart.Document = new Document(new Body());
                    }

                    // Ensure styles part exists; if not, add one
                    StyleDefinitionsPart stylePart = mainPart.StyleDefinitionsPart;
                    if (stylePart == null)
                    {
                        stylePart = mainPart.AddNewPart<StyleDefinitionsPart>();
                        stylePart.Styles = new Styles();
                        stylePart.Styles.Save();
                    }

                    // Check if the required header style exists, and create if not
                    Style style = stylePart.Styles.Descendants<Style>()
                        .FirstOrDefault(s => s.StyleId == headerLevel && s.Type == StyleValues.Paragraph);
                    if (style == null)
                    {
                        style = new Style()
                        {
                            StyleId = headerLevel,
                            Type = StyleValues.Paragraph
                        };
                        style.Append(new DocumentFormat.OpenXml.Wordprocessing.Name() { Val = headerLevel });
                        style.Append(new BasedOn() { Val = "Normal" });
                        style.Append(new NextParagraphStyle() { Val = "Normal" });
                        style.Append(new UIPriority() { Val = 9 });
                        style.Append(new PrimaryStyle());
                        StyleRunProperties styleRunProps = new StyleRunProperties();
                        styleRunProps.Append(new Bold());
                        styleRunProps.Append(new FontSize() { Val = "32" }); // Font size in half-points, 32 is 16pt

                        // Add font type if specified
                        if (!string.IsNullOrEmpty(fontType))
                        {
                            styleRunProps.Append(new RunFonts() { Ascii = fontType, HighAnsi = fontType });
                        }

                        style.Append(styleRunProps);
                        style.Append(new StyleParagraphProperties(new SpacingBetweenLines() { After = "200" }));
                        stylePart.Styles.Append(style);
                        stylePart.Styles.Save();
                    }


                    // Create and append a page break before the header
                    Paragraph breakPara = new Paragraph(new Run(new Break() { Type = BreakValues.Page }));
                    mainPart.Document.Body.AppendChild(breakPara);


                    // Create a new paragraph with the specified header style
                    Paragraph para = new Paragraph();
                    ParagraphProperties paraProperties = new ParagraphProperties();
                    paraProperties.ParagraphStyleId = new ParagraphStyleId() { Val = headerLevel };
                    para.Append(paraProperties);
                    para.Append(new Run(new Text(headerText)));

                    // Append the paragraph to the document body
                    mainPart.Document.Body.AppendChild(para);

                    // Save changes to the document
                    mainPart.Document.Save();
                }

                Console.WriteLine("Header added to the Word document successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private static bool DocumentHasTextBeforeHeader(MainDocumentPart mainPart)
        {
            Body body = mainPart.Document.Body;
            if (body == null) return false;

            var paragraphs = body.Elements<Paragraph>().ToList();
            foreach (var para in paragraphs)
            {
                // Check if the paragraph has text that is not whitespace
                if (para.InnerText.Trim().Length > 0)
                {
                    return true;
                }

                // Check for existing page breaks
                if (para.Elements<Run>().Any(run => run.Elements<Break>().Any(b => b.Type == BreakValues.Page)))
                {
                    // Stop searching further if a page break is found
                    return false;
                }
            }

            return false;
        }

        public static void RemovePageBreaksOnEmptyPages(string filePath)
        {
            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(filePath, true))
            {
                // Get the main document part
                MainDocumentPart mainPart = wordDoc.MainDocumentPart;
                if (mainPart != null && mainPart.Document != null && mainPart.Document.Body != null)
                {
                    Body body = mainPart.Document.Body;
                    var paragraphs = body.Elements<Paragraph>().ToList();

                    bool isPreviousPageEmpty = true;
                    foreach (var para in paragraphs)
                    {
                        bool isEmptyParagraph = string.IsNullOrWhiteSpace(para.InnerText);

                        if (isEmptyParagraph && para.Elements<Run>().Any(run => run.Elements<Break>().Any(b => b.Type == BreakValues.Page)))
                        {
                            if (isPreviousPageEmpty)
                            {
                                para.Remove();
                            }
                        }
                        else
                        {
                            isPreviousPageEmpty = false;
                        }

                        if (para.Elements<Run>().Any(run => run.Elements<Break>().Any(b => b.Type == BreakValues.Page)))
                        {
                            isPreviousPageEmpty = true;
                        }
                    }

                    // Save the changes to the document
                    mainPart.Document.Save();
                }
            }
        }
        public static void RemoveEmptyPages(string filePath)
        {
            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(filePath, true))
            {
                // Get the main document part
                MainDocumentPart mainPart = wordDoc.MainDocumentPart;
                if (mainPart != null && mainPart.Document != null && mainPart.Document.Body != null)
                {
                    Body body = mainPart.Document.Body;
                    var paragraphs = body.Elements<Paragraph>().ToList();

                    bool inEmptyPage = true;
                    foreach (var para in paragraphs)
                    {
                        bool isEmptyParagraph = para.Elements<Run>().All(run =>
                            string.IsNullOrWhiteSpace(run.InnerText) && !run.Elements<Break>().Any());

                        if (!isEmptyParagraph)
                        {
                            inEmptyPage = false;
                        }

                        if (isEmptyParagraph && inEmptyPage)
                        {
                            para.Remove();
                        }

                        if (para.Elements<Run>().Any(run => run.Elements<Break>().Any(b => b.Type == BreakValues.Page)))
                        {
                            inEmptyPage = true;
                        }
                    }

                    // Save the changes to the document
                    mainPart.Document.Save();
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="basePath"></param>
        /// <returns></returns>
        public static Dictionary<char, System.Drawing.Image> LoadAlphabetImages(string directory)
        {
            // Dictionary to hold the images
            Dictionary<char, System.Drawing.Image> alphabetImages = new Dictionary<char, System.Drawing.Image>();

            // Iterate over each letter of the alphabet
            for (char letter = 'A'; letter <= 'Z'; letter++)
            {
                string fileName = $"{letter}.jpg";
                string filePath = System.IO.Path.Combine(directory, fileName);

                if (File.Exists(filePath))
                {
                    System.Drawing.Image image = System.Drawing.Image.FromFile(filePath);
                    alphabetImages.Add(letter, image);
                    Console.WriteLine($"Loaded image for {letter}");
                }
                else
                {
                    Console.WriteLine($"Image for {letter} not found.");
                }
            }

            return alphabetImages;
        }

        public static void AppendBoldTextToWord(string filePath, string text, bool pageBreak, string fontType = "Old English Text MT"
            , int fontSize = 24)
        {
            try
            {
                // Open the Word document in edit mode
                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(filePath, true))
                {
                    // Get the main document part
                    MainDocumentPart mainPart = wordDoc.MainDocumentPart;

                    // If the document is empty, add a new main document part
                    if (mainPart == null)
                    {
                        mainPart = wordDoc.AddMainDocumentPart();
                        mainPart.Document = new Document(new Body());
                    }

                    // Ensure styles part exists; if not, add one
                    StyleDefinitionsPart stylePart = mainPart.StyleDefinitionsPart;
                    if (stylePart == null)
                    {
                        stylePart = mainPart.AddNewPart<StyleDefinitionsPart>();
                        stylePart.Styles = new Styles();
                        stylePart.Styles.Save();
                    }

                    // Define a new style for bold text with the specified font type and size
                    Style boldStyle = new Style()
                    {
                        StyleId = "BoldText", // Custom Style ID
                        Type = StyleValues.Paragraph
                    };
                    boldStyle.Append(new DocumentFormat.OpenXml.Wordprocessing.Name() { Val = "BoldText" });
                    boldStyle.Append(new BasedOn() { Val = "Normal" });
                    boldStyle.Append(new NextParagraphStyle() { Val = "Normal" });
                    boldStyle.Append(new UIPriority() { Val = 9 });
                    boldStyle.Append(new PrimaryStyle());
                    StyleRunProperties styleRunProps = new StyleRunProperties();
                    styleRunProps.Append(new Bold());
                    styleRunProps.Append(new RunFonts() { Ascii = fontType }); // Set the font type
                    styleRunProps.Append(new FontSize() { Val = (fontSize * 2).ToString() }); // Set the font size (Word font size is in half-points)
                    boldStyle.Append(styleRunProps);
                    boldStyle.Append(new StyleParagraphProperties(new SpacingBetweenLines() { After = "200" }));
                    stylePart.Styles.Append(boldStyle);
                    stylePart.Styles.Save();

                    // Create a new paragraph with the custom bold style
                    Paragraph para = new Paragraph();
                    ParagraphProperties paraProperties = new ParagraphProperties();
                    paraProperties.ParagraphStyleId = new ParagraphStyleId() { Val = "BoldText" };
                    para.Append(paraProperties);
                    para.Append(new Run(new Text(text)));

                    if (pageBreak)
                    {
                        // Create and append a page break before the header
                        Paragraph breakPara = new Paragraph(new Run(new Break() { Type = BreakValues.Page }));
                        mainPart.Document.Body.AppendChild(breakPara);
                    }

                    // Append the paragraph to the document body
                    mainPart.Document.Body.AppendChild(para);

                    // Save changes to the document
                    mainPart.Document.Save();
                }

                Console.WriteLine("Text added to the Word document successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public static void AppendTextToWordDocumentCorrectFormat(string filepath, string text)
        {
            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(filepath, true))
            {
                var docBody = wordDoc.MainDocumentPart.Document.Body;

                // Ensure that there's at least one paragraph to append to
                Paragraph para = docBody.AppendChild(new Paragraph(new ParagraphProperties(new SpacingBetweenLines() { After = "200" })));

                // Create a run with text
                Run run = new Run();
                // Optionally set run properties such as font size
                RunProperties runProperties = new RunProperties();
                runProperties.Append(new FontSize() { Val = "24" }); // Font size is in half-points, 24 is 12pt
                runProperties.Append(new RunFonts() { Ascii = "Arial" }); // Setting font family to Arial

                run.Append(runProperties);

                // Create a text element with the input text
                Text textElement = new Text(text);
                run.Append(textElement);

                // Add run to the paragraph
                para.Append(run);

                // Save changes to the document
                wordDoc.MainDocumentPart.Document.Save();
            }

        }
        public static string GetAllExceptFirst(string input)
        {
            if (string.IsNullOrEmpty(input) || input.Length == 1)
            {
                return string.Empty; // Return empty string if input is null, empty, or has only one character
            }

            return input.Substring(1);
        }

        public static void AppendTextToWordDocumentCorrectFormatSplit(string filepath, string textToSynthesize,
    string fontt = "Old English Text MT", double fontSize = 14.5)
        {
            // Open the document for editing
            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(filepath, true))
            {
                var docBody = wordDoc.MainDocumentPart.Document.Body;

                // Split the input text into potential paragraphs on new line
                string[] paragraphs = textToSynthesize.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);

                foreach (string paragraphText in paragraphs)
                {
                    // Check if the line is not just an empty string
                    if (!string.IsNullOrWhiteSpace(paragraphText))
                    {
                        // Create a new paragraph with a run and text
                        Paragraph para = new Paragraph();
                        ParagraphProperties paraProps = new ParagraphProperties();

                        // Set paragraph alignment to justified
                        Justification justification = new Justification() { Val = JustificationValues.Both };
                        paraProps.Append(justification);

                        // Set the font and font size
                        RunProperties runProperties = new RunProperties();
                        RunFonts runFont = new RunFonts() { Ascii = fontt };
                        FontSize size = new FontSize() { Val = (fontSize * 2).ToString() }; // FontSize value should be twice the point size (in half-points)
                        runProperties.Append(runFont);
                        runProperties.Append(size);

                        para.AppendChild(paraProps);

                        Run run = new Run(new Text(paragraphText));
                        run.PrependChild(runProperties); // Prepend the run properties to apply the font

                        // Append the styled paragraph to the document body
                        para.AppendChild(run);
                        docBody.Append(para);
                    }
                }

                // Save changes to the document
                wordDoc.MainDocumentPart.Document.Save();
            }
        }

        private static void AddImageToBodyWithWrapping(WordprocessingDocument wordDoc, string imagePath, string sQuote, int imWidth = 512, int imHeight = 0, string imAlign = "center")
        {
            // Load the image to get its dimensions
            int imageWidth, imageHeight;
            using (System.Drawing.Image image = System.Drawing.Image.FromFile(imagePath))
            {
                // Use provided width and height or the image's original dimensions
                imageWidth = imWidth;
                imageHeight = imHeight == 0 ? image.Height : imHeight;
            }

            // Calculate size in EMUs (English Metric Units)
            long widthInEmus = imageWidth * 9525;
            long heightInEmus = imageHeight * 9525;

            // Create a new image part in the document
            MainDocumentPart mainPart = wordDoc.MainDocumentPart;
            ImagePart imagePart = mainPart.AddImagePart(ImagePartType.Jpeg);

            // Copy the image into the new image part
            using (FileStream stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                imagePart.FeedData(stream);
            }

            // Get the relationship ID of the new image part
            string relationshipId = mainPart.GetIdOfPart(imagePart);

            // Create the Drawing element with wrapping
            var element = new Drawing(
                new Anchor(
                    new SimplePosition() { X = 0L, Y = 0L },
                    new HorizontalPosition()
                    {
                        RelativeFrom = HorizontalRelativePositionValues.Margin,
                        PositionOffset = new PositionOffset("0")
                    },
                    new VerticalPosition()
                    {
                        RelativeFrom = VerticalRelativePositionValues.Paragraph,
                        PositionOffset = new PositionOffset("0")
                    },
                    new Extent() { Cx = widthInEmus, Cy = heightInEmus },
                    new EffectExtent()
                    {
                        LeftEdge = 0L,
                        TopEdge = 0L,
                        RightEdge = 0L,
                        BottomEdge = 0L
                    },
                    new WrapSquare() { WrapText = WrapTextValues.BothSides },
                    new DocProperties() { Id = (UInt32Value)1U, Name = "Picture 1" },
                    new NonVisualGraphicFrameDrawingProperties(new DocumentFormat.OpenXml.Drawing.GraphicFrameLocks() { NoChangeAspect = true }),
                    new DocumentFormat.OpenXml.Drawing.Graphic(
                        new DocumentFormat.OpenXml.Drawing.GraphicData(
                            new DocumentFormat.OpenXml.Drawing.Pictures.Picture(
                                new DocumentFormat.OpenXml.Drawing.Pictures.NonVisualPictureProperties(
                                    new DocumentFormat.OpenXml.Drawing.Pictures.NonVisualDrawingProperties()
                                    {
                                        Id = (UInt32Value)0U,
                                        Name = "Image.jpg"
                                    },
                                    new DocumentFormat.OpenXml.Drawing.Pictures.NonVisualPictureDrawingProperties()
                                ),
                                new DocumentFormat.OpenXml.Drawing.Pictures.BlipFill(
                                    new DocumentFormat.OpenXml.Drawing.Blip() { Embed = relationshipId },
                                    new DocumentFormat.OpenXml.Drawing.Stretch(new DocumentFormat.OpenXml.Drawing.FillRectangle())
                                ),
                                new DocumentFormat.OpenXml.Drawing.Pictures.ShapeProperties(
                                    new DocumentFormat.OpenXml.Drawing.Transform2D(
                                        new DocumentFormat.OpenXml.Drawing.Offset() { X = 0L, Y = 0L },
                                        new DocumentFormat.OpenXml.Drawing.Extents() { Cx = widthInEmus, Cy = heightInEmus }
                                    ),
                                    new DocumentFormat.OpenXml.Drawing.PresetGeometry(new DocumentFormat.OpenXml.Drawing.AdjustValueList()) { Preset = DocumentFormat.OpenXml.Drawing.ShapeTypeValues.Rectangle },
                                    new DocumentFormat.OpenXml.Drawing.Outline(
                                        new DocumentFormat.OpenXml.Drawing.SolidFill(
                                            new DocumentFormat.OpenXml.Drawing.RgbColorModelHex() { Val = "8B4513" } // Brown border color
                                        )
                                    )
                                )
                            )
                        )
                        { Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture" }
                    )
                )
                {
                    DistanceFromTop = (UInt32Value)57150L, // Reduced top margin to 0.05 inch
                    DistanceFromBottom = (UInt32Value)114300L, // 0.1 inch margin
                    DistanceFromLeft = (UInt32Value)114300L, // 0.1 inch margin
                    DistanceFromRight = (UInt32Value)114300L, // 0.1 inch margin
                    SimplePos = false,
                    RelativeHeight = (UInt32Value)251658240U,
                    BehindDoc = false,
                    Locked = false,
                    LayoutInCell = true,
                    AllowOverlap = true
                }
            );

            Paragraph paragraph = new Paragraph(new Run(element));

            // Append the Drawing element to the document body
            wordDoc.MainDocumentPart.Document.Body.AppendChild(paragraph);
        }

        public static void AddEmptyLineToWordDocument(string filePath)
        {
            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(filePath, true))
            {
                Body body = wordDoc.MainDocumentPart.Document.Body;

                // Create a new paragraph with a blank line
                Paragraph paragraph = new Paragraph();
                Run run = new Run(new Text(string.Empty));
                paragraph.Append(run);

                // Add the paragraph to the body
                body.Append(paragraph);

                // Save changes to the document
                wordDoc.MainDocumentPart.Document.Save();
            }
        }
        public static char GetFirstCharacter(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return '\0'; // Return null character if the input is null or empty
            }

            foreach (char c in input)
            {
                if (!char.IsWhiteSpace(c) && !char.IsControl(c))
                {
                    return c;
                }
            }

            return '\0'; // Return null character if no printable character is found
        }
        public static void ExtractFirstCharacter(string input, out char firstChar, out string remainingString)
        {
            firstChar = '\0';
            remainingString = input;

            if (string.IsNullOrEmpty(input))
            {
                return;
            }

            for (int i = 0; i < input.Length; i++)
            {
                if (!char.IsWhiteSpace(input[i]) && !char.IsControl(input[i]))
                {
                    firstChar = input[i];
                    remainingString = input.Substring(i + 1);
                    return;
                }
            }
        }

        public static void InsertQuotedText(string filePath, string quoteText, bool pageBreak, bool italic,
      string colorBackground, bool _borders, string textColor, string fontType = "Garamond", int fontSize = 16)
        {
            try
            {
                // Open the Word document for editing
                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(filePath, true))
                {
                    var docBody = wordDoc.MainDocumentPart.Document.Body;

                    // Create a new paragraph for the quote
                    Paragraph para = new Paragraph();
                    ParagraphProperties paraProps = new ParagraphProperties();

                    // Set paragraph alignment to center
                    Justification justification = new Justification() { Val = JustificationValues.Center };
                    paraProps.Append(justification);

                    // Create a run to hold the quote text
                    Run run = new Run();
                    RunProperties runProps = new RunProperties();

                    if (italic)
                    {
                        // Set the text to be italic
                        Italic italicElement = new Italic();
                        runProps.Append(italicElement);
                    }

                    // Set the text color
                    Color color = new Color() { Val = textColor };
                    runProps.Append(color);

                    // Set the font type if specified
                    if (!string.IsNullOrEmpty(fontType))
                    {
                        runProps.Append(new RunFonts() { Ascii = fontType, HighAnsi = fontType });
                    }

                    // Set the font size (Word font size is in half-points)
                    runProps.Append(new FontSize() { Val = (fontSize * 2).ToString() });

                    // Add the run properties to the run
                    run.Append(runProps);

                    // Set the quote text directly without additional quotation marks
                    Text text = new Text(quoteText);
                    run.Append(text);

                    // Append run to the paragraph
                    para.Append(paraProps);
                    para.Append(run);

                    if (_borders)
                    {
                        // Create a border around the paragraph
                        ParagraphBorders borders = new ParagraphBorders(
                            new TopBorder() { Val = BorderValues.Single, Color = textColor, Size = 15 },
                            new BottomBorder() { Val = BorderValues.Single, Color = textColor, Size = 15 },
                            new LeftBorder() { Val = BorderValues.Single, Color = textColor, Size = 15 },
                            new RightBorder() { Val = BorderValues.Single, Color = textColor, Size = 15 }
                        );

                        paraProps.Append(borders);

                        // Add a light grey background
                        Shading shading = new Shading()
                        {
                            Val = ShadingPatternValues.Clear,
                            Color = "auto",
                            Fill = colorBackground  // Light grey color
                        };

                        paraProps.Append(shading);
                    }

                    // Append the paragraph to the document body
                    docBody.Append(para);

                    if (pageBreak)
                    {
                        // Create and append a page break after the quote
                        Paragraph breakParagraph = new Paragraph(new Run(new Break() { Type = BreakValues.Page }));
                        docBody.Append(breakParagraph);
                    }
                    else
                    {
                        // Create and append an extra line (empty paragraph) after the quote
                        Paragraph extraLine = new Paragraph(new Run(new Text(string.Empty)));
                        docBody.Append(extraLine);
                    }

                    // Save changes to the document
                    wordDoc.MainDocumentPart.Document.Save();
                }

                Console.WriteLine("Quoted text added and centered in the Word document successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }


        public static void InsertPageBreak(WordprocessingDocument wordDoc)
        {
            // Get the main document part
            MainDocumentPart mainPart = wordDoc.MainDocumentPart;

            // Create a new paragraph
            Paragraph paragraph = new Paragraph();

            // Create a new run
            Run run = new Run();

            // Create a page break
            Break pageBreak = new Break() { Type = BreakValues.Page };

            // Add the page break to the run
            run.Append(pageBreak);

            // Add the run to the paragraph
            paragraph.Append(run);

            // Add the paragraph to the document body
            mainPart.Document.Body.Append(paragraph);

            // Save the changes to the main document part
            mainPart.Document.Save();
        }
        public static void CreateQuoteBoxWithBackground(string imagePath, string outputPath, string quote, int fontSize = 16,
    string fontType = "Old English Text MT", int borderWidth = 5)
        {
            using (System.Drawing.Image image = System.Drawing.Image.FromFile(imagePath))
            {
                int pageWidth = 512; // example page width
                float aspectRatio = (float)image.Width / image.Height;
                int newWidth = pageWidth;
                int newHeight = (int)(pageWidth / aspectRatio);

                // Adjust dimensions to include border
                int borderedWidth = newWidth + 2 * borderWidth;
                int borderedHeight = newHeight + 2 * borderWidth;

                using (Bitmap bitmap = new Bitmap(newWidth, newHeight))
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    // Draw the resized image
                    graphics.DrawImage(image, 0, 0, newWidth, newHeight);

                    // Define font and measure the size of the quote text
                    System.Drawing.Font font = new System.Drawing.Font(fontType, fontSize, FontStyle.Bold);
                    SizeF textSize = graphics.MeasureString(quote, font, pageWidth - 40); // Measure with max width constraint
                    int padding = 20;

                    // Calculate the dimensions of the quote box
                    int boxWidth = (int)textSize.Width + padding * 2;
                    int boxHeight = (int)textSize.Height + padding * 2;

                    // Calculate the number of lines for the quote
                    int lineHeight = (int)textSize.Height;
                    int numberOfLines = (int)Math.Ceiling(textSize.Width / (pageWidth - padding * 2));

                    // Set the new height to match the quote lines
                    newHeight = numberOfLines * lineHeight + padding * 2;
                    borderedHeight = newHeight + 2 * borderWidth;

                    using (Bitmap finalBitmap = new Bitmap(borderedWidth, borderedHeight))
                    using (Graphics finalGraphics = Graphics.FromImage(finalBitmap))
                    {
                        // Fill background with border color
                        finalGraphics.Clear(System.Drawing.Color.Black); // Change the border color as needed

                        // Draw the resized image on the final bitmap with border offset
                        finalGraphics.DrawImage(bitmap, borderWidth, borderWidth, newWidth, newHeight);

                        // Define rectangle for the quote box
                        int boxX = (borderedWidth - boxWidth) / 2;
                        int boxY = (borderedHeight - boxHeight) / 2;
                        System.Drawing.Rectangle quoteBox = new System.Drawing.Rectangle(boxX, boxY, boxWidth, boxHeight);

                        // Draw semi-transparent rectangle
                        System.Drawing.Color semiTransparentWhite = System.Drawing.Color.FromArgb(128, System.Drawing.Color.White);
                        System.Drawing.Color fullyTransparentWhite = System.Drawing.Color.FromArgb(0, 255, 255, 255);

                        using (SolidBrush brush = new SolidBrush(fullyTransparentWhite))
                        {
                            finalGraphics.FillRectangle(brush, quoteBox);
                        }

                        // Define alignment for the quote text
                        StringFormat format = new StringFormat
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Center
                        };

                        // Draw quote text
                        using (SolidBrush textBrush = new SolidBrush(System.Drawing.Color.Black))
                        {
                            finalGraphics.DrawString(quote, font, textBrush, quoteBox, format);
                        }

                        // Save the result
                        finalBitmap.Save(outputPath);
                    }
                }
            }
        }
        // TODO, within the paragraph, not at the end
        public static string EnsureSpaceAfterPeriod(string input)
        {
            // Define a regular expression pattern to match a period followed by a capital letter
            string pattern = @"(\.)([A-Z])";

            // Replace the pattern with a period, a space, and the capital letter
            string result = Regex.Replace(input, pattern, "$1 $2");

            return result;
        }



        public static void AppendTextToWordDocument(string filePath, string content)
        {
            try
            {
                // Open the document in edit mode
                using (WordprocessingDocument wordDocument = WordprocessingDocument.Open(filePath, true))
                {
                    MainDocumentPart mainPart = wordDocument.MainDocumentPart;

                    if (mainPart == null)
                    {
                        mainPart = wordDocument.AddMainDocumentPart();
                        mainPart.Document = new Document(new Body());
                    }

                    // Create a new paragraph with the content indented
                    Paragraph paragraph = new Paragraph(new Run(new Text(content)));
                    ParagraphProperties paragraphProperties = new ParagraphProperties();
                    Indentation indentation = new Indentation() { Left = "960" }; // 960 twentieths of a point (48 points = 4 spaces assuming 12 point font size)

                    paragraphProperties.Append(indentation);
                    paragraph.PrependChild(paragraphProperties);

                    // Append the new paragraph to the body of the document
                    mainPart.Document.Body.AppendChild(paragraph);

                    // Save changes to the Word document
                    mainPart.Document.Save();
                }

                Console.WriteLine("Text appended to the Word document successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        public static string CreateWordDocument(string filename)
        {
            // Create a Wordprocessing document. 
            using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(filename, WordprocessingDocumentType.Document))
            {
                // Add a new main document part. 
                MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();

                // Create the document structure and add some text.
                mainPart.Document = new Document();
                Body body = mainPart.Document.AppendChild(new Body());
                DocumentFormat.OpenXml.Wordprocessing.Paragraph para = body.AppendChild(new Paragraph());
                Run run = para.AppendChild(new Run());

                // Assuming you might want to add text initially
                run.AppendChild(new Text("Hello, this is a new document created on " + System.DateTime.Now.ToString()));

                // Save changes to the document.
                mainPart.Document.Save();
            }

            Console.WriteLine("Word document created successfully at: " + filename);
            return filename;
        }
        public static void AddImageToWordDocument(string docPath, string imagePath, bool _original = false)
        {
            int maxRetries = 5; // Number of retry attempts
            int delay = 1000; // Delay between retries in milliseconds

            for (int attempt = 0; attempt < maxRetries; attempt++)
            {
                try
                {
                    using (WordprocessingDocument wordDocument = WordprocessingDocument.Open(docPath, true))
                    {
                        MainDocumentPart mainPart = wordDocument.MainDocumentPart;

                        ImagePart imagePart = mainPart.AddImagePart(ImagePartType.Jpeg);
                        using (FileStream stream = new FileStream(imagePath, FileMode.Open))
                        {
                            imagePart.FeedData(stream);
                        }

                        AddImageToBody1024CenteredBorder(wordDocument, mainPart.GetIdOfPart(imagePart));
                    }
                    break; // Break the loop if successful
                }
                catch (IOException ex) when (attempt < maxRetries - 1)
                {
                    // Log the exception or handle it as needed
                    Console.WriteLine($"Attempt {attempt + 1} failed. Retrying in {delay / 1000} seconds...");
                    Thread.Sleep(delay);
                }
            }
        }


        private static void AddImageToBody1024CenteredBorder(WordprocessingDocument wordDoc, string relationshipId)
        {
            // Calculate size in EMUs (English Metric Units)
            long imageSizeInEmus = 512 * 9525;
            int borderSizeInEmus = 5 * 12700; // Border width in EMUs (12700 EMUs is approximately 1 point)

            // Define the color and thickness of the border
            string borderColorHex = "5A3E1B"; // Dark brown color in hex

            // Create the Drawing element
            Drawing imageElement = new Drawing(
                new Inline(
                    new Extent() { Cx = imageSizeInEmus + borderSizeInEmus * 2, Cy = imageSizeInEmus + borderSizeInEmus * 2 }, // Increase extent to accommodate border
                    new DocProperties() { Id = UInt32Value.FromUInt32(1U), Name = "Picture 1" },
                    new Graphic(
                        new GraphicData(
                            new DocumentFormat.OpenXml.Drawing.Pictures.Picture(
                                new DocumentFormat.OpenXml.Drawing.Pictures.NonVisualPictureProperties(
                                    new DocumentFormat.OpenXml.Drawing.Pictures.NonVisualDrawingProperties()
                                    {
                                        Id = UInt32Value.FromUInt32(0U),
                                        Name = "Image.jpg"
                                    },
                                    new DocumentFormat.OpenXml.Drawing.Pictures.NonVisualPictureDrawingProperties()
                                ),
                                new DocumentFormat.OpenXml.Drawing.Pictures.BlipFill(
                                    new Blip() { Embed = relationshipId },
                                    new Stretch(new FillRectangle())
                                ),
                                new DocumentFormat.OpenXml.Drawing.Pictures.ShapeProperties(
                                    new Transform2D(
                                        new Offset() { X = borderSizeInEmus, Y = borderSizeInEmus }, // Offset the image to leave space for the border
                                        new Extents() { Cx = imageSizeInEmus, Cy = imageSizeInEmus } // Reduce the image size to fit within the border
                                    ),
                                    new PresetGeometry(new AdjustValueList()) { Preset = ShapeTypeValues.Rectangle },
                                    new DocumentFormat.OpenXml.Drawing.Outline(
                                        new DocumentFormat.OpenXml.Drawing.SolidFill(
                                            new DocumentFormat.OpenXml.Drawing.RgbColorModelHex() { Val = borderColorHex }
                                        )
                                    )
                                    {
                                        Width = borderSizeInEmus,
                                        CapType = DocumentFormat.OpenXml.Drawing.LineCapValues.Round
                                    }
                                )
                            )
                        )
                        { Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture" }
                    )
                )
                { DistanceFromTop = 0U, DistanceFromBottom = 0U, DistanceFromLeft = 0U, DistanceFromRight = 0U }
            );

            // Create the paragraph with center alignment
            Paragraph paragraph = new Paragraph(
                new ParagraphProperties(
                    new Justification() { Val = JustificationValues.Center } // Center align the paragraph
                ),
                new Run(imageElement)
            );

            // Append the Drawing element to the document body
            wordDoc.MainDocumentPart.Document.Body.AppendChild(paragraph);
        }



        public static void AddImageToWordDocumentOriginal(string wordDocumentPath, string imagePath, string sQuote,
                int imWidth = 512, int imHeight = 0, string imAlign = "center")
        {
            int maxRetries = 5; // Number of retry attempts
            int delay = 1000; // Delay between retries in milliseconds

            for (int attempt = 0; attempt < maxRetries; attempt++)
            {
                try
                {
                    using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(wordDocumentPath, true))
                    {
                        AddImageToBody1024CenteredOriginal(wordDoc, imagePath, sQuote, imWidth, imHeight, imAlign);
                    }
                    break; // Break the loop if successful
                }
                catch (IOException ex) when (attempt < maxRetries - 1)
                {
                    // Log the exception or handle it as needed
                    Console.WriteLine($"Attempt {attempt + 1} failed. Retrying in {delay / 1000} seconds...");
                    Thread.Sleep(delay);
                }
            }
        }

        public static void AddImageToWordDocumentOriginalWrap(string wordDocumentPath, string imagePath, string sQuote,
            int imWidth = 512, int imHeight = 0, string imAlign = "center")
        {
            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(wordDocumentPath, true))
            {
                AddImageToBodyWithWrapping(wordDoc, imagePath, sQuote, imWidth, imHeight, imAlign);
            }
        }
        public static void AddImageToWordDocumentOverlay(string docPath, string baseImagePath, string overlayImagePath, bool _original = false)
        {
            using (WordprocessingDocument wordDocument = WordprocessingDocument.Open(docPath, true))
            {
                MainDocumentPart mainPart = wordDocument.MainDocumentPart;

                // Add base image
                ImagePart baseImagePart = mainPart.AddImagePart(ImagePartType.Jpeg);
                using (System.IO.FileStream stream = new System.IO.FileStream(baseImagePath, System.IO.FileMode.Open))
                {
                    baseImagePart.FeedData(stream);
                }

                string baseImageRelId = mainPart.GetIdOfPart(baseImagePart);

                // Add overlay image
                ImagePart overlayImagePart = mainPart.AddImagePart(ImagePartType.Jpeg);
                using (System.IO.FileStream stream = new System.IO.FileStream(overlayImagePath, System.IO.FileMode.Open))
                {
                    overlayImagePart.FeedData(stream);
                }

                string overlayImageRelId = mainPart.GetIdOfPart(overlayImagePart);

                AddImagesToBodyWithOverlay(wordDocument, baseImageRelId, overlayImageRelId);
            }
        }

        private static void AddImagesToBodyWithOverlay(WordprocessingDocument wordDocument, string baseImageRelId, string overlayImageRelId)
        {
            long baseImageWidthEmus = 6000000; // Example width in EMUs for base image
            long baseImageHeightEmus = 4000000; // Example height in EMUs for base image

            long overlayImageWidthEmus = 2000000; // Example width in EMUs for overlay image
            long overlayImageHeightEmus = 2000000; // Example height in EMUs for overlay image

            // Create base image Drawing element
            var baseImageElement = new Drawing(
                new Anchor(
                    new SimplePosition() { X = 0L, Y = 0L },
                    new HorizontalPosition()
                    {
                        RelativeFrom = HorizontalRelativePositionValues.Margin,
                        PositionOffset = new PositionOffset("0")
                    },
                    new VerticalPosition()
                    {
                        RelativeFrom = VerticalRelativePositionValues.Paragraph,
                        PositionOffset = new PositionOffset("0")
                    },
                    new Extent() { Cx = baseImageWidthEmus, Cy = baseImageHeightEmus },
                    new EffectExtent() { LeftEdge = 0L, TopEdge = 0L, RightEdge = 0L, BottomEdge = 0L },
                    new WrapNone(),
                    new DocProperties() { Id = (UInt32Value)1U, Name = "Base Image" },
                    new NonVisualGraphicFrameDrawingProperties(new DocumentFormat.OpenXml.Drawing.GraphicFrameLocks() { NoChangeAspect = true }),
                    new DocumentFormat.OpenXml.Drawing.Graphic(
                        new DocumentFormat.OpenXml.Drawing.GraphicData(
                            new DocumentFormat.OpenXml.Drawing.Pictures.Picture(
                                new DocumentFormat.OpenXml.Drawing.Pictures.NonVisualPictureProperties(
                                    new DocumentFormat.OpenXml.Drawing.Pictures.NonVisualDrawingProperties() { Id = (UInt32Value)0U, Name = "Base Image.jpg" },
                                    new DocumentFormat.OpenXml.Drawing.Pictures.NonVisualPictureDrawingProperties()
                                ),
                                new DocumentFormat.OpenXml.Drawing.Pictures.BlipFill(
                                    new DocumentFormat.OpenXml.Drawing.Blip() { Embed = baseImageRelId },
                                    new DocumentFormat.OpenXml.Drawing.Stretch(new DocumentFormat.OpenXml.Drawing.FillRectangle())
                                ),
                                new DocumentFormat.OpenXml.Drawing.Pictures.ShapeProperties(
                                    new DocumentFormat.OpenXml.Drawing.Transform2D(
                                        new DocumentFormat.OpenXml.Drawing.Offset() { X = 0L, Y = 0L },
                                        new DocumentFormat.OpenXml.Drawing.Extents() { Cx = baseImageWidthEmus, Cy = baseImageHeightEmus }
                                    ),
                                    new DocumentFormat.OpenXml.Drawing.PresetGeometry(new DocumentFormat.OpenXml.Drawing.AdjustValueList()) { Preset = DocumentFormat.OpenXml.Drawing.ShapeTypeValues.Rectangle }
                                )
                            )
                        )
                        { Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture" }
                    )
                )
                {
                    DistanceFromTop = 0U,
                    DistanceFromBottom = 0U,
                    DistanceFromLeft = 0U,
                    DistanceFromRight = 0U,
                    SimplePos = false,
                    RelativeHeight = (UInt32Value)251658240U,
                    BehindDoc = false,
                    Locked = false,
                    LayoutInCell = true,
                    AllowOverlap = true
                }
            );

            // Create overlay image Drawing element
            var overlayImageElement = new Drawing(
                new Anchor(
                    new SimplePosition() { X = 0L, Y = 0L },
                    new HorizontalPosition()
                    {
                        RelativeFrom = HorizontalRelativePositionValues.Margin,
                        PositionOffset = new PositionOffset("2000000") // Position the overlay image
                    },
                    new VerticalPosition()
                    {
                        RelativeFrom = VerticalRelativePositionValues.Paragraph,
                        PositionOffset = new PositionOffset("2000000") // Position the overlay image
                    },
                    new Extent() { Cx = overlayImageWidthEmus, Cy = overlayImageHeightEmus },
                    new EffectExtent() { LeftEdge = 0L, TopEdge = 0L, RightEdge = 0L, BottomEdge = 0L },
                    new WrapNone(),
                    new DocProperties() { Id = (UInt32Value)2U, Name = "Overlay Image" },
                    new NonVisualGraphicFrameDrawingProperties(new DocumentFormat.OpenXml.Drawing.GraphicFrameLocks() { NoChangeAspect = true }),
                    new DocumentFormat.OpenXml.Drawing.Graphic(
                        new DocumentFormat.OpenXml.Drawing.GraphicData(
                            new DocumentFormat.OpenXml.Drawing.Pictures.Picture(
                                new DocumentFormat.OpenXml.Drawing.Pictures.NonVisualPictureProperties(
                                    new DocumentFormat.OpenXml.Drawing.Pictures.NonVisualDrawingProperties() { Id = (UInt32Value)1U, Name = "Overlay Image.jpg" },
                                    new DocumentFormat.OpenXml.Drawing.Pictures.NonVisualPictureDrawingProperties()
                                ),
                                new DocumentFormat.OpenXml.Drawing.Pictures.BlipFill(
                                    new DocumentFormat.OpenXml.Drawing.Blip() { Embed = overlayImageRelId },
                                    new DocumentFormat.OpenXml.Drawing.Stretch(new DocumentFormat.OpenXml.Drawing.FillRectangle())
                                ),
                                new DocumentFormat.OpenXml.Drawing.Pictures.ShapeProperties(
                                    new DocumentFormat.OpenXml.Drawing.Transform2D(
                                        new DocumentFormat.OpenXml.Drawing.Offset() { X = 0L, Y = 0L },
                                        new DocumentFormat.OpenXml.Drawing.Extents() { Cx = overlayImageWidthEmus, Cy = overlayImageHeightEmus }
                                    ),
                                    new DocumentFormat.OpenXml.Drawing.PresetGeometry(new DocumentFormat.OpenXml.Drawing.AdjustValueList()) { Preset = DocumentFormat.OpenXml.Drawing.ShapeTypeValues.Rectangle }
                                )
                            )
                        )
                        { Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture" }
                    )
                )
                {
                    DistanceFromTop = 0U,
                    DistanceFromBottom = 0U,
                    DistanceFromLeft = 0U,
                    DistanceFromRight = 0U,
                    SimplePos = false,
                    RelativeHeight = (UInt32Value)251658240U,
                    BehindDoc = false,
                    Locked = false,
                    LayoutInCell = true,
                    AllowOverlap = true
                }
            );

            // Append both Drawing elements to the document body
            var docBody = wordDocument.MainDocumentPart.Document.Body;
            docBody.AppendChild(new Paragraph(new Run(baseImageElement)));
            docBody.AppendChild(new Paragraph(new Run(overlayImageElement)));
        }
        public static bool HasMoreThanSixParagraphs(string input)
        {
            // Split the string by two newline characters which indicate paragraphs
            string[] paragraphs = input.Split(new string[] { "\n\n" }, StringSplitOptions.RemoveEmptyEntries);

            // Check if the number of paragraphs is greater than 6
            return paragraphs.Length > 6;
        }
        private static void AddImageToBody1024CenteredOriginal(WordprocessingDocument wordDoc, string imagePath, string sQuote
            , int imWidth = 512, int imHeight = 0, string imAlign = "center")
        {
            // Load the image to get its dimensions
            int imageWidth, imageHeight;
            using (System.Drawing.Image image = System.Drawing.Image.FromFile(imagePath))
            {
                //imageWidth = image.Width;
                imageWidth = imWidth;
                if (imHeight.Equals(0))
                    imageHeight = image.Height;
                else
                    imageHeight = imHeight;
            } // Ensure the image file is closed after getting dimensions

            // Calculate size in EMUs (English Metric Units)
            long widthInEmus = imageWidth * 9525;
            long heightInEmus = imageHeight * 9525;

            // Create a new image part in the document
            MainDocumentPart mainPart = wordDoc.MainDocumentPart;
            ImagePart imagePart = mainPart.AddImagePart(ImagePartType.Jpeg);

            // Copy the image into the new image part
            using (FileStream stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                imagePart.FeedData(stream);
            } // Ensure the image file stream is properly disposed

            // Get the relationship ID of the new image part
            string relationshipId = mainPart.GetIdOfPart(imagePart);

            // Create the Drawing element
            Drawing imageElement = new Drawing(
                new Inline(
                    new Extent() { Cx = widthInEmus, Cy = heightInEmus },
                    new DocProperties() { Id = UInt32Value.FromUInt32(1U), Name = "Picture 1" },
                    new Graphic(
                        new GraphicData(
                            new DocumentFormat.OpenXml.Drawing.Pictures.Picture(
                                new DocumentFormat.OpenXml.Drawing.Pictures.NonVisualPictureProperties(
                                    new DocumentFormat.OpenXml.Drawing.Pictures.NonVisualDrawingProperties()
                                    {
                                        Id = UInt32Value.FromUInt32(0U),
                                        Name = "Image.jpg"
                                    },
                                    new DocumentFormat.OpenXml.Drawing.Pictures.NonVisualPictureDrawingProperties()
                                ),
                                new DocumentFormat.OpenXml.Drawing.Pictures.BlipFill(
                                    new Blip() { Embed = relationshipId },
                                    new Stretch(new FillRectangle())
                                ),
                                new DocumentFormat.OpenXml.Drawing.Pictures.ShapeProperties(
                                    new Transform2D(
                                        new Offset() { X = 0L, Y = 0L },
                                        new Extents() { Cx = widthInEmus, Cy = heightInEmus }
                                    ),
                                    new PresetGeometry(new AdjustValueList()) { Preset = ShapeTypeValues.Rectangle }
                                )
                            )
                        )
                        { Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture" }
                    )
                )
                { DistanceFromTop = 0U, DistanceFromBottom = 0U, DistanceFromLeft = 0U, DistanceFromRight = 0U }
            );
            Paragraph paragraph = null;

            if (imAlign.Contains("center")) // Center aligned
            {
                paragraph = new Paragraph(
                    new ParagraphProperties(
                        new Justification() { Val = JustificationValues.Center } // Center align the paragraph
                    ),
                    new Run(imageElement)
                );
            }
            else // Left aligned
            {
                paragraph = new Paragraph(
                   new ParagraphProperties(
                       new Justification() { Val = JustificationValues.Left } // Center align the paragraph
                   ),
                   new Run(imageElement)
               );
            }

            // Append the Drawing element to the document body
            wordDoc.MainDocumentPart.Document.Body.AppendChild(paragraph);
        }
        public static void AddImageToWordDocumentFramed(string docPath, string imagePath)
        {
            using (WordprocessingDocument wordDocument = WordprocessingDocument.Open(docPath, true))
            {
                MainDocumentPart mainPart = wordDocument.MainDocumentPart;

                ImagePart imagePart = mainPart.AddImagePart(ImagePartType.Jpeg);
                using (FileStream stream = new FileStream(imagePath, FileMode.Open))
                {
                    imagePart.FeedData(stream);
                }

                AddImageToBody(wordDocument, mainPart.GetIdOfPart(imagePart));
            }
        }

        private static void ApplyFrameAndShadow(Drawing drawing)
        {
            // Access the ShapeProperties of the Picture within the Drawing
            var graphic = drawing.Inline.Graphic;
            var graphicData = graphic.GraphicData;
            var picture = graphicData.GetFirstChild<DocumentFormat.OpenXml.Drawing.Pictures.Picture>();
            var shapeProperties = picture.ShapeProperties;

            // Add a simple frame
            shapeProperties.Append(new Outline(
                new SolidFill(
                    new SchemeColor() { Val = SchemeColorValues.Text1 }
                ),
                new PresetDash() { Val = PresetLineDashValues.Solid },
                new Round()
            )
            {
                Width = 12700 // Frame width in EMU (1/12700 of an inch)
            });

            // Add a simple shadow effect
            shapeProperties.Append(new EffectList(
                new OuterShadow()
                {
                    BlurRadius = 40000L, // Shadow blur radius in EMU
                    Distance = 20000L, // Shadow distance from the shape in EMU
                    Direction = 5400000, // Shadow direction in degrees * 60000
                    Alignment = RectangleAlignmentValues.Center,
                    RotateWithShape = false,
                    RgbColorModelHex = new RgbColorModelHex() { Val = "000000" } // Shadow color (black)
                }
            ));
        }

        private static void AddImageToBodyWithFrameAndShadow(WordprocessingDocument wordDoc, string relationshipId)
        {
            // Define the page size in EMUs
            const long pageWidth = 11906000L; // 8.27 inches in EMUs
            const long pageHeight = 16838000L; // 11.69 inches in EMUs

            // Define the element for the image
            var element =
                new Drawing(
                    new Inline(
                        new Extent() { Cx = pageWidth, Cy = pageHeight }, // Set size to page width and height
                        new EffectExtent() { LeftEdge = 19050L, TopEdge = 0L, RightEdge = 19050L, BottomEdge = 19050L },
                        new DocProperties() { Id = (UInt32Value)1U, Name = "Picture 1" },
                        new NonVisualGraphicFrameDrawingProperties(new GraphicFrameLocks() { NoChangeAspect = true }),
                        new Graphic(
                            new GraphicData(
                                new DocumentFormat.OpenXml.Drawing.Pictures.Picture(
                                    new DocumentFormat.OpenXml.Drawing.Pictures.NonVisualPictureProperties(
                                        new DocumentFormat.OpenXml.Drawing.Pictures.NonVisualDrawingProperties() { Id = (UInt32Value)0U, Name = "New Bitmap Image.jpg" },
                                        new DocumentFormat.OpenXml.Drawing.Pictures.NonVisualPictureDrawingProperties()),
                                    new DocumentFormat.OpenXml.Drawing.Pictures.BlipFill(
                                        new DocumentFormat.OpenXml.Drawing.Blip(
                                            new DocumentFormat.OpenXml.Drawing.BlipExtensionList(
                                                new DocumentFormat.OpenXml.Drawing.BlipExtension()
                                                {
                                                    Uri =
                                                      "{28A0092B-C50C-407E-A947-70E740481C1C}"
                                                })
                                        )
                                        {
                                            Embed = relationshipId,
                                            CompressionState =
                                            DocumentFormat.OpenXml.Drawing.BlipCompressionValues.Print
                                        },
                                        new DocumentFormat.OpenXml.Drawing.Stretch(
                                            new DocumentFormat.OpenXml.Drawing.FillRectangle())),
                                    new DocumentFormat.OpenXml.Drawing.Pictures.ShapeProperties(
                                        new DocumentFormat.OpenXml.Drawing.Transform2D(
                                            new DocumentFormat.OpenXml.Drawing.Offset() { X = 0L, Y = 0L },
                                            new DocumentFormat.OpenXml.Drawing.Extents() { Cx = pageWidth, Cy = pageHeight }), // Set size to page width and height
                                        new DocumentFormat.OpenXml.Drawing.PresetGeometry(
                                            new DocumentFormat.OpenXml.Drawing.AdjustValueList()
                                        )
                                        { Preset = DocumentFormat.OpenXml.Drawing.ShapeTypeValues.Rectangle }))
                            )
                            { Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture" })
                    )
                    {
                        DistanceFromTop = (UInt32Value)0U,
                        DistanceFromBottom = (UInt32Value)0U,
                        DistanceFromLeft = (UInt32Value)0U,
                        DistanceFromRight = (UInt32Value)0U,
                        EditId = "50D07946"
                    });

            // Apply the frame and shadow
            ApplyFrameAndShadow(element);

            // Add the image to the document body
            wordDoc.MainDocumentPart.Document.Body.AppendChild(new Paragraph(new Run(element)));
        }


        private static void AddImageToBody(WordprocessingDocument wordDoc, string relationshipId)
        {
            // Create the Drawing element
            Drawing imageElement = new Drawing(
                new Inline(
                    new Extent() { Cx = 990000L, Cy = 792000L },
                    new DocProperties() { Id = UInt32Value.FromUInt32(1U), Name = "Picture 1" },
                    new Graphic(
                        new GraphicData(
                            new DocumentFormat.OpenXml.Drawing.Pictures.Picture(
                                new DocumentFormat.OpenXml.Drawing.Pictures.NonVisualPictureProperties(
                                    new DocumentFormat.OpenXml.Drawing.Pictures.NonVisualDrawingProperties()
                                    {
                                        Id = UInt32Value.FromUInt32(0U),
                                        Name = "Image.jpg"
                                    },
                                    new DocumentFormat.OpenXml.Drawing.Pictures.NonVisualPictureDrawingProperties()
                                ),
                                new DocumentFormat.OpenXml.Drawing.Pictures.BlipFill(
                                    new Blip() { Embed = relationshipId },
                                    new Stretch(new FillRectangle())
                                ),
                                new DocumentFormat.OpenXml.Drawing.Pictures.ShapeProperties(
                                    new Transform2D(
                                        new Offset() { X = 0L, Y = 0L },
                                        new Extents() { Cx = 990000L, Cy = 792000L }
                                    ),
                                    new PresetGeometry(new AdjustValueList()) { Preset = ShapeTypeValues.Rectangle }
                                )
                            )
                        )
                        { Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture" }
                    )
                )
                { DistanceFromTop = 0U, DistanceFromBottom = 0U, DistanceFromLeft = 0U, DistanceFromRight = 0U }
            );

            // Append the Drawing element to the document body
            Paragraph paragraph = new Paragraph(new Run(imageElement));
            wordDoc.MainDocumentPart.Document.Body.AppendChild(paragraph);
        }
        private static void AddImageToBody1024(WordprocessingDocument wordDoc, string relationshipId)
        {
            // Calculate size in EMUs (English Metric Units)
            long sizeInEmus = 512 * 9525;

            // Create the Drawing element
            Drawing imageElement = new Drawing(
                new Inline(
                    new Extent() { Cx = sizeInEmus, Cy = sizeInEmus }, // Set both Cx and Cy to sizeInEmus for a square image
                    new DocProperties() { Id = UInt32Value.FromUInt32(1U), Name = "Picture 1" },
                    new Graphic(
                        new GraphicData(
                            new DocumentFormat.OpenXml.Drawing.Pictures.Picture(
                                new DocumentFormat.OpenXml.Drawing.Pictures.NonVisualPictureProperties(
                                    new DocumentFormat.OpenXml.Drawing.Pictures.NonVisualDrawingProperties()
                                    {
                                        Id = UInt32Value.FromUInt32(0U),
                                        Name = "Image.jpg"
                                    },
                                    new DocumentFormat.OpenXml.Drawing.Pictures.NonVisualPictureDrawingProperties()
                                ),
                                new DocumentFormat.OpenXml.Drawing.Pictures.BlipFill(
                                    new Blip() { Embed = relationshipId },
                                    new Stretch(new FillRectangle())
                                ),
                                new DocumentFormat.OpenXml.Drawing.Pictures.ShapeProperties(
                                    new Transform2D(
                                        new Offset() { X = 0L, Y = 0L },
                                        new Extents() { Cx = sizeInEmus, Cy = sizeInEmus }
                                    ),
                                    new PresetGeometry(new AdjustValueList()) { Preset = ShapeTypeValues.Rectangle }
                                )
                            )
                        )
                        { Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture" }
                    )
                )
                { DistanceFromTop = 0U, DistanceFromBottom = 0U, DistanceFromLeft = 0U, DistanceFromRight = 0U }
            );

            // Append the Drawing element to the document body
            Paragraph paragraph = new Paragraph(new Run(imageElement));
            wordDoc.MainDocumentPart.Document.Body.AppendChild(paragraph);
        }
        private static void AddImageToBody1024Centered(WordprocessingDocument wordDoc, string relationshipId)
        {
            // Calculate size in EMUs (English Metric Units)
            long sizeInEmus = 512 * 9525;

            // Create the Drawing element
            Drawing imageElement = new Drawing(
                new Inline(
                    new Extent() { Cx = sizeInEmus, Cy = sizeInEmus }, // Set both Cx and Cy to sizeInEmus for a square image
                    new DocProperties() { Id = UInt32Value.FromUInt32(1U), Name = "Picture 1" },
                    new Graphic(
                        new GraphicData(
                            new DocumentFormat.OpenXml.Drawing.Pictures.Picture(
                                new DocumentFormat.OpenXml.Drawing.Pictures.NonVisualPictureProperties(
                                    new DocumentFormat.OpenXml.Drawing.Pictures.NonVisualDrawingProperties()
                                    {
                                        Id = UInt32Value.FromUInt32(0U),
                                        Name = "Image.jpg"
                                    },
                                    new DocumentFormat.OpenXml.Drawing.Pictures.NonVisualPictureDrawingProperties()
                                ),
                                new DocumentFormat.OpenXml.Drawing.Pictures.BlipFill(
                                    new Blip() { Embed = relationshipId },
                                    new Stretch(new FillRectangle())
                                ),
                                new DocumentFormat.OpenXml.Drawing.Pictures.ShapeProperties(
                                    new Transform2D(
                                        new Offset() { X = 0L, Y = 0L },
                                        new Extents() { Cx = sizeInEmus, Cy = sizeInEmus }
                                    ),
                                    new PresetGeometry(new AdjustValueList()) { Preset = ShapeTypeValues.Rectangle }
                                )
                            )
                        )
                        { Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture" }
                    )
                )
                { DistanceFromTop = 0U, DistanceFromBottom = 0U, DistanceFromLeft = 0U, DistanceFromRight = 0U }
            );

            // Create the paragraph with center alignment
            Paragraph paragraph = new Paragraph(
                new ParagraphProperties(
                    new Justification() { Val = JustificationValues.Center } // Center align the paragraph
                ),
                new Run(imageElement)
            );

            // Append the Drawing element to the document body
            wordDoc.MainDocumentPart.Document.Body.AppendChild(paragraph);
        }

        #endregion

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets HTTP return from a pi REST link. </summary>
        ///
        /// <remarks>   Shadow, 4/2/2024. </remarks>
        ///
        /// <param name="theLinkAPI">   the link a pi. </param>
        ///
        /// <returns>   The HTTP return from a pi REST link. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string GetHttpReturnFromAPIRestLink(string theLinkAPI)
        {
            // This method has some troubles getting the string from the REST API in good format.
            try
            {
                var responseSimple = new WebClient().DownloadString(theLinkAPI);

                HttpWebRequest request =
                     (HttpWebRequest)WebRequest.Create(theLinkAPI);

                WebResponse response = request.GetResponse();
                string responseText = "";
                var encoding = ASCIIEncoding.ASCII;
                using (var reader = new System.IO.StreamReader(response.GetResponseStream(), encoding))
                {
                    responseText = reader.ReadToEnd();
                }
                return responseText;

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Adds a line feeds to file. </summary>
        ///
        /// <remarks>   Shadow, 4/2/2024. </remarks>
        ///
        /// <param name="filePath"> Full pathname of the file. </param>
        ///
        /// <returns>   A string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string AddLineFeedsToFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                string inputText = File.ReadAllText(filePath);

                string[] liness = inputText.Split(new string[] { "Chapter:", "Paragraph:" }, StringSplitOptions.RemoveEmptyEntries);


                string[] chaptersAndParagraphs = inputText.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                string result = "";



                for (int i = 0; i < chaptersAndParagraphs.Length; i++)
                {
                    string chapterOrParagraph = chaptersAndParagraphs[i].Trim();
                    string[] lines = chapterOrParagraph.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

                    for (int j = 0; j < lines.Length; j++)
                    {
                        string line = lines[j].Trim();

                        if (!string.IsNullOrEmpty(line))
                        {
                            if (Regex.IsMatch(line, @"^\d+:X\s.*$"))
                            {
                                result += "Chapter: " + line.Replace(":X", "").Trim() + " **<br>";
                            }
                            else if (Regex.IsMatch(line, @"^\d+:\d+\s.*$"))
                            {
                                result += "Paragraph: " + line.Replace(":", "") + " **<br>";
                            }
                            else
                            {
                                result += line + "<br>";
                            }
                        }
                    }
                }
                string appPath = AppDomain.CurrentDomain.BaseDirectory;
                string bFile = "BookWork.html";
                if (File.Exists(filePath))
                {
                    if (!string.IsNullOrEmpty(result))
                    {
                        File.WriteAllText(bFile, result);

                    }
                    else
                    {
                        Console.WriteLine("No content to write.");
                    }
                }
                else
                {
                    Console.WriteLine("Input file not found: " + filePath);
                }
                return "Success";

            }
            else
            {
                Console.WriteLine("File not found: " + filePath);
            }
            return "";
        }

        public static async Task ReduceImageSize(string url, string resizeImage)
        {
            string imageUrl = url; // Replace with the URL of the image from DALL-E
            string outputPath = resizeImage; // Path to save the resized image
            int newWidth = 512; // Desired width
            int newHeight = 512; // Desired height

            using (HttpClient client = new HttpClient())
            {
                var imageBytes = await client.GetByteArrayAsync(imageUrl);
                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    using (System.Drawing.Image originalImage = System.Drawing.Image.FromStream(ms))
                    {
                        System.Drawing.Image resizedImage = ResizeImage(originalImage, newWidth, newHeight);
                        resizedImage.Save(outputPath, ImageFormat.Jpeg);
                        Console.WriteLine($"Resized image saved to {outputPath}");
                    }
                }
            }
        }
        public static void ReduceImageSizeFromDisk(string inputPath, string outputPath)
        {
            int newWidth = 512; // Desired width
            int newHeight = 512; // Desired height

            using (FileStream fs = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
            {
                using (System.Drawing.Image originalImage = System.Drawing.Image.FromStream(fs))
                {
                    System.Drawing.Image resizedImage = ResizeImage(originalImage, newWidth, newHeight);
                    resizedImage.Save(outputPath, ImageFormat.Jpeg);
                    Console.WriteLine($"Resized image saved to {outputPath}");
                }
            }
        }
        public static void LowerImageFileSize(string inputPath, string outputPath, long quality)
        {
            try
            {
                using (FileStream fs = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
                {
                    using (System.Drawing.Image originalImage = System.Drawing.Image.FromStream(fs))
                    {
                        // Set up the quality parameter for JPEG compression
                        ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);
                        System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
                        EncoderParameters myEncoderParameters = new EncoderParameters(1);
                        EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, quality);
                        myEncoderParameters.Param[0] = myEncoderParameter;

                        // Save the image with the new quality level
                        originalImage.Save(outputPath, jpgEncoder, myEncoderParameters);
                        Console.WriteLine($"Image saved to {outputPath} with quality level {quality}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }
        public static System.Drawing.Image ResizeImage(System.Drawing.Image image, int width, int height)
        {
            var destRect = new System.Drawing.Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(System.Drawing.Drawing2D.WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Splits on line break. </summary>
        ///
        /// <remarks>   Shadow, 4/2/2024. </remarks>
        ///
        /// <param name="filePathWork"> The file path work. </param>
        ///
        /// <returns>   A List&lt;string&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static List<string> SplitOnBR(string filePathWork)
        {

            List<string> lines = ReadAndSplitTextFromFileBR(filePathWork, "<br>");

            return lines;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Says. </summary>
        ///
        /// <remarks>   Shadow, 4/2/2024. </remarks>
        ///
        /// <param name="textToSpeech"> The text to speech. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void Say(string textToSpeech)
        {
            var client = GlobalMethods.IniGoogleSound();
            string textToSynthesize = textToSpeech;
            GlobalMethods.DoSpeak(client, textToSynthesize);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes the google sound. </summary>
        ///
        /// <remarks>   Shadow, 4/2/2024. </remarks>
        ///
        /// <returns>   A TextToSpeechClient. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static TextToSpeechClient IniGoogleSound()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string credentialsPath = basePath + @"\json\wavtotext-380220-c4609e859a87.json";

            // Load your service account credentials
            GoogleCredential credential = GoogleCredential.FromFile(credentialsPath);

            // Create a client to interact with the Text-to-Speech API
            TextToSpeechClientBuilder builder = new TextToSpeechClientBuilder();
            builder.CredentialsPath = credentialsPath;
            TextToSpeechClient client = builder.Build();
            return client;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Reads and split text from file line break. </summary>
        ///
        /// <remarks>   Shadow, 4/2/2024. </remarks>
        ///
        /// <param name="filePath">     Full pathname of the file. </param>
        /// <param name="delimiter">    The delimiter. </param>
        ///
        /// <returns>   The and split text from file line break. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static List<string> ReadAndSplitTextFromFileBR(string filePath, string delimiter)
        {
            List<string> lines = new List<string>();

            try
            {
                if (File.Exists(filePath))
                {
                    string fileContent = File.ReadAllText(filePath);
                    string[] splitLines = fileContent.Split(new string[] { delimiter }, StringSplitOptions.None);
                    lines.AddRange(splitLines);
                }
                else
                {
                    Console.WriteLine("File not found: " + filePath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return lines;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Reads and split text from file. </summary>
        ///
        /// <remarks>   Shadow, 4/2/2024. </remarks>
        ///
        /// <param name="filePath"> Full pathname of the file. </param>
        ///
        /// <returns>   The and split text from file. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static List<string> ReadAndSplitTextFromFile(string filePath)
        {
            List<string> lines = new List<string>();

            // Specify the encoding (UTF-8, UTF-16, etc.) based on your file's encoding
            Encoding encoding = Encoding.Latin1;

            using (StreamReader reader = new StreamReader(filePath, encoding))
            {
                string line;
                bool inParagraph = false;
                string paragraph = "";

                while ((line = reader.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        if (inParagraph)
                        {
                            lines.Add(paragraph.Trim());

                            paragraph = "";
                            inParagraph = false;
                        }
                    }
                    else
                    {
                        paragraph += line + " ";
                        inParagraph = true;
                    }
                }

                // Add the last paragraph if it's not empty
                if (inParagraph)
                {

                    lines.Add(paragraph.Trim());
                }
            }

            return lines;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets chat gpt. </summary>
        ///
        /// <remarks>   Shadow, 4/2/2024. </remarks>
        ///
        /// <param name="textToAsk">    The text to ask. </param>
        ///
        /// <returns>   The chat gpt. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async static Task<string> GetChatGPT(string textToAsk)
        {
            try
            {
                var openAI = new OpenAI_API.OpenAIAPI(Secrets.openAIKey);


                CompletionRequest completion = new CompletionRequest();
                completion.Prompt = textToAsk;
                completion.MaxTokens = 4000;
                completion.Model = "text-davinci-003"; // Set the model ID for GPT-3.5-turbo
                var result = await openAI.Completions.CreateCompletionAsync(completion);
                string answer = "";
                if (result != null)
                {
                    foreach (var item in result.Completions)
                    {
                        answer += item.Text;
                    }
                    return answer;
                }
                else
                    return "No results from BlackBeltBible AI.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Deletes the first number described by input. </summary>
        ///
        /// <remarks>   Shadow, 4/2/2024. </remarks>
        ///
        /// <param name="input">    The input. </param>
        ///
        /// <returns>   A string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string DeleteFirstNumber(string input)
        {
            int index = input.IndexOfAny("0123456789".ToCharArray()); // Find the first digit's index

            if (index >= 0)
            {
                // Remove the character at the found index
                input = input.Remove(index, 1);
            }

            return input;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Adds a space between numbers and text. </summary>
        ///
        /// <remarks>   Shadow, 4/2/2024. </remarks>
        ///
        /// <param name="input">    The input. </param>
        ///
        /// <returns>   A string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string AddSpaceBetweenNumbersAndText(string input)
        {
            // Use a regular expression to match the pattern <number>:<number><text>
            string pattern = @"(\d+):(\d+)(\w+)";
            string replacement = @"$1:$2 $3"; // Add a space between the second number and the text
            string result = Regex.Replace(input, pattern, replacement);

            return result;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Deletes the first colon space described by input. </summary>
        ///
        /// <remarks>   Shadow, 4/2/2024. </remarks>
        ///
        /// <param name="input">    The input. </param>
        ///
        /// <returns>   A string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string DeleteFirstColonSpace(string input)
        {
            int index = input.IndexOf(": ");

            if (index >= 0)
            {
                input = input.Remove(index, 2); // Remove ": " (2 characters)
            }

            return input;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Deletes the first space described by input. </summary>
        ///
        /// <remarks>   Shadow, 4/2/2024. </remarks>
        ///
        /// <param name="input">    The input. </param>
        ///
        /// <returns>   A string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string DeleteFirstSpace(string input)
        {
            int index = input.IndexOf(" ");

            if (index >= 0)
            {
                input = input.Remove(index, 1); // Remove ": " (2 characters)
            }

            return input;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Word to number. </summary>
        ///
        /// <remarks>   Shadow, 4/2/2024. </remarks>
        ///
        /// <param name="word"> The word. </param>
        ///
        /// <returns>   An int. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static int WordToNumber(string word)
        {
            // You can implement a function to convert word numbers to numeric values here
            // For simplicity, let's assume a simple mapping for "One" to 1
            switch (word.ToLower())
            {
                case "one":
                    return 1;
                case "two":
                    return 2;
                case "three":
                    return 3;
                case "four":
                    return 4;
                case "five":
                    return 5;
                case "six":
                    return 6;
                case "seven":
                    return 7;
                case "eight":
                    return 8;
                case "nine":
                    return 9;
                case "ten":
                    return 10;
                default:
                    return Convert.ToInt16(word); // Return 0 if no match found
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Reads content of file. </summary>
        ///
        /// <remarks>   Shadow, 4/2/2024. </remarks>
        ///
        /// <param name="sName">    The name. </param>
        ///
        /// <returns>   The content of file. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string ReadContentOfFile(string sName)
        {
            string appPath = AppDomain.CurrentDomain.BaseDirectory;
            string sAmbiance; // The writing style.
            using (StreamReader reader = new StreamReader(appPath + sName))
            {
                sAmbiance = reader.ReadToEnd();
            }

            return sAmbiance;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Reads file from BLOB. </summary>
        ///
        /// <remarks>   Shadow, 4/2/2024. </remarks>
        ///
        /// <param name="fileName"> Filename of the file. </param>
        ///
        /// <returns>   The file from BLOB. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string readFileFromBlobFull(string fileName)
        {
            try
            {
                string _prefix = fileName;

                if (_prefix.Length > 0 && _prefix.Contains("Bible - ")) // First parts of the Bible
                {
                    // Initialise client in a different place if you like
                    string connS = Secrets.cloudStorageConnString;
                    CloudStorageAccount account = CloudStorageAccount.Parse(connS);
                    var blobClient = account.CreateCloudBlobClient();

                    var blobContainer = blobClient.GetContainerReference("aibookengine");
                    blobContainer.CreateIfNotExistsAsync();

                    CloudBlockBlob blob = blobContainer.GetBlockBlobReference($"{fileName}");
                    string contents = blob.DownloadTextAsync().Result;
                    return contents;
                }
                else if (_prefix.Length > 0 && _prefix.Contains("Bible -- ")) // Second parts of the Bible
                {
                    // Initialise client in a different place if you like
                    string connS = Secrets.cloudStorageConnString;
                    CloudStorageAccount account = CloudStorageAccount.Parse(connS);
                    var blobClient = account.CreateCloudBlobClient();

                    var blobContainer = blobClient.GetContainerReference("aibookengine2");
                    blobContainer.CreateIfNotExistsAsync();

                    CloudBlockBlob blob = blobContainer.GetBlockBlobReference($"{fileName}");
                    string contents = blob.DownloadTextAsync().Result;
                    return contents;
                }
                else // No Bible books
                {
                    // Initialise client in a different place if you like
                    string connS = Secrets.cloudStorageConnString;
                    CloudStorageAccount account = CloudStorageAccount.Parse(connS);
                    var blobClient = account.CreateCloudBlobClient();

                    var blobContainer = blobClient.GetContainerReference("aibookengine3");
                    blobContainer.CreateIfNotExistsAsync();

                    CloudBlockBlob blob = blobContainer.GetBlockBlobReference($"{fileName}");
                    string contents = blob.DownloadTextAsync().Result;
                    return contents;
                }

                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Reads content of file two lines in variables. </summary>
        ///
        /// <remarks>   Shadow, 4/2/2024. </remarks>
        ///
        /// <param name="sName">    The name. </param>
        ///
        /// <returns>   The content of file two lines in variables. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static List<string> ReadContentOfFileTwoLinesInVars(string sName)
        {
            List<string> TwoLinesfromFile = new List<string>();
            try
            {
                string appPath = AppDomain.CurrentDomain.BaseDirectory;
                using (StreamReader reader = new StreamReader(appPath + sName))
                {
                    TwoLinesfromFile.Add(reader.ReadLine()); // Read the first line
                    TwoLinesfromFile.Add(reader.ReadLine()); // Read the second line
                    return TwoLinesfromFile;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred reading two lines file for titles: " + e.Message);
            }
            return TwoLinesfromFile;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Reads content of file three lines in variables. </summary>
        ///
        /// <remarks>   Shadow, 4/2/2024. </remarks>
        ///
        /// <param name="sName">    The name. </param>
        ///
        /// <returns>   The content of file three lines in variables. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static List<string> ReadContentOfFileThreeLinesInVars(string sName)
        {
            List<string> TwoLinesfromFile = new List<string>();
            try
            {
                string appPath = AppDomain.CurrentDomain.BaseDirectory;
                using (StreamReader reader = new StreamReader(appPath + sName))
                {
                    TwoLinesfromFile.Add(reader.ReadLine()); // Read the first line
                    TwoLinesfromFile.Add(reader.ReadLine()); // Read the second line
                    TwoLinesfromFile.Add(reader.ReadLine()); // Read the Third line
                    TwoLinesfromFile.Add(reader.ReadLine()); // Read the Third line
                    return TwoLinesfromFile;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred reading two lines file for titles: " + e.Message);
            }
            return TwoLinesfromFile;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Removes the digits and non letters described by input. </summary>
        ///
        /// <remarks>   Shadow, 4/2/2024. </remarks>
        ///
        /// <param name="input">    The input. </param>
        ///
        /// <returns>   A string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string RemoveDigitsAndNonLetters(string input)
        {
            // Use a regular expression to remove all digits and non-letters before the first letter.
            string pattern = @"^[^a-zA-Z]*";
            string cleaned = Regex.Replace(input, pattern, "");

            return cleaned;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Starts with number using RegEx. </summary>
        ///
        /// <remarks>   Shadow, 4/2/2024. </remarks>
        ///
        /// <param name="input">    The input. </param>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static bool StartsWithNumberUsingRegex(string input)
        {
            string pattern = @"^\d";
            return Regex.IsMatch(input, pattern);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Removes the before letters described by input. </summary>
        ///
        /// <remarks>   Shadow, 4/2/2024. </remarks>
        ///
        /// <param name="input">    The input. </param>
        ///
        /// <returns>   A string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string RemoveBeforeLetters(string input)
        {
            int index = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsLetter(input[i]))
                {
                    index = i;
                    break;
                }
            }

            if (index > 0)
            {
                return input.Substring(index);
            }
            else
            {
                return input; // No letters found, return the original string.
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Removes the leading numbers described by input. </summary>
        ///
        /// <remarks>   Shadow, 4/2/2024. </remarks>
        ///
        /// <param name="input">    The input. </param>
        ///
        /// <returns>   A string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string RemoveLeadingNumbers(string input)
        {
            int startIndex = 0;

            while (startIndex < input.Length && char.IsDigit(input[startIndex]))
            {
                startIndex++;
            }

            return input.Substring(startIndex);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Adds a space after x coordinate. </summary>
        ///
        /// <remarks>   Shadow, 4/2/2024. </remarks>
        ///
        /// <param name="input">    The input. </param>
        ///
        /// <returns>   A string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string AddSpaceAfterX(string input)
        {
            string pattern = ":X";

            if (input.Contains(pattern + " "))
            {
                // ":X" is already followed by a space
                return input;
            }
            else
            {
                // Replace ":X" with ":X "
                return input.Replace(pattern, pattern + " ");
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sanitize file name. </summary>
        ///
        /// <remarks>   Shadow, 4/2/2024. </remarks>
        ///
        /// <param name="input">    The input. </param>
        ///
        /// <returns>   A string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private static string SanitizeFileName(string input)
        {
            char[] invalidChars = input.ToCharArray();

            // Replace illegal characters with a valid replacement (e.g., underscore)
            string sanitized = string.Join("_", input.Split(invalidChars, StringSplitOptions.RemoveEmptyEntries));

            // Check if the sanitized string is not empty
            if (!string.IsNullOrEmpty(sanitized))
            {
                // Truncate the sanitized string if it exceeds the maximum allowed filename length
                int maxFileNameLength = 260; // Windows file system limit
                if (sanitized.Length > maxFileNameLength)
                {
                    sanitized = sanitized.Substring(0, maxFileNameLength);
                }

                return sanitized.Replace("'", "");
            }

            return null; // The input contains only illegal characters
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Extracts the first part described by input. </summary>
        ///
        /// <remarks>   Shadow, 4/2/2024. </remarks>
        ///
        /// <param name="input">    The input. </param>
        ///
        /// <returns>   The extracted first part. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string ExtractFirstPart(string input)
        {
            string firstPart = string.Empty;

            foreach (char c in input)
            {
                if (char.IsDigit(c))
                {
                    break; // Stop when the first number is encountered
                }

                firstPart += c;
            }

            return firstPart;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A table checker. </summary>
        ///
        /// <remarks>
        /// Shadow, 1/17/2024. Check if the last <table> in a string is followed by a </table>
        /// </remarks>
        ///
        /// <param name="html"> The HTML. </param>
        ///
        /// <returns>   True if the last table is closed, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static bool IsLastTableClosed(string html)
        {
            // Find the last occurrence of <table>
            int lastTableStartIndex = html.LastIndexOf("<table", StringComparison.OrdinalIgnoreCase);

            // If there is no <table> tag, return true as there's nothing to check
            if (lastTableStartIndex == -1)
            {
                return true;
            }

            // Extract the substring from the last <table> tag to the end of the string
            string substringAfterLastTable = html.Substring(lastTableStartIndex);

            // Use Regex to check if there is a </table> tag in that substring
            return Regex.IsMatch(substringAfterLastTable, "</table>", RegexOptions.IgnoreCase);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Fix tables. </summary>
        ///
        /// <remarks>   Shadow, 4/2/2024. </remarks>
        ///
        /// <param name="html"> The HTML. </param>
        ///
        /// <returns>   A string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string FixTables(string html)
        {
            // This Regex finds all <table> tags including those that are not properly closed
            var tableMatches = Regex.Matches(html, "<table[^>]*>(?:(?!<table[^>]*>|</table>).)*", RegexOptions.Singleline | RegexOptions.IgnoreCase);

            // List to hold indexes where </table> needs to be inserted
            List<int> insertPositions = new List<int>();

            foreach (Match match in tableMatches)
            {
                // Check if the current match is not closed properly
                if (!match.Value.EndsWith("</table>", StringComparison.OrdinalIgnoreCase))
                {
                    // Calculate the position to insert </table>
                    int insertPos = match.Index + match.Length;
                    insertPositions.Add(insertPos);
                }
            }

            // Reverse the list to avoid altering the indexes of further insertions
            insertPositions.Reverse();

            // Insert </table> tags where needed
            foreach (int pos in insertPositions)
            {
                html = html.Insert(pos, "</table>");
            }

            return html;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Fix lists. </summary>
        ///
        /// <remarks>   Shadow, 4/2/2024. </remarks>
        ///
        /// <param name="html"> The HTML. </param>
        ///
        /// <returns>   A string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string FixLists(string html)
        {
            // This Regex finds all <ul> tags including those that are not properly closed
            var listMatches = Regex.Matches(html, "<ul[^>]*>(?:(?!<ul[^>]*>|</ul>).)*", RegexOptions.Singleline | RegexOptions.IgnoreCase);

            // List to hold indexes where </ul> needs to be inserted
            List<int> insertPositions = new List<int>();

            foreach (Match match in listMatches)
            {
                // Check if the current match is not closed properly
                if (!match.Value.EndsWith("</ul>", StringComparison.OrdinalIgnoreCase))
                {
                    // Calculate the position to insert </ul>
                    int insertPos = match.Index + match.Length;
                    insertPositions.Add(insertPos);
                }
            }

            // Reverse the list to avoid altering the indexes of further insertions
            insertPositions.Reverse();

            // Insert </ul> tags where needed
            foreach (int pos in insertPositions)
            {
                html = html.Insert(pos, "</ul>");
            }

            return html;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Ensures that proper table structure. </summary>
        ///
        /// <remarks>   Shadow, 4/2/2024. </remarks>
        ///
        /// <param name="doc">  The document. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void EnsureProperTableStructure(HtmlDocument doc)
        {
            var tableElements = doc.DocumentNode.SelectNodes("//table");
            if (tableElements != null)
            {
                foreach (var table in tableElements)
                {
                    if (!table.OuterHtml.Contains("</table>"))
                    {
                        table.InnerHtml += "</table>";
                    }
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Ensures that proper list structure. </summary>
        ///
        /// <remarks>   Shadow, 4/2/2024. </remarks>
        ///
        /// <param name="doc">  The document. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void EnsureProperListStructure(HtmlDocument doc)
        {
            var ulElements = doc.DocumentNode.SelectNodes("//ul");
            if (ulElements != null)
            {
                foreach (var ul in ulElements)
                {
                    if (!ul.OuterHtml.Contains("</ul>"))
                    {
                        ul.InnerHtml += "</ul>";
                    }
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Analyze and highlight text. </summary>
        ///
        /// <remarks>   Shadow, 4/2/2024. </remarks>
        ///
        /// <param name="inputText">    The input text. </param>
        ///
        /// <returns>   A string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string AnalyzeAndHighlightText(string inputText)
        {
            string highlightedText = "";

            using (Py.GIL())
            {
                dynamic sys = Py.Import("sys");
                string appPath = AppDomain.CurrentDomain.BaseDirectory;
                sys.path.append(appPath); // Set the path to your Python script directory

                dynamic script = Py.Import("text_analysis_script"); // Import the Python script for text analysis

                // Call the analyze_and_highlight_text function from the Python script
                dynamic result = script.analyze_and_highlight_text(inputText);

                // Convert the Python result to a C# string
                highlightedText = result.ToString();
            }

            return highlightedText;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Removes the unclosed HTML tags described by input. </summary>
        ///
        /// <remarks>   Shadow, 4/2/2024. </remarks>
        ///
        /// <param name="input">    The input. </param>
        ///
        /// <returns>   A string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string RemoveUnclosedHtmlTags(string input)
        {
            // Remove unclosed opening tags
            string cleanedText = Regex.Replace(input, "<[^>]+>", string.Empty);

            // Remove unclosed closing tags
            cleanedText = Regex.Replace(cleanedText, "</[^>]+>", string.Empty);

            return cleanedText;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Analyze and highlight leading words. </summary>
        ///
        /// <remarks>   Shadow, 4/2/2024. </remarks>
        ///
        /// <param name="inputText">    The input text. </param>
        /// <param name="apiKey">       The API key. </param>
        /// <param name="endpoint">     The endpoint. </param>
        ///
        /// <returns>   A string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static async Task<string> AnalyzeAndHighlightLeadingWords(string inputText, string apiKey, string endpoint)
        {
            using (var client = new HttpClient())
            {
                // Set the API endpoint and headers
                client.BaseAddress = new Uri(endpoint);
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", apiKey);

                // Prepare the request content
                var request = new
                {
                    documents = new[]
                    {
                    new { id = "1", language = "en", text = inputText }
                }
                };

                var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

                // Send the request to perform sentiment analysis
                var response = await client.PostAsync("text/analytics/v3.0/sentiment", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();

                    // Parse the sentiment analysis results
                    // You can also use other endpoints like keyPhrases to extract phrases

                    // Implement your custom logic to identify and highlight leading words in phrases
                    // For example, you can split the text into sentences and analyze each sentence.

                    // In this example, we'll simply return the input text with leading words highlighted
                    return HighlightLeadingWords(inputText);
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                    return inputText; // Return the original text on error
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Highlight leading words. </summary>
        ///
        /// <remarks>   Shadow, 4/2/2024. </remarks>
        ///
        /// <param name="inputText">    The input text. </param>
        ///
        /// <returns>   A string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        static string HighlightLeadingWords(string inputText)
        {
            string[] paragraphs = inputText.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            StringBuilder adjustedTextBuilder = new StringBuilder();

            bool firstParagraph = true;

            foreach (string paragraph in paragraphs)
            {
                string[] sentences = paragraph.Split(new[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string sentence in sentences)
                {
                    string trimmedSentence = sentence.Trim();
                    if (!string.IsNullOrEmpty(trimmedSentence))
                    {
                        string[] words = trimmedSentence.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                        if (words.Length >= 4 || (firstParagraph && words.Length > 0))
                        {
                            string leadingWords = string.Join(" ", words.Take(4));
                            string restOfSentence = string.Join(" ", words.Skip(4));

                            if (firstParagraph)
                            {
                                adjustedTextBuilder.AppendFormat("<b>{0}</b> {1}. ", leadingWords, restOfSentence);
                                firstParagraph = false;
                            }
                            else
                            {
                                adjustedTextBuilder.AppendFormat("<b>{0}</b> {1}. ", leadingWords, restOfSentence);
                            }
                        }
                        else
                        {
                            // If there are less than 4 words in the sentence, just highlight the whole sentence.
                            adjustedTextBuilder.AppendFormat("<b>{0}</b>. ", trimmedSentence);
                        }
                    }
                }

                adjustedTextBuilder.AppendLine();
            }

            return adjustedTextBuilder.ToString();
        }
        #region CodeBlock
        public static List<string> ExtractCodeBlocks(string input)
        {
            var codeBlocks = new List<string>();
            string pattern = @"(?s)(<\?xml.*?\?>|<html.*?>.*?<\/html>|<xaml.*?>.*?<\/xaml>|<script.*?>.*?<\/script>|<%\s*--.*?--\s*%>|<%.*?%>|/\*.*?\*/|<!--.*?-->|<\?.*?\?>|\b(?:public|private|protected|internal|static|void|int|string|double|float|bool|class)\s+\w+\s*\(.*?\)\s*\{.*?\})";

            var matches = Regex.Matches(input, pattern, RegexOptions.Singleline | RegexOptions.IgnoreCase);

            foreach (Match match in matches)
            {
                if (match.Groups.Count > 0)
                {
                    codeBlocks.Add(match.Value.Trim());
                }
            }

            return codeBlocks;
        }

        public static List<string> ModifyCodeBlocks(List<string> codeBlocks)
        {
            var modifiedCodeBlocks = new List<string>();

            for (int i = 0; i < codeBlocks.Count; i++)
            {
                string modifiedCode = codeBlocks[i] + "\n// This is a modified code block";
                modifiedCodeBlocks.Add(modifiedCode);
            }

            return modifiedCodeBlocks;
        }

        public static string ReplaceCodeBlocks(string original, List<string> modifiedCodeBlocks)
        {
            string pattern = @"/\* code start \*/(.*?)/\* code end \*/";
            var matches = Regex.Matches(original, pattern, RegexOptions.Singleline);
            int blockIndex = 0;

            StringBuilder enrichedText = new StringBuilder(original);

            foreach (Match match in matches)
            {
                if (match.Groups.Count > 1 && blockIndex < modifiedCodeBlocks.Count)
                {
                    string modifiedBlock = $@"<w:r><w:rPr><w:highlight w:val=""black""/><w:color w:val=""white""/></w:rPr><w:t>/* code start */\n{modifiedCodeBlocks[blockIndex]}\n/* code end */</w:t></w:r>";
                    enrichedText.Replace(match.Value, modifiedBlock);
                    blockIndex++;
                }
            }

            return enrichedText.ToString();
        }
        #endregion
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Emphasize important words. </summary>
        ///
        /// <remarks>   Shadow, 4/2/2024. </remarks>
        ///
        /// <param name="text"> The text. </param>
        ///
        /// <returns>   A string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string EmphasizeImportantWords(string text)
        {
            var words = Regex.Split(text, @"\W+");
            var wordCounts = words.GroupBy(word => word.ToLower())
                                  .ToDictionary(group => group.Key, group => group.Count());

            // Calculate TF-IDF (simplified for this example)
            var maxCount = wordCounts.Values.Max();
            var scores = wordCounts.ToDictionary(pair => pair.Key,
                                                 pair => pair.Value / (double)maxCount);

            // Assume words with the top 20% scores are important
            var threshold = scores.Values.OrderBy(x => x).Skip((int)(0.8 * scores.Count)).FirstOrDefault();

            // Emphasize important words
            return Regex.Replace(text, @"\w+", match =>
            {
                var lowerWord = match.Value.ToLower();
                if (scores.ContainsKey(lowerWord) && scores[lowerWord] >= threshold)
                    return "**" + match.Value + "**";
                return match.Value;
            });
        }

        #region Blob
        public static string deleteFileFromBlob(string fileName, string containerName)
        {
            try
            {
                // Initialise client in a different place if you like
                string connS = Secrets.cloudStorageConnString;
                CloudStorageAccount account = CloudStorageAccount.Parse(connS);
                var blobClient = account.CreateCloudBlobClient();

                var blobContainer = blobClient.GetContainerReference(containerName);
                blobContainer.CreateIfNotExistsAsync();

                CloudBlockBlob blob = blobContainer.GetBlockBlobReference($"{fileName}");

                if (blob.DeleteIfExistsAsync().Result)
                {
                    return "File deleted successfully.";
                }
                else
                {
                    return "File not found or failed to delete.";
                }

                return "";
            }
            catch (Exception ex)
            {
                return "0";
            }
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Writes a file to BLOB. </summary>
        ///
        /// <remarks>   Shadow, 4/2/2024. </remarks>
        ///
        /// <param name="writeToBlobAIBookEngine">  The write to BLOB an i book engine. </param>
        /// <param name="fileName">                 Filename of the file. </param>
        /// <param name="sBlobLong">                The BLOB long. </param>
        /// <param name="sBlob">                    The BLOB. </param>
        ///
        /// <returns>   A string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static async Task<string> writeFileToBlob(string writeToBlobAIBookEngine, string fileName, string sBlobLong, string sBlob)
        {
            try
            {
                // Initialise client in a different place if you like
                string connS = Secrets.cloudStorageConnString;
                var account = CloudStorageAccount.Parse(connS);
                var blobClient = account.CreateCloudBlobClient();

                // Make sure container is there
                var blobContainer = blobClient.GetContainerReference(sBlob);
                blobContainer.CreateIfNotExistsAsync();

                WebClient wc = new WebClient();
                using (Stream fs = wc.OpenWrite(sBlobLong + fileName))
                {
                    TextWriter tw = new StreamWriter(fs);
                    CloudBlockBlob blockBlob = blobContainer.GetBlockBlobReference(
                        fileName);
                    await blockBlob.UploadTextAsync(writeToBlobAIBookEngine);
                    tw.Flush();
                }
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Reads file from BLOB. </summary>
        ///
        /// <remarks>   Shadow, 4/2/2024. </remarks>
        ///
        /// <param name="fileName"> Filename of the file. </param>
        ///
        /// <returns>   The file from BLOB. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string readFileFromBlob(string fileName)
        {
            try
            {
                // Initialise client in a different place if you like
                string connS = Secrets.cloudStorageConnString;
                var account = CloudStorageAccount.Parse(connS);
                var blobClient = account.CreateCloudBlobClient();

                var blobContainer = blobClient.GetContainerReference("aibookengine");
                blobContainer.CreateIfNotExistsAsync();

                CloudBlockBlob blob = blobContainer.GetBlockBlobReference($"{fileName}");
                string contents = blob.DownloadTextAsync().Result;

                return contents;
            }
            catch (Exception ex)
            {
                return "0";
            }
        }

        public static async Task WriteProgress(string outputFilePathPdf, string outputFileProgressTxt, string progressText)
        {
            if (File.Exists(outputFileProgressTxt))
            {
                Console.WriteLine("The progress file exists — deleting...");
                GlobalMethods.deleteFileFromBlob(outputFileProgressTxt, "mindscriptedconfig");
                File.Delete(outputFileProgressTxt);
            }
            else
            {
                Console.WriteLine("The progress file does NOT exist.");
            }

            // (Re)create the progress file
            HtmlGenerator.CreateProgressDocument(outputFileProgressTxt, progressText);

            // Read and upload to blob
            byte[] txtBytes = File.ReadAllBytes(outputFileProgressTxt);
            Console.WriteLine("After byte fill progress");
            string resultProgress = await GlobalMethods.WritePdfToBlobAsync(txtBytes, outputFileProgressTxt, "mindscriptedconfig");

        }
        public static string readFileFromBlob(string fileName, string blobber)
        {
            try
            {
                // Initialise client in a different place if you like
                string connS = Secrets.cloudStorageConnString;
                CloudStorageAccount account = CloudStorageAccount.Parse(connS);
                var blobClient = account.CreateCloudBlobClient();

                var blobContainer = blobClient.GetContainerReference(blobber);
                blobContainer.CreateIfNotExistsAsync();

                CloudBlockBlob blob = blobContainer.GetBlockBlobReference($"{fileName}");
                string contents = blob.DownloadTextAsync().Result;

                return contents;
            }
            catch (Exception ex)
            {
                return "0";
            }
        }
        public static async Task<string> writeFileToBlobPref(string writeToBlobKentekenControle, string fileName)
        {
            try
            {
                // Initialise client in a different place if you like
                string connS = Secrets.cloudStorageConnString;
                var account = CloudStorageAccount.Parse(connS);
                var blobClient = account.CreateCloudBlobClient();

                // Make sure container is there
                var blobContainer = blobClient.GetContainerReference("kentekenccontrole");
                await blobContainer.CreateIfNotExistsAsync();

                WebClient wc = new WebClient();
                using (Stream fs = wc.OpenWrite(Secrets.blobKentekenControle + fileName))
                {
                    TextWriter tw = new StreamWriter(fs);
                    CloudBlockBlob blockBlob = blobContainer.GetBlockBlobReference(
                        fileName);
                    await blockBlob.UploadTextAsync(writeToBlobKentekenControle);
                    //tw.Flush();
                }
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static async Task<string> WritePdfToBlobAsync(byte[] pdfBytes, string fileName, string containername)
        {
            try
            {
                string connS = Secrets.cloudStorageConnString;
                var account = CloudStorageAccount.Parse(connS);
                var blobClient = account.CreateCloudBlobClient();

                var blobContainer = blobClient.GetContainerReference(containername);
                await blobContainer.CreateIfNotExistsAsync();

                CloudBlockBlob blockBlob = blobContainer.GetBlockBlobReference(fileName);
                using (var stream = new MemoryStream(pdfBytes))
                {
                    await blockBlob.UploadFromStreamAsync(stream);
                }

                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        #endregion
        #region Google

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Synthesize text. </summary>
        ///
        /// <remarks>   Shadow, 4/2/2024. </remarks>
        ///
        /// <param name="text"> The text. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void SynthesizeText(string text)
        {
            TextToSpeechClient client = TextToSpeechClient.Create();

            // Configure the request with language and voice
            SynthesizeSpeechRequest request = new SynthesizeSpeechRequest
            {
                Input = new SynthesisInput
                {
                    Text = text
                },
                Voice = new VoiceSelectionParams
                {
                    LanguageCode = "nl-NL", // Dutch language
                    SsmlGender = SsmlVoiceGender.Neutral
                },
                AudioConfig = new Google.Cloud.TextToSpeech.V1.AudioConfig
                {
                    AudioEncoding = AudioEncoding.Mp3
                }
            };

            // Perform the Text-to-Speech request
            var response = client.SynthesizeSpeech(request);

            // Write the response to an MP3 file
            using (Stream output = File.Create("output.mp3"))
            {
                response.AudioContent.WriteTo(output);
                Console.WriteLine($"Audio content written to file 'output.mp3'");
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Executes the speak newline operation. </summary>
        ///
        /// <remarks>   Shadow, 4/2/2024. </remarks>
        ///
        /// <param name="client">           The client. </param>
        /// <param name="textToSynthesize"> The text to synthesize. </param>
        /// <param name="_speed">           The speed. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void DoSpeakNL(TextToSpeechClient client, string textToSynthesize, float _speed)
        {
            float sRate = _speed;
            string ssml = $"<speak><prosody rate=\"{sRate}\">{textToSynthesize}</prosody></speak>";

            // Set up the input text
            SynthesisInput input = new SynthesisInput
            {
                Ssml = ssml
            };


            // Configure the voice parameters (e.g., language, pitch, speaking rate)
            VoiceSelectionParams voiceSelection = new VoiceSelectionParams
            {
                LanguageCode = "nl-NL",
                Name = "nl-NL-Wavenet-D",
                SsmlGender = SsmlVoiceGender.Female
            };

            Google.Cloud.TextToSpeech.V1.AudioConfig audioConfig = new Google.Cloud.TextToSpeech.V1.AudioConfig
            {
                AudioEncoding = AudioEncoding.Linear16,
                SampleRateHertz = 16000, // Adjust as needed
            };

            // Generate the speech
            SynthesizeSpeechResponse response = client.SynthesizeSpeech(input, voiceSelection, audioConfig);

            // Convert the byte array to a WAV file
            string outputPath = "output.wav";
            ConvertToWav(response.AudioContent.ToByteArray(), outputPath);

            Console.WriteLine("Speech converted to WAV.");

            // Play the generated WAV audio
            PlayAudio(outputPath);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Executes the speak computer operation. </summary>
        ///
        /// <remarks>   Shadow, 4/2/2024. </remarks>
        ///
        /// <param name="client">           The client. </param>
        /// <param name="textToSynthesize"> The text to synthesize. </param>
        /// <param name="_speed">           The speed. </param>
        /// <param name="wavFile">          The WAV file. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void DoSpeakComputer(TextToSpeechClient client, string textToSynthesize,
            float _speed, string wavFile)
        {
            float sRate = _speed;
            string ssml = $"<speak><prosody rate=\"{sRate}\">{textToSynthesize}</prosody></speak>";

            // Set up the input text
            SynthesisInput input = new SynthesisInput
            {
                Ssml = ssml
            };


            // Configure the voice parameters (e.g., language, pitch, speaking rate)
            VoiceSelectionParams voiceSelection = new VoiceSelectionParams
            {
                LanguageCode = "en-US", // Language code (English, US)
                Name = "en-US-Wavenet-F", // Voice name (adjust as needed)
                SsmlGender = SsmlVoiceGender.Female
            };

            Google.Cloud.TextToSpeech.V1.AudioConfig audioConfig = new Google.Cloud.TextToSpeech.V1.AudioConfig
            {
                AudioEncoding = AudioEncoding.Linear16,
                SampleRateHertz = 16000, // Adjust as needed
            };

            // Generate the speech
            SynthesizeSpeechResponse response = client.SynthesizeSpeech(input, voiceSelection, audioConfig);

            // Convert the byte array to a WAV file
            string outputPath = wavFile;
            ConvertToWav(response.AudioContent.ToByteArray(), outputPath);

            Console.WriteLine("Speech converted to WAV.");

            // Play the generated WAV audio
            PlayAudio(outputPath);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Executes the speak us mail operation. </summary>
        ///
        /// <remarks>   Shadow, 4/2/2024. </remarks>
        ///
        /// <param name="client">           The client. </param>
        /// <param name="textToSynthesize"> The text to synthesize. </param>
        /// <param name="_speed">           The speed. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void DoSpeakUSMail(TextToSpeechClient client, string textToSynthesize, float _speed)
        {
            float sRate = _speed;
            string ssml = $"<speak><prosody rate=\"{sRate}\">{textToSynthesize}</prosody></speak>";

            // Set up the input text
            SynthesisInput input = new SynthesisInput
            {
                Ssml = ssml
            };


            // Configure the voice parameters (e.g., language, pitch, speaking rate)
            VoiceSelectionParams voiceSelection = new VoiceSelectionParams
            {
                LanguageCode = "en-US", // Language code (English, US)
                Name = "en-US-Wavenet-D", // Voice name (adjust as needed)
                SsmlGender = SsmlVoiceGender.Male
            };

            Google.Cloud.TextToSpeech.V1.AudioConfig audioConfig = new Google.Cloud.TextToSpeech.V1.AudioConfig
            {
                AudioEncoding = AudioEncoding.Linear16,
                SampleRateHertz = 16000, // Adjust as needed
            };

            // Generate the speech
            SynthesizeSpeechResponse response = client.SynthesizeSpeech(input, voiceSelection, audioConfig);

            // Convert the byte array to a WAV file
            string outputPath = "output.wav";
            ConvertToWav(response.AudioContent.ToByteArray(), outputPath);

            Console.WriteLine("Speech converted to WAV.");

            // Play the generated WAV audio
            PlayAudio(outputPath);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Executes the speak us operation. </summary>
        ///
        /// <remarks>   Shadow, 4/2/2024. </remarks>
        ///
        /// <param name="client">           The client. </param>
        /// <param name="textToSynthesize"> The text to synthesize. </param>
        /// <param name="_speed">           The speed. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void DoSpeakUS(TextToSpeechClient client, string textToSynthesize, float _speed)
        {
            float sRate = _speed;
            string ssml = $"<speak><prosody rate=\"{sRate}\">{textToSynthesize}</prosody></speak>";

            // Set up the input text
            SynthesisInput input = new SynthesisInput
            {
                Ssml = ssml
            };


            // Configure the voice parameters (e.g., language, pitch, speaking rate)
            VoiceSelectionParams voiceSelection = new VoiceSelectionParams
            {
                LanguageCode = "en-US", // Language code (English, US)
                Name = "en-US-Wavenet-F", // Voice name (adjust as needed)
                SsmlGender = SsmlVoiceGender.Female
            };

            Google.Cloud.TextToSpeech.V1.AudioConfig audioConfig = new Google.Cloud.TextToSpeech.V1.AudioConfig
            {
                AudioEncoding = AudioEncoding.Linear16,
                SampleRateHertz = 16000, // Adjust as needed
            };

            // Generate the speech
            SynthesizeSpeechResponse response = client.SynthesizeSpeech(input, voiceSelection, audioConfig);

            // Convert the byte array to a WAV file
            string outputPath = "output.wav";
            ConvertToWav(response.AudioContent.ToByteArray(), outputPath);

            Console.WriteLine("Speech converted to WAV.");

            // Play the generated WAV audio
            PlayAudio(outputPath);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Executes the speak uk operation. </summary>
        ///
        /// <remarks>   Shadow, 4/2/2024. </remarks>
        ///
        /// <param name="client">           The client. </param>
        /// <param name="textToSynthesize"> The text to synthesize. </param>
        /// <param name="_speed">           The speed. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void DoSpeakUK(TextToSpeechClient client, string textToSynthesize, float _speed)
        {
            float sRate = _speed;
            string ssml = $"<speak><prosody rate=\"{sRate}\">{textToSynthesize}</prosody></speak>";

            // Set up the input text
            SynthesisInput input = new SynthesisInput
            {
                Ssml = ssml
            };

            // Configure the voice parameters (e.g., language, pitch, speaking rate)
            VoiceSelectionParams voiceSelection = new VoiceSelectionParams
            {
                LanguageCode = "en-GB", // Language code (English, US)
                Name = "en-GB-Wavenet-C", // Voice name (adjust as needed)
                SsmlGender = SsmlVoiceGender.Female
            };

            Google.Cloud.TextToSpeech.V1.AudioConfig audioConfig = new Google.Cloud.TextToSpeech.V1.AudioConfig
            {
                AudioEncoding = AudioEncoding.Linear16,
                SampleRateHertz = 16000, // Adjust as needed
            };

            // Generate the speech
            SynthesizeSpeechResponse response = client.SynthesizeSpeech(input, voiceSelection, audioConfig);

            // Convert the byte array to a WAV file
            string outputPath = "output.wav";
            ConvertToWav(response.AudioContent.ToByteArray(), outputPath);

            Console.WriteLine("Speech converted to WAV.");

            // Play the generated WAV audio
            PlayAudio(outputPath);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Executes the speak de operation. </summary>
        ///
        /// <remarks>   Shadow, 4/2/2024. </remarks>
        ///
        /// <param name="client">           The client. </param>
        /// <param name="textToSynthesize"> The text to synthesize. </param>
        /// <param name="_speed">           The speed. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void DoSpeakDE(TextToSpeechClient client, string textToSynthesize, float _speed)
        {
            float sRate = _speed;
            string ssml = $"<speak><prosody rate=\"{sRate}\">{textToSynthesize}</prosody></speak>";

            // Set up the input text
            SynthesisInput input = new SynthesisInput
            {
                Ssml = ssml
            };

            // Configure the voice parameters (e.g., language, pitch, speaking rate)
            VoiceSelectionParams voiceSelection = new VoiceSelectionParams
            {
                LanguageCode = "de-DE", // Language code (German, DE)
                Name = "de-DE-Wavenet-A", // Voice name (adjust as needed)
            };

            Google.Cloud.TextToSpeech.V1.AudioConfig audioConfig = new Google.Cloud.TextToSpeech.V1.AudioConfig
            {
                AudioEncoding = AudioEncoding.Linear16,
                SampleRateHertz = 16000, // Adjust as needed
            };

            // Generate the speech
            SynthesizeSpeechResponse response = client.SynthesizeSpeech(input, voiceSelection, audioConfig);

            // Convert the byte array to a WAV file
            string outputPath = "output.wav";
            ConvertToWav(response.AudioContent.ToByteArray(), outputPath);

            Console.WriteLine("Speech converted to WAV.");

            // Play the generated WAV audio
            PlayAudio(outputPath);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Executes the speak background operation. </summary>
        ///
        /// <remarks>   Shadow, 4/2/2024. </remarks>
        ///
        /// <param name="client">           The client. </param>
        /// <param name="textToSynthesize"> The text to synthesize. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void DoSpeakBG(TextToSpeechClient client, string textToSynthesize)
        {
            // Set up the input text
            SynthesisInput input = new SynthesisInput
            {
                Text = textToSynthesize
            };

            // Configure the voice parameters (e.g., language, pitch, speaking rate)
            VoiceSelectionParams voiceSelection = new VoiceSelectionParams
            {
                LanguageCode = "bg-BG", // Language code for Bulgarian (BG)
                Name = "bg-BG-Standard-A", // Voice name (adjust as needed)
            };

            Google.Cloud.TextToSpeech.V1.AudioConfig audioConfig = new Google.Cloud.TextToSpeech.V1.AudioConfig
            {
                AudioEncoding = AudioEncoding.Linear16,
                SampleRateHertz = 16000, // Adjust as needed
            };

            // Generate the speech
            SynthesizeSpeechResponse response = client.SynthesizeSpeech(input, voiceSelection, audioConfig);

            // Convert the byte array to a WAV file
            string outputPath = "output.wav";
            ConvertToWav(response.AudioContent.ToByteArray(), outputPath);

            Console.WriteLine("Speech converted to WAV.");

            // Play the generated WAV audio
            PlayAudio(outputPath);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Executes the speak operation. </summary>
        ///
        /// <remarks>   Shadow, 4/2/2024. </remarks>
        ///
        /// <param name="client">           The client. </param>
        /// <param name="textToSynthesize"> The text to synthesize. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void DoSpeak(TextToSpeechClient client, string textToSynthesize)
        {
            // Set up the input text
            SynthesisInput input = new SynthesisInput
            {
                Text = textToSynthesize
            };

            // Configure the voice parameters (e.g., language, pitch, speaking rate)
            VoiceSelectionParams voiceSelection = new VoiceSelectionParams
            {
                LanguageCode = "en-US", // Language code (English, US)
                Name = "en-US-Wavenet-D", // Voice name (adjust as needed)
            };

            Google.Cloud.TextToSpeech.V1.AudioConfig audioConfig = new Google.Cloud.TextToSpeech.V1.AudioConfig
            {
                AudioEncoding = AudioEncoding.Linear16,
                SampleRateHertz = 16000, // Adjust as needed
            };

            // Generate the speech
            SynthesizeSpeechResponse response = client.SynthesizeSpeech(input, voiceSelection, audioConfig);

            // Convert the byte array to a WAV file
            string outputPath = "output.wav";
            ConvertToWav(response.AudioContent.ToByteArray(), outputPath);

            Console.WriteLine("Speech converted to WAV.");

            // Play the generated WAV audio
            PlayAudio(outputPath);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Converts this object to a WAV. </summary>
        ///
        /// <remarks>   Shadow, 4/2/2024. </remarks>
        ///
        /// <param name="audioData">    Information describing the audio. </param>
        /// <param name="outputPath">   Full pathname of the output file. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void ConvertToWav(byte[] audioData, string outputPath)
        {
            try
            {
                using (MemoryStream stream = new MemoryStream(audioData))
                {
                    using (WaveFileWriter waveWriter = new WaveFileWriter(outputPath, new WaveFormat(16000, 16, 1)))
                    {
                        stream.CopyTo(waveWriter);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error converting to WAV: {ex.Message}");
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Play audio. </summary>
        ///
        /// <remarks>   Shadow, 4/2/2024. </remarks>
        ///
        /// <param name="audioFilePath">    Full pathname of the audio file. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void PlayAudio(string audioFilePath)
        {
            try
            {
                using (var audioFileReader = new AudioFileReader(audioFilePath))
                using (var outputDevice = new WaveOutEvent())
                {
                    outputDevice.Init(audioFileReader);
                    outputDevice.Play();
                    while (outputDevice.PlaybackState == PlaybackState.Playing)
                    {
                        // Wait for the audio to finish playing
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error playing audio: {ex.Message}");
            }
        }
        #endregion

    }
    public static class UpDateProgress
    {
        public static async Task SendProgressAsync(int percent)
        {
            using var client = new HttpClient();
            var content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { "value", percent.ToString() }
            });

            // Replace with your local MVC app URL
            await client.PostAsync("https://localhost:7110/Progress/update", content);
        }
    }
    public static class LargeGPT
    {
        private static readonly string apiKey = Secrets._o1;
        private static readonly string apiUrl = "https://api.openai.com/v1/chat/completions"; // API endpoint

        public static async Task<string> CallLargeChatGPT(string prompt, string modell)
        {
            var response = await CallOpenAIAsync(prompt, modell);
            Console.WriteLine(response);
            return response;
        }

        static async Task<string> CallOpenAIAsync(string prompt, string modell)
        {
            int maxRetries = 10;
            int retryCount = 0;
            TimeSpan delay = TimeSpan.FromSeconds(2); // Initial delay

            while (retryCount < maxRetries)
            {
                using (HttpClient client = new HttpClient { Timeout = TimeSpan.FromSeconds(500) })
                {
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

                    var requestBody = new
                    {
                        model = modell, // Change to "o1" if needed
                        messages = new[]
                        {
                    new { role = "system", content = "You are a helpful assistant." },
                    new { role = "user", content = prompt }
                },
                        max_completion_tokens = 100000
                    };

                    string jsonContent = JsonConvert.SerializeObject(requestBody);
                    var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                    try
                    {
                        HttpResponseMessage response = await client.PostAsync(apiUrl, content);
                        response.EnsureSuccessStatusCode(); // Throw exception if not successful

                        string responseString = await response.Content.ReadAsStringAsync();
                        using JsonDocument doc = JsonDocument.Parse(responseString);

                        return doc.RootElement
                            .GetProperty("choices")[0]
                            .GetProperty("message")
                            .GetProperty("content")
                            .GetString();
                    }
                    catch (TaskCanceledException ex) when (ex.InnerException is TimeoutException)
                    {
                        // Handle timeout
                        retryCount++;
                        if (retryCount >= maxRetries)
                            throw new Exception("Request timed out after multiple retries.", ex);

                        await Task.Delay(delay);
                        delay *= 2; // Exponential backoff
                    }
                    catch (HttpRequestException ex)
                    {
                        // Handle other request errors (like network issues)
                        retryCount++;
                        if (retryCount >= maxRetries)
                            throw new Exception("HTTP request failed after multiple retries.", ex);

                        await Task.Delay(delay);
                        delay *= 4;
                    }
                }
            }

            throw new Exception("Unexpected error: Maximum retries exceeded.");
        }
        public static async Task<string> GetGrok(string question)
        {
            string resultGrok = "";
            // Your API key and base URL 
            string apiKey = Secrets.GrokKey;
            string baseURL = Secrets.GrokCompletionAddress;

            // Create the HTTP client 
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
                string gRok = "";
                // Define the request body 
                var requestBody = new
                {
                    model = "grok-3-mini-beta",
                    messages = new[]
                    {
                    new { role = "system", content = Secrets.GrokRole },
                    new { role = "user", content = question }
                    },
                    max_tokens = 40000  // Set to the maximum allowed tokens for grok-beta
                };

                // Serialize the request body to JSON 
                string json = JsonConvert.SerializeObject(requestBody);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // Make the POST request 
                HttpResponseMessage response = await client.PostAsync(baseURL, content);

                // Read and output the response 
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    dynamic result = JsonConvert.DeserializeObject(responseBody);
                    resultGrok = result.choices[0].message.content;
                    gRok = resultGrok;

                }
                else
                {
                    resultGrok = response.StatusCode.ToString();
                    gRok = resultGrok;

                }
            }
            return resultGrok;

        }
        public static async Task<string> GetGoogleLarge(string textToTranslate)
        {
            string directoryPath = AppDomain.CurrentDomain.BaseDirectory;
            try
            {
                // 1. Vertex AI Configuration
                string projectId = Secrets.GoogleProjectID;
                string location = "us-central1";
                string publisher = "google";
                string modelId = "gemini-2.5-pro-exp-03-25";
                string apiEndpoint = $"https://{location}-aiplatform.googleapis.com/v1/projects/{projectId}/locations/{location}/publishers/{publisher}/models/{modelId}:generateContent";
                var credentialsFilePath = directoryPath + Secrets.GoogleCredentialFile;

                Console.WriteLine($"API Endpoint: {apiEndpoint}");
                Console.WriteLine($"Credentials Path: {credentialsFilePath}");

                // 2. Set up authentication
                var credential = Google.Apis.Auth.OAuth2.GoogleCredential.FromFile(credentialsFilePath);
                var scopedCredential = credential.CreateScoped(new[] { "https://www.googleapis.com/auth/cloud-platform" });
                var accessToken = await scopedCredential.UnderlyingCredential.GetAccessTokenForRequestAsync();
                Console.WriteLine("Access Token retrieved successfully");

                // 3. Prepare the Request
                string question = textToTranslate ?? "Default prompt: Tell me about stars."; // Fallback if null
                Console.WriteLine($"Input Question: {question}");
                var requestData = new
                {
                    contents = new[]
                    {
                    new { role = "user", parts = new[] { new { text = question } } }
                },
                    generationConfig = new
                    {
                        temperature = 0.4,
                        maxOutputTokens = 64000,
                        topP = 0.95,
                        topK = 40
                    }
                };
                string jsonContent = JsonConvert.SerializeObject(requestData);
                Console.WriteLine($"Request JSON: {jsonContent}");

                // 4. Make the API call
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
                    var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(apiEndpoint, content);
                    string result = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Raw API Response: {result}");
                    Console.WriteLine($"HTTP Status Code: {response.StatusCode}");

                    // Check if the response was successful
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new Exception($"API request failed with status {response.StatusCode}: {result}");
                    }

                    // 5. Parse the response
                    var responseData = JsonConvert.DeserializeObject<ResponseData>(result);
                    if (responseData?.Candidates?.Length > 0 && responseData.Candidates[0].Content?.Parts?.Length > 0)
                    {
                        string answer = responseData.Candidates[0].Content.Parts[0].Text;
                        Console.WriteLine($"Extracted Answer: {answer}");
                        return answer;
                    }
                    else
                    {
                        throw new Exception("No valid response from the API: " + result);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return $"Error: {ex.Message}";
            }

        }
        public class ResponseData
        {
            public Candidate[] Candidates { get; set; }
        }

        public class Candidate
        {
            public Content Content { get; set; }
            public string FinishReason { get; set; }
            public int Index { get; set; }
        }

        public class Content
        {
            public Part[] Parts { get; set; }
            public string Role { get; set; }
        }

        public class Part
        {
            public string Text { get; set; }
        }
        public static async Task<string> GetGoogle(string textToTranslate, string targetLanguage)
        {
            try
            {
                string translation = "";
                if (targetLanguage.Contains("nl"))
                    translation = "Translate the answer of the following to Dutch";
                else
                    translation = "";

                // Get the full path of the executable file
                string directoryPath = AppDomain.CurrentDomain.BaseDirectory;

                // 1. Vertex AI Configuration
                string projectId = Secrets.GoogleProjectID;     // Your Google Cloud Project ID
                string location = "us-central1";                // Your Vertex AI Model Location
                string publisher = "google";                    // Publisher of the model (e.g., "google")
                //string modelId = "text-bison@001";              // ID of the Vertex AI Model
                string modelId = "gemini-2.5-pro-exp-03-25";
                string apiEndpoint = $"https://{location}-aiplatform.googleapis.com/v1/projects/{projectId}/locations/{location}/publishers/{publisher}/models/{modelId}:predict";
                var credentialsFilePath = directoryPath + Secrets.GoogleCredentialFile;
                // 2. Prepare the Request
                //string question = textToTranslate;
                string question = translation + "-" + textToTranslate;
                var requestData = new
                {
                    instances = new[]
                    {
                    new { prompt = question }
                },
                    parameters = new
                    {
                        temperature = 0.4,                  // Slightly higher for creativity
                        maxOutputTokens = 64000,             // Increased token limit
                        topP = 0.95,                        // Nucleus sampling for diverse text
                        topK = 40                           // Top-k sampling for focused text
                    }
                };
                string jsonContent = JsonConvert.SerializeObject(requestData);

                // 3. Authenticate with OAuth 2.0 (Service Account)
                GoogleCredential credential = GoogleCredential.FromFile(credentialsFilePath)
                    .CreateScoped(PredictionServiceClient.DefaultScopes); // Adjust scopes if needed
                var accessToken = await credential.UnderlyingCredential.GetAccessTokenForRequestAsync();

                // 4. Send the REST Request
                using var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

                var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");

                var response = await client.PostAsync(apiEndpoint, content);

                // 4. Handle the Response
                if (response.IsSuccessStatusCode)
                {
                    string responseJson = await response.Content.ReadAsStringAsync();
                    dynamic responseData = JsonConvert.DeserializeObject(responseJson);

                    string answer = responseData.predictions[0].content;
                    return answer;
                }
                else
                {
                    return "Failed: " + response.StatusCode;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

    }
    public static class ConvertWordToHtml
    {
        public static void ConvertWToHtml(string wDocument, string hDocument)
        {
            string wordFilePath = wDocument;
            string htmlFilePath = hDocument;

            Converter(wordFilePath, htmlFilePath);
        }

        public static void Converter(string wordPath, string htmlPath)
        {
            // Load the Word document
            Aspose.Words.Document doc = new Aspose.Words.Document(wordPath);

            // Save as HTML
            doc.Save(htmlPath, Aspose.Words.SaveFormat.Html);

            Console.WriteLine("Conversion successful: " + htmlPath);
        }
    }

public static class HtmlGenerator
    {
        public static void WriteHtmlHead(string htmlFilePath)
        {
            string htmlHead = @"<!DOCTYPE html>
                <html lang=""en"">
                <head>
                    <meta charset=""UTF-8"">
                    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                    <title>Image in HTML</title>
                    <style>
                        .image-container {
                            text-align: center;
                            margin: 20px auto;
                            border: 2px solid black;
                            display: inline-block;
                            padding: 10px;
                        }
                        .image-container img {
                            max-width: 1024px;
                            height: auto;
                        }
                    </style>
                </head>
                <body>
                ";

            // Append only if the file does not exist
            if (!File.Exists(htmlFilePath))
            {
                File.AppendAllText(htmlFilePath, htmlHead, Encoding.UTF8);
                Console.WriteLine("HTML head section appended successfully: " + htmlFilePath);
            }
            else
            {
                Console.WriteLine("HTML file already exists. Skipping head section.");
            }
        }
        public static string CreateProgressDocument(string filename, string cContent)
        {
            if (File.Exists(filename))
            {
                Console.WriteLine("Progress file already exists. Skipping creation.");
                return filename;
            }

            File.AppendAllText(filename, cContent + '\n', Encoding.UTF8);
            Console.WriteLine("Progress document created successfully at: " + filename);
            return filename;
        }
        public static void AppendImageToHtml(string htmlFilePath, string imagePath)
        {
            string newContent = $@"
                <center><div class=""image-container"">
                    <img src=""{imagePath}"" alt=""Inserted Image"">
                </div></center>";

            AppendToBody(htmlFilePath, newContent, "Image HTML snippet appended successfully.");
        }

        public static void InsertQuotedText(string filePath, string quoteText, bool pageBreak, bool italic,
                                            string colorBackground, bool _borders, string textColor,
                                            string fontType = "Garamond", int fontSize = 16)
        {
            string fontStyle = italic ? "font-style: italic;" : "";
            string borderStyle = _borders ? $"border: 2px solid {textColor};" : "";
            string backgroundColor = !string.IsNullOrEmpty(colorBackground) ? $"background-color: {colorBackground};" : "";
            string textColorStyle = $"color: {textColor};";
            string fontSizeStyle = $"font-size: {fontSize}px;";
            string fontFamily = $"font-family: '{fontType}', serif;";

            string quoteHtml = $@"
                <div style=""text-align: center; {borderStyle} {backgroundColor} padding: 10px; margin: 20px auto; width: 80%;"">
                    <p style=""{fontFamily} {fontSizeStyle} {fontStyle} {textColorStyle} margin: 0;"">{quoteText}</p>
                </div>";

            if (pageBreak)
                quoteHtml += "<div style='page-break-after: always;'></div>";

            AppendToBody(filePath, quoteHtml, "Quoted text added successfully.");
        }

        public static void AppendBoldTextToHtml(string filePath, string text, bool pageBreak,
                                                string fontType = "Old English Text MT", int fontSize = 24)
        {
            string boldTextHtml = $@"
                <p style=""font-weight: bold; font-family: '{fontType}', serif; font-size: {fontSize}px; text-align: center;"">
                    {text}
                </p>";

            if (pageBreak)
                boldTextHtml += "<div style='page-break-after: always;'></div>";

            AppendToBody(filePath, boldTextHtml, "Bold text added successfully.");
        }

        public static void AppendHeaderToHtml(string filePath, string headerText, string headerLevel,
                                              string fontType = "Old English Text MT")
        {
            string validHeaderLevel = (headerLevel == "h1" || headerLevel == "h2" || headerLevel == "h3" ||
                                       headerLevel == "h4" || headerLevel == "h5" || headerLevel == "h6")
                                      ? headerLevel
                                      : "h2";

            string headerHtml = $@"
                <{validHeaderLevel} style=""font-family: '{fontType}', serif; text-align: center; font-weight: bold; font-size: 32px;"">
                    {headerText}
                </{validHeaderLevel}>";

            AppendToBody(filePath, headerHtml, "Header added successfully.");
        }

        public static void AppendTextToHtmlDocument(string filePath, string textToSynthesize,
                                                    string fontType = "Old English Text MT", double fontSize = 14.5)
        {
            string[] paragraphs = textToSynthesize.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);

            StringBuilder formattedText = new StringBuilder();
            foreach (string paragraphText in paragraphs)
            {
                if (!string.IsNullOrWhiteSpace(paragraphText))
                {
                    formattedText.AppendLine($@"
                    <p style=""font-family: '{fontType}', serif; font-size: {fontSize}px; text-align: left; margin-bottom: 10px;"">
                        {paragraphText}
                    </p>");
                }
            }

            AppendToBody(filePath, formattedText.ToString(), "Formatted text added successfully.");
        }

        public static void AppendClosingHtmlTags(string filePath)
        {
            if (!File.Exists(filePath)) return;

            string htmlContent = File.ReadAllText(filePath, Encoding.UTF8);

            if (!htmlContent.Contains("</body>") && !htmlContent.Contains("</html>"))
            {
                File.AppendAllText(filePath, "\n</body>\n</html>", Encoding.UTF8);
                Console.WriteLine("Closing HTML tags appended successfully.");
            }
            else
            {
                Console.WriteLine("Closing HTML tags already exist. No changes made.");
            }
        }

        public static string CreateHtmlDocument(string filename)
        {
            if (File.Exists(filename))
            {
                Console.WriteLine("HTML file already exists. Skipping creation.");
                return filename;
            }

            string imagePath = GetPromptVars.MainHtmlImageTop; // Without .jpg
            string firstPageInit = GetPromptVars.FirstPageInitiation;
            string bookTitle = GetPromptVars.TitleBook;
            string headerTitle = GetPromptVars.MainHeaderTitleOfBook;
            
            string emptyHtmlContent = $@"
            <!DOCTYPE html>
            <html lang=""en"">
            <head>
                <meta charset=""UTF-8"">
                <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                <title>{bookTitle}</title>
                <style>
                    p, table, ul, li {{
                        font-family: 'Arial', sans-serif;
                        font-size: 14px;
                        color: #000;
                        background-color: #fff;
                        line-height: 1.6;
                        margin: 0;
                        padding: 0;
                    }}
                    ul {{
                        font-size: 12px;
                    }}
                    body {{
                        font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
                        font-size: 16px;
                        color: #000;
                        background-color: #fff;
                        line-height: 1.6;
                        margin: 0;
                        padding: 0;
                    }}
                    .text-container {{
                        width: 95%;
                        margin: auto;
                        margin-bottom: 40mm;
                        padding: 2px;
                        font-family: Arial, sans-serif;
                        font-size: 12pt;
                        line-height: 1.5;
                        text-align: justify;
                    }}
                    .a4-page {{
                        width: 210mm;
                        height: 297mm;
                        max-width: 210mm;
                        aspect-ratio: 210 / 297;
                        margin: auto;
                        padding: 5mm 5mm 20mm 5mm;
                        background: white;
                        box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.2);
                    }}
                    @media print {{
                        body {{
                            margin: 0;
                            padding: 0;
                        }}
                        .a4-page {{
                            width: 210mm;
                            height: 297mm;
                            max-width: 210mm;
                            aspect-ratio: 210 / 297;
                            margin: auto;
                            padding: 5mm 5mm 20mm 5mm;
                            box-shadow: none;
                        }}
                    }}
                    .image-container {{
                        text-align: center;
                        margin: 10px auto;
                        border: 1px solid black;
                        display: inline-block;
                        padding: 6px;
                    }}
                    .image-container img {{
                        max-width: 100%;
                        height: auto;
                    }}
                </style>
            </head>
            <body>
            <center>
                <h1>{headerTitle}</h1> 
                <h2>{bookTitle}</h2>
                <div class=""image-container"">
                    <img src=""C:\Users\Jaap\Source\Repos\AIBookEngineDumpCode\Writeyourownbooktest\bin\Debug\net8.0\{imagePath}.jpg"" alt=""Inserted Image"">
                </div>
            </center>
            <div style='page-break-after: always;'></div>
            <br /><br /><br /><br />
            <div style=""text-align: center;  background-color: white; padding: 10px; margin: 20px auto; width: 80%;"">
            {firstPageInit}
            </div>
            <div style='page-break-after: always;'></div>
            <div class='text-container'>
       
            </div>
            </body>
            </html>";



            File.AppendAllText(filename, emptyHtmlContent, Encoding.UTF8);
            Console.WriteLine("HTML document created successfully at: " + filename);
            return filename;
        }
        public static List<string> tocTitles = new List<string>();
        public static string tocHead = "\n<div id=\"toc\"><h2>Table of Contents</h2><ul></ul></div>\n";
        public static void AppendToBody(string filePath, string contentToAdd, string successMessage)
        {
            if (!File.Exists(filePath)) return;

            string htmlContent = File.ReadAllText(filePath, Encoding.UTF8);

            // Find the position of the text-container div
            int textContainerIndex = htmlContent.IndexOf("<div class='text-container'>", StringComparison.OrdinalIgnoreCase);
            if (textContainerIndex != -1)
            {
                int tocIndex = htmlContent.IndexOf("<div id=\"toc\">", StringComparison.OrdinalIgnoreCase);
                if (tocIndex == -1)
                {
                    // Insert TOC before the text-container div
                    htmlContent = htmlContent.Insert(textContainerIndex, "\n" +
                        "<div class='text-container'><div id=\"toc\"><h2>Table of Contents</h2><ul></ul></div></div>\n");
                }
            }

            // Process H1 tags for TOC (handling inline styles)
            var matches = Regex.Matches(contentToAdd, "<h1[^>]*>(.*?)</h1>", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            foreach (Match match in matches)
            {
                string headingText = Regex.Replace(match.Groups[1].Value, "<.*?>", "").Trim(); // Remove inner HTML tags
                string anchorId = Regex.Replace(headingText, "[^a-zA-Z0-9]", "_").ToLower();
                string anchorTag = $"<h1 id=\"{anchorId}\" {match.Value.Substring(3)}";

                // Replace original H1 with anchored version
                contentToAdd = contentToAdd.Replace(match.Value, anchorTag);

                // Add TOC entry
                string tocEntry = $"<li><a href=\"#{anchorId}\">{headingText}</a></li>";
                int tocListIndex = htmlContent.IndexOf("<div id=\"toc\"><h2>Table of Contents</h2><ul>", StringComparison.OrdinalIgnoreCase);
                if (tocListIndex != -1)
                {
                    int ulEndIndex = htmlContent.IndexOf("</ul>", tocListIndex, StringComparison.OrdinalIgnoreCase);
                    if (ulEndIndex != -1)
                    {
                        htmlContent = htmlContent.Insert(ulEndIndex, tocEntry + "\n");
                    }
                }
            }

            // Insert content properly before </body>
            int bodyCloseIndex = htmlContent.LastIndexOf("</div>", StringComparison.OrdinalIgnoreCase);
            if (bodyCloseIndex != -1)
            {
                htmlContent = htmlContent.Insert(bodyCloseIndex, contentToAdd + Environment.NewLine);
            }
            else
            {
                Console.WriteLine("No </body> tag found. Appending content at the end of the file.");
                htmlContent += contentToAdd + Environment.NewLine;
            }

            File.WriteAllText(filePath, htmlContent, Encoding.UTF8);
            Console.WriteLine(successMessage);
        }



        public static void orgAppendToBody(string filePath, string contentToAdd, string successMessage)
        {
            if (!File.Exists(filePath)) return;

            string htmlContent = File.ReadAllText(filePath, Encoding.UTF8);
            int bodyCloseIndex = htmlContent.LastIndexOf("</div>", StringComparison.OrdinalIgnoreCase);

            if (bodyCloseIndex != -1)
            {
                htmlContent = htmlContent.Insert(bodyCloseIndex, 
                    contentToAdd + Environment.NewLine);
            }
            else
            {
                Console.WriteLine("No </body> tag found. Appending content at the end of the file.");
                htmlContent += contentToAdd + Environment.NewLine;
            }

            File.WriteAllText(filePath,
                htmlContent, Encoding.UTF8);
            Console.WriteLine(successMessage);
        }
    }
    /// <summary>
    /// Convert Html to Pdf
    /// </summary>
    public static class ConvertHmlToPdf
    {
        
        public static void ConvertToPdfAspose(string html, string pdf)
        {
            // Path to input HTML and output PDF
            string htmlPath = html;
            string pdfPath = pdf;

            // Create HTMLLoadOptions
            HtmlLoadOptions options = new HtmlLoadOptions();

            // Load HTML file into Document
            Aspose.Pdf.Document pdfDocument = new Aspose.Pdf.Document(html, options);

            // Save as PDF
            pdfDocument.Save(pdfPath);

            Console.WriteLine("HTML converted to PDF successfully!");
        }
        public static void ConvertToPdf_PdfSharp(string html, string pdf)
        {
            string htmlP = File.ReadAllText(html); // or use hardcoded HTML
            PdfSharpCore.Pdf.PdfDocument pdfP = PdfGenerator.GeneratePdf(htmlP, PdfSharpCore.PageSize.A4);
            pdfP.Save(pdf);

            Console.WriteLine("PDF created successfully.");
        }
        public static void ConvertToPdf_IronPdf(string html, string pdf)
        {
            // Path to your HTML file
            string htmlFilePath = html;
            string pdfPath = pdf;

            // Read the HTML content from file
            string htmlContent = File.ReadAllText(htmlFilePath);

            // Create the renderer
            var renderer = new HtmlToPdf();

            // Convert the HTML to PDF
            var pdfIron = renderer.RenderHtmlAsPdf(htmlContent);

            // Save the PDF
            pdfIron.SaveAs(pdfPath);

            Console.WriteLine("Iron PDF created from HTML file.");
        }
        public static void ConvertToPdf_Dink(string html, string pdf, string _baseUrl)
        {
            // Path to your HTML file
            string htmlFilePath = html;

            // Read HTML content
            string htmlContent = File.ReadAllText(htmlFilePath);

            // Optional: Base URL so relative image paths can be resolved
            string baseUrl = _baseUrl;


            var renderer = new ChromePdfRenderer();

            renderer.RenderingOptions = new ChromePdfRenderOptions
            {
                EnableJavaScript = true                     
            };

            // Convert HTML to PDF
            var pdfDink = renderer.RenderHtmlAsPdf(htmlContent);

            // Save the PDF
            pdfDink.SaveAs(pdf);

            Console.WriteLine("Dink PDF with images created.");
        }
    }
    public static class GetPromptVars
    {
        private static string dataFilePath = GlobalBlobber.readFileFromBlob("Cbookdata.txt", "mindscriptedconfig");

        public static string MainHtmlImageTop { get; set; } = "";
        public static string TitleBook { get; set; } = "";
        public static string FirstPageInitiation { get; set; } = "";
        public static string MainHeaderTitleOfBook { get; set; } = "";
        public static string HeaderTitleOfBook { get; set; } = "";
        public static string NameOfBook { get; set; } = "";
        public static string PageNumbersOfBook { get; set; } = "";
        public static string FileNameBlob { get; set; } = "";

        public static async Task LoadDataGenericPromptVars(string fileName = "Cbookdata.txt")
        {
            string[] lines = await GlobalBlobber.ReadLinesFromBlobAsync(
                Secrets.cloudStorageConnString,
                "mindscriptedconfig",
                fileName
            );

            // Assign safely based on line count
            if (lines.Length > 0) MainHtmlImageTop = lines[0];
            if (lines.Length > 1) TitleBook = lines[1];
            if (lines.Length > 2) FirstPageInitiation = lines[2];
            if (lines.Length > 3) MainHeaderTitleOfBook = lines[3];
            if (lines.Length > 4) NameOfBook = lines[4];
            if (lines.Length > 5) PageNumbersOfBook = lines[5];
            if (lines.Length > 5) FileNameBlob = lines[6];
        }

        public static string TitlePrefix { get; private set; } = "";
        public static string ImagePrefix { get; private set; } = "";
        public static string FirstForePrompt { get; private set; } = "";
        public static string SecondRunningPrompt { get; private set; } = "";
        public static string ExtraTouch { get; private set; } = "";

        private static bool _promptDataLoaded = false;

        public static async Task LoadDataDocHtmlPromptVars(string fileName = "Cdochtml.txt")
        {
            if (_promptDataLoaded) return;

            string[] lines = await GlobalBlobber.ReadLinesFromBlobAsync(
                Secrets.cloudStorageConnString,
                "mindscriptedconfig",
                fileName
            );

            if (lines.Length > 0) TitlePrefix = lines[0];
            if (lines.Length > 1) ImagePrefix = lines[1];
            if (lines.Length > 2) FirstForePrompt = lines[2];
            if (lines.Length > 3) SecondRunningPrompt = lines[3];
            if (lines.Length > 4) ExtraTouch = lines[4];

            _promptDataLoaded = true;
        }
        public static string BookDescription { get; private set; } = "";
        public static string BookPlotLine { get; private set; } = "";
        public static string SteerPlot { get; private set; } = "";
        public static string SteeringWriters { get; private set; } = "";
        public static string BookSteeringWheelUniverse { get; private set; } = "";

        private static bool _plotDataLoaded = false;

        public static async Task LoadPlotDataDocHtmlPlotVars(string fileName = "Pdochtml.txt")
        {
            if (_plotDataLoaded) return;

            try
            {
                string[] lines = await GlobalBlobber.ReadLinesFromBlobAsync(
                    Secrets.cloudStorageConnString,
                    "mindscriptedconfig",
                    fileName
                );

                if (lines.Length > 0) BookDescription = lines[0].Trim();
                if (lines.Length > 1) BookPlotLine = lines[1].Trim();
                if (lines.Length > 2) SteerPlot = lines[2].Trim();
                if (lines.Length > 3) SteeringWriters = lines[3].Trim();
                if (lines.Length > 4) BookSteeringWheelUniverse = lines[4].Trim();

                _plotDataLoaded = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading plot config from blob: " + ex.Message);
            }
        }
    }
    /// <summary>
    /// Provides methods to translate text to a specified language.
    /// </summary>
    public static class Translator
    {
        /// <summary>
        /// The subscription key required to authenticate API requests.
        /// This key is used for interacting with various services and APIs that require a subscription for access.
        /// Typically, the subscription key is a unique string provided by the service provider.
        /// </summary>
        private static readonly string subscriptionKey = Secrets.subscriptionKey;

        /// <summary>
        /// The endpoint for accessing the translation API service.
        /// </summary>
        private static readonly string endpoint = Secrets.enddpoint;

        /// <summary>
        /// Represents the region information required for making API calls to the translation service.
        /// This value is used as the subscription region in the HTTP request headers when
        /// interacting with the translation API.
        /// </summary>
        private static readonly string location = Secrets.llocation;

        /// <summary>
        /// Translates the provided text to the language specified in the global settings.
        /// </summary>
        /// <param name="inputText">The text to be translated.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the translated text.</returns>
        public static async Task<string> TranslateTextToGiven(string inputText, string _language)
        {
            string route = "/translate?api-version=3.0&from=en&to=" + _language;

            object[] body = new object[] { new { Text = inputText } };
            var requestBody = JsonConvert.SerializeObject(body);

            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage())
            {
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(endpoint + route);
                request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                request.Headers.Add("Ocp-Apim-Subscription-Key", subscriptionKey);
                request.Headers.Add("Ocp-Apim-Subscription-Region", location);

                HttpResponseMessage response = await client.SendAsync(request);
                string result = await response.Content.ReadAsStringAsync();
                var translationResult = JsonConvert.DeserializeObject<TranslationResult[]>(result);
                return translationResult[0].Translations[0].Text;
            }
        }

        /// <summary>
        /// Represents the result of a translation operation.
        /// </summary>
        private class TranslationResult
        {
            /// <summary>
            /// Gets or sets the translation results from the API response.
            /// </summary>
            public Translation[] Translations { get; set; }
        }

        /// <summary>
        /// Represents a translation result with the translated text.
        /// </summary>
        private class Translation
        {
            /// <summary>
            /// Gets or sets the text content used in translation results.
            /// </summary>
            /// <value>
            /// A string representing the translated text.
            /// </value>
            public string Text { get; set; }
        }
    }

}


