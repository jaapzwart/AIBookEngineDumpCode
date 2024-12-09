
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Drawing;
using Newtonsoft.Json; // Ensure you have Newtonsoft.Json installed
using OpenAI_API.Completions;
using Writeyourownbooktest;
using static IronPython.Modules.PythonDateTime;

////////////////////////////////////////////////////////////////////////////////////////////////////
/// <summary>   A create thriller book titles. </summary>
///
/// <remarks>   Shadow, 4/2/2024. </remarks>
////////////////////////////////////////////////////////////////////////////////////////////////////

class CreateThrillerBookTitles
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Gets or sets the chat gpt. </summary>
    ///
    /// <value> The chat gpt. </value>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static string _ChatGPT { get; set; } = "";

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Gets or sets the ai model. </summary>
    ///
    /// <value> The ai model. </value>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static string _ai_model { get; set; } = "";

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// (Immutable) HttpClient is intended to be instantiated once and re-used throughout the life of
    /// an application.
    /// </summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    private static readonly HttpClient client = new HttpClient();

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Gets or sets the topic. </summary>
    ///
    /// <value> The topic. </value>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static string _topic { get; set; } = "";

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Gets or sets the chapters. </summary>
    ///
    /// <value> The chapters. </value>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static int _chapters { get; set; } = 0;

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Gets or sets the paragraphs. </summary>
    ///
    /// <value> The paragraphs. </value>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static int _paragraphs { get; set; } = 0;

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Gets or sets from where. </summary>
    ///
    /// <value> from where. </value>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static string _fromWhere { get; set; } = "";

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Gets or sets the words. </summary>
    ///
    /// <value> The words. </value>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static string _words { get; set; } = "";

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Gets or sets the characters. </summary>
    ///
    /// <value> The characters. </value>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static string _characters { get; set; } = "";
    /// <summary>   The not. </summary>
    public static string nNot = " DO NOT USE the word Chapter or Paragraph in the titles.";

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Gets or sets the words used. </summary>
    ///
    /// <value> The words used. </value>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static string wordsUsed { get; set; } = "";

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Creates the titles. </summary>
    ///
    /// <remarks>   Shadow, 4/2/2024. </remarks>
    ///
    /// <returns>   The new titles. </returns>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static async Task<Dictionary<string, List<string>>> CreateTitles()
    {
        // Set your OpenAI API key here
        string apiKey = _ChatGPT;
        ConfigureHttpClient(apiKey);

        var chapterTitles = await GenerateChapterTitles(_topic, _chapters);
        var chapterParagraphTitles = new Dictionary<string, List<string>>();
        wordsUsed = "";
        int tCount = 1;
        foreach (var chapterTitle in chapterTitles)
        {
            var paragraphTitles = await GenerateParagraphTitles(chapterTitle, _paragraphs, tCount);
            chapterParagraphTitles[chapterTitle] = paragraphTitles;
            tCount++;
        }
        return chapterParagraphTitles;
       
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Configure HTTP client. </summary>
    ///
    /// <remarks>   Shadow, 4/2/2024. </remarks>
    ///
    /// <param name="apiKey">   The API key. </param>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    static void ConfigureHttpClient(string apiKey)
    {
        client.BaseAddress = new Uri("https://api.openai.com/");
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Generates a chapter titles. </summary>
    ///
    /// <remarks>   Shadow, 4/2/2024. </remarks>
    ///
    /// <param name="theme">    The theme. </param>
    /// <param name="count">    Number of. </param>
    ///
    /// <returns>   The chapter titles. </returns>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static async Task<List<string>> GenerateChapterTitles(string theme, int count)
    {
        var prompt = "";
       
        if(_fromWhere.Contains("bible"))
        {
            string sj = await GetChatGPTExtraSmallToken("Create a summary of five lines of this specific bible part: " + _topic);

            var TwoLinesfromFile = GlobalMethods.ReadContentOfFileThreeLinesInVars("sTwoLinesChapterTitlesBible.txt");
            string s1 = TwoLinesfromFile.First();
            string s2 = TwoLinesfromFile[1];
            prompt = s1 + " " + count + " " + s2 + " " + theme + " and considering " + _topic 
                + " based on this summary " +  sj  
                + " but do not mention " + theme + " in the title itself." + nNot;
        }
        else if (_fromWhere.Contains("thriller"))
        {
            var TwoLinesfromFile = GlobalMethods.ReadContentOfFileThreeLinesInVars("sTwoLinesChapterTitlesThriller.txt");
            string s1 = TwoLinesfromFile.First();
            string s2 = TwoLinesfromFile[1];
            string s3 = TwoLinesfromFile[2];
            string s4 = TwoLinesfromFile.Last();
            prompt = s1 +  " " + count + " " + s2 + " " + theme + " " + s4 + " " + s3 + " " + _characters 
                + nNot;
        }
        else
        {
            var TwoLinesfromFile = GlobalMethods.ReadContentOfFileThreeLinesInVars("sTwoLinesChapterTitlesBusiness.txt");
            string s1 = TwoLinesfromFile.First();
            string s2 = TwoLinesfromFile[1];
            string s3 = TwoLinesfromFile[2];
            prompt = s1 + " " + count + " " + s2 + " " + theme + " " + s3 +
                " BUT DO NOT USE WORDS already present in " + wordsUsed + nNot;
        }

        var titles = await GetChatGPTSmallToken(prompt);
        List<string> properTitles = new List<string>();
        int tCount = 1;
        foreach(var item in titles)
        {
            wordsUsed += item;
            properTitles.Add(tCount.ToString() + ":X " + item.Replace(":", " "));
            tCount++;
        }
        return properTitles;
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Generates a paragraph titles. </summary>
    ///
    /// <remarks>   Shadow, 4/2/2024. </remarks>
    ///
    /// <param name="chapterTitle"> The chapter title. </param>
    /// <param name="count">        Number of. </param>
    /// <param name="tCount">       Number of. </param>
    ///
    /// <returns>   The paragraph titles. </returns>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static async Task<List<string>> GenerateParagraphTitles(string chapterTitle, int count, int tCount)
    {
        var prompt = "";
        if (_fromWhere.Contains("bible"))
        {
            string sj = await GetChatGPTExtraSmallToken("Create a summary of five lines of this specific Proverb: " + _topic);

            var TwoLinesfromFile = GlobalMethods.ReadContentOfFileThreeLinesInVars("sTwoLinesChapterTitlesBible.txt");
            string s1 = TwoLinesfromFile.First();
            string s2 = TwoLinesfromFile[1];
            prompt = s1 + " " + count + " " + s2 + " " + _topic + " and " + sj
                + " based around " + chapterTitle
                + " but do not mention " + _topic + " in the title itself. " + nNot;
        }
        else if (_fromWhere.Contains("thriller"))
        {
            var TwoLinesfromFile = GlobalMethods.ReadContentOfFileThreeLinesInVars("sTwoLinesChapterTitlesThriller.txt");
            string s1 = TwoLinesfromFile.First();
            string s2 = TwoLinesfromFile[1];
            string s3 = TwoLinesfromFile[2];
            string s4 = TwoLinesfromFile.Last();
            prompt = s1 + " " + count + " " + s2 + " " + chapterTitle + nNot;
        }
        else
        {
            var TwoLinesfromFile = GlobalMethods.ReadContentOfFileThreeLinesInVars("sTwoLinesChapterTitlesBusiness.txt");
            string s1 = TwoLinesfromFile.First();
            string s2 = TwoLinesfromFile[1];
            string s3 = TwoLinesfromFile[2];
            //prompt = s1 + " " + count + " " + s2  + " " + chapterTitle + " " + s3 +
            //    " BUT DO NOT USE WORDS already present in " + wordsUsed + " and create new words instead related to "
            //    + nNot;
            prompt = s1 + " " + count + " " + s2 + " " + chapterTitle +
               nNot;

        }
        var titles = await GetChatGPTSmallToken(prompt);
        List<string> properTitles = new List<string>();
        int tCountt = 1;
        foreach (var item in titles)
        {
            wordsUsed += item;
            properTitles.Add(tCount.ToString() + ":" + tCountt.ToString() + " " + item.Replace(":", " "));
            tCountt++;
        }
        return properTitles;
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Gets chat gpt extra small token. </summary>
    ///
    /// <remarks>   Shadow, 4/2/2024. </remarks>
    ///
    /// <param name="textToAsk">    The text to ask. </param>
    ///
    /// <returns>   The chat gpt extra small token. </returns>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    private async static Task<string> GetChatGPTExtraSmallToken(string textToAsk)
    {

        try
        {
            var openAI = new OpenAI_API.OpenAIAPI(_ChatGPT);


            CompletionRequest completion = new CompletionRequest();
            completion.Prompt = textToAsk;
            completion.MaxTokens = 3000;
            completion.Model = _ai_model; // Set the model ID for GPT-3.5-turbo
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
    /// <summary>   Gets chat gpt small token. </summary>
    ///
    /// <remarks>   Shadow, 4/2/2024. </remarks>
    ///
    /// <param name="textToAsk">    The text to ask. </param>
    ///
    /// <returns>   The chat gpt small token. </returns>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    private async static Task<List<string>> GetChatGPTSmallToken(string textToAsk)
    {
        List<string> answer = new List<string>();
        try
        {
            var openAI = new OpenAI_API.OpenAIAPI(_ChatGPT);


            CompletionRequest completion = new CompletionRequest();
            completion.Prompt = textToAsk;
            completion.MaxTokens = 1500;
            completion.Model = _ai_model; // Set the model ID for GPT-3.5-turbo
            var result = await openAI.Completions.CreateCompletionAsync(completion);

            if (result != null && result.Completions != null && result.Completions.Count > 0)
            {
                var text = result.Completions[0].Text.Trim(); // Get the text of the first choice
                                                          // Split the text into parts based on '\n'
                var parts = text.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries); // Split by new line
                foreach (var part in parts)
                {
                    answer.Add(GlobalMethods.RemoveDigitsAndNonLetters(part)); // Add each part as a separate item in the list
                }
                return answer;
            }
            else
            {
                answer.Add("No results from BlackBeltBible AI.");
                return answer;
            }
                
        }
        catch (Exception ex)
        {
            answer.Add(ex.Message);
            return answer;
        }
    }
}

////////////////////////////////////////////////////////////////////////////////////////////////////
/// <summary>   Define classes for deserializing the response. </summary>
///
/// <remarks>   Shadow, 4/2/2024. </remarks>
////////////////////////////////////////////////////////////////////////////////////////////////////

public class Choice
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Gets or sets the text. </summary>
    ///
    /// <value> The text. </value>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public string text { get; set; }
}

////////////////////////////////////////////////////////////////////////////////////////////////////
/// <summary>   An open ai response. </summary>
///
/// <remarks>   Shadow, 4/2/2024. </remarks>
////////////////////////////////////////////////////////////////////////////////////////////////////

public class OpenAiResponse
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Gets or sets the choices. </summary>
    ///
    /// <value> The choices. </value>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public List<Choice> choices { get; set; }
}

