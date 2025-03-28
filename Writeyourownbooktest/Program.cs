

using HtmlAgilityPack;
using OpenAI_API.Completions;
using OpenAI_API.Images;
using System.Text;
using System.Text.RegularExpressions;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using Xceed.Document.NET;
using Spire.Doc;
using TheArtOfDev.HtmlRenderer.PdfSharp;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using System.Speech.Synthesis;
using System.Net;
using DocumentFormat.OpenXml.Spreadsheet;
using static System.Reflection.Metadata.BlobBuilder;
using DocumentFormat.OpenXml.Bibliography;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.TextToSpeech.V1;
using Google.Cloud.Translation.V2;
using Google.Protobuf;
using NAudio.Wave;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Writeyourownbooktest;
using OpenAI_API.Moderation;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using DocumentFormat.OpenXml.ExtendedProperties;
using DocumentFormat.OpenXml.Vml;
using Path = System.IO.Path;
using System.Runtime.CompilerServices;
using static Google.Rpc.Context.AttributeContext.Types;
using System.Security.Policy;
using PdfSharp.Pdf;
using HtmlRendererCore.PdfSharp;


using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using DocumentFormat.OpenXml.Math;
using System.Security.Cryptography;
using DocumentFormat.OpenXml.Presentation;
using DocumentFormat.OpenXml.EMMA;
using static Community.CsharpSqlite.Sqlite3;
using DateTime = System.DateTime;
using System.Net.Http.Json;
using NAudio.SoundFont;
using DocumentFormat.OpenXml.Drawing.Charts;
using Microsoft.ML;
using OpenTextSummarizer.Interfaces;
using OpenTextSummarizer;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System.Diagnostics;
using System.Net.NetworkInformation;

using Google.Api;
using Google.Cloud.AIPlatform.V1;
using HuggingFace;
using Newtonsoft.Json;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Google.LongRunning;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using static IronPython.Modules._ast;
using System.Collections.Generic;
using System.Drawing;  // Ensure you have System.Drawing.Common installed via NuGet
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using Aspose.Words;
using Google.Rpc;
using static Google.Cloud.AIPlatform.V1.FunctionCallingConfig.Types;
using static HuggingFace.RecommendedModelIds.Llama2;
using System.Diagnostics.Contracts;
using DocumentFormat.OpenXml.Drawing;
using Microsoft.CognitiveServices.Speech.Diagnostics.Logging;
using Microsoft.ML.Trainers;
using OpenXmlPowerTools.HtmlToWml.CSS;
using OpenXmlPowerTools;
using PdfSharp.Pdf.Content.Objects;
using NAudio.CoreAudioApi;



////////////////////////////////////////////////////////////////////////////////////////////////////
/// <summary>   A program. </summary>
///
/// <remarks>   Shadow, 12/4/2023. </remarks>
////////////////////////////////////////////////////////////////////////////////////////////////////

class Program
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Gets or sets the subject. </summary>
    ///
    /// <value> The subject. </value>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static string _subject { get; set; } = "";

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Gets or sets a value indicating whether this object is from bible. </summary>
    ///
    /// <value> True if from bible, false if not. </value>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static bool _fromBible { get; set; } = false;

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Gets or sets the provider. </summary>
    ///
    /// <value> The v provider. </value>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static int _VProvider { get; set; } = 2; 

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Gets or sets a value indicating whether the speak. </summary>
    ///
    /// <value> True if speak, false if not. </value>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static bool _speak { get; set; } = true;

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Gets or sets the static voice topic. </summary>
    ///
    /// <value> The static voice topic. </value>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static string _staticVoiceTopic { get; set; } = "";

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Gets or sets the ai level. </summary>
    ///
    /// <value> The ai level. </value>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static int _AILevel { get; set; } = 1;

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Gets or sets options for controlling the operation. </summary>
    ///
    /// <value> The parameters. </value>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static string _params { get; set; } = "";

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Gets or sets the topic. </summary>
    ///
    /// <value> The topic. </value>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static string _topic { get; set; } = "";

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Gets or sets the book. </summary>
    ///
    /// <value> The n book. </value>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static int nBook { get; set; } = 0;

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Gets or sets the chapters. </summary>
    ///
    /// <value> The n chapters. </value>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static int nChapters { get; set; } = 0;

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Gets or sets the examples. </summary>
    ///
    /// <value> The n examples. </value>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static int nExamples { get; set; } = 0;

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Gets or sets a value indicating whether the images. </summary>
    ///
    /// <value> True if images, false if not. </value>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static bool nImages { get; set; } = false;

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Gets or sets a value indicating whether the ai topic or user. </summary>
    ///
    /// <value> True if ai topic or user, false if not. </value>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static bool _AITopicOrUser { get; set; } = false;

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Gets or sets the holy book. </summary>
    ///
    /// <value> The holy book. </value>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static string _HolyBook { get; set; } = string.Empty;

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Gets or sets the holy chapter. </summary>
    ///
    /// <value> The holy chapter. </value>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static string _HolyChapter { get; set; } = string.Empty;

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Gets or sets the start chapter. </summary>
    ///
    /// <value> The start chapter. </value>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static int _startChapter { get; set; } = 0;

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Gets or sets the end chapter. </summary>
    ///
    /// <value> The end chapter. </value>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static int _endChapter { get; set; } = 0;

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Gets or sets the holy verse. </summary>
    ///
    /// <value> The holy verse. </value>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static int _HolyVerse { get; set; } = 0;

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Gets or sets the holy extra for subject. </summary>
    ///
    /// <value> The holy extra for subject. </value>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static string _HolyExtraForSubject { get; set; } = "";

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Gets or sets the language. </summary>
    ///
    /// <value> The language. </value>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static string _language { get; set; } = "EN";

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Gets or sets the speed. </summary>
    ///
    /// <value> The speed. </value>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static float _speed { get; set; } = 1.0f;

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Gets or sets the talkfile. </summary>
    ///
    /// <value> The talkfile. </value>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static string _talkfile { get; set; } = ""; // The file to use when we wanna have a talking file

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Gets or sets the doscommand. </summary>
    ///
    /// <value> The doscommand. </value>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static string _doscommand { get; set; } = ""; // To know where we come from

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Gets or sets the publishfile. </summary>
    ///
    /// <value> The publishfile. </value>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static string _publishfile { get; set; } = ""; // For publishing file to blob

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Gets or sets the thriller stuff. </summary>
    ///
    /// <value> The thriller stuff. </value>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static string _thrillerStuff { get; set; } = "";

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Gets or sets the extra summary. </summary>
    ///
    /// <value> The extra summary. </value>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static string _extraSummary { get; set; } = "";

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Gets or sets the title stuff. </summary>
    ///
    /// <value> The title stuff. </value>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static string _titleStuff { get; set; } = "";

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Gets or sets the is thriller. </summary>
    ///
    /// <value> The is thriller. </value>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static string _IsThriller { get; set; } = "no";

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Gets or sets the thriller characters. </summary>
    ///
    /// <value> The thriller characters. </value>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static string _thrillerCharacters { get; set; } = "";

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Gets or sets the summary of previous thriller part. </summary>
    ///
    /// <value> The summary of previous thriller part. </value>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static string _SummaryOfPreviousThrillerPart { get; set; } = "";

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Gets or sets the bbook. </summary>
    ///
    /// <value> The bbook. </value>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static string _Bbook { get; set; } = "";

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Gets or sets the bs verse. </summary>
    ///
    /// <value> The bs verse. </value>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static string _bsVerse { get; set; } = "";

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Gets or sets the prefix. </summary>
    ///
    /// <value> The b prefix. </value>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static string _bPrefix { get; set; } = "";

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Gets or sets the be verse. </summary>
    ///
    /// <value> The be verse. </value>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static string _beVerse { get; set; } = "";

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Gets or sets the paragraphs. </summary>
    ///
    /// <value> The b paragraphs. </value>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static string _bParagraphs { get; set; } = "";

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Gets or sets the last bible chapter. </summary>
    ///
    /// <value> The last bible chapter. </value>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static string _LastBibleChapter { get; set; } = "";

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Gets or sets the summary. </summary>
    ///
    /// <value> The b summary. </value>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static string _bSummary { get; set; } = "";

    public static string _talkfile_Quite { get; set; } = "false";
    public static string _prompt_provider { get; set; } = "ChatGPT"; // Standard ChatGPT so all functionality keeps on working.
    public static string _discuss_answer { get; set; } = "";
    public static string _discuss_answer_double { get; set; } = "";
    public static int _loop_discussion { get; set; } = 0;
    public static string _elaborate { get; set; } = "false";
    public static string _SomeMoreThoughts { get; set; } = "Some more thoughts";
    public static string _Images { get; set; } = "false";
    public static string _Replace_InConclusion { get; set; } = "false";
    public static string _code_blocks { get; set; } = "false";
    public static string _with_perkament { get; set; } = "false";
    public static string _with_bible_letter { get; set; } = "false";

    public static string perkament { get; set; } = "false";
    public static string perkamentOut { get; set; } = "false";
    public static string perkamentOutFinal { get; set; } = "false";
    public static string imagePathQuote { get; set; } = "false";
    public static string outputPath { get; set; } = "false";
    public static string quote { get; set; } = "false";

    public static System.Collections.Generic.Dictionary<char, System.Drawing.Image> _images = 
        new System.Collections.Generic.Dictionary<char, System.Drawing.Image>();

    public static string _first_letter { get; set; } = "Z";

    // Bookvars
    //-----------------------------------
    public static int liness = 0;
    public static string getResponse = "";
    public static string sFore = "";
    public static string bigStory = "";
    public static string sSteeringFirstChapter = "";
    //--------------------------------------

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Main entry-point for this application. </summary>
    ///
    /// <remarks>   Shadow, 12/4/2023. </remarks>
    ///
    /// <param name="args"> An array of command-line argument strings. </param>
    ///
    /// <returns>   A Task. </returns>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    static async Task Main(string[] args)
    {
        List<string> GetSequenceFiles = new List<string>();
        System.Speech.Synthesis.SpeechSynthesizer speechSynthesizer = new System.Speech.Synthesis.SpeechSynthesizer();


        // First, the choices. Ask for speak or the command prompt.

        // Args 0, you will get help
        if (args.Length == 0) // If no commands, show how it should be used.
        {
            if (args.Length < 5)
            {
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "commandsdocumentation.txt");

                try
                {
                    // Check if the file exists
                    if (File.Exists(filePath))
                    {
                        // Open the file for reading
                        using (StreamReader reader = new StreamReader(filePath))
                        {
                            string line;

                            // Read and display each line in the file
                            while ((line = reader.ReadLine()) != null)
                            {
                                Console.WriteLine(line);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("The file 'commanddocumentation.txt' does not exist in the app directory.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }

                return;
            }
        }
        // "scrum" 1 5 1 false false true "Bible" "Psalms" 1 1 1 "" "Bible Psalms - "
        // "publish" 1 5 1 false "Your own title" "NL" "Publish" "Agile - "
        // First part does nothing, dummy.
        // 2 is amount of books.
        // 3 is amount of chapters
        // 4 is examples of same book
        // 5 Images
        // 6 AITopic of User (will AI overwrite subject title or not)
        // 7 Is the list coming from the Bible API (or other api)
        // 8 Holy book title
        // 9 Book from the Holy book
        // 10 Chapter in the book of the holy book
        // 11 Starting Verse
        // 12 End verse (not implemented)
        // 13 Extra string for the subject (e.d. "relate to the Kabbala" for example)
        // 14 The prefix for if we want to publish.
        //    > If empty, no publish
        //    > if filled, the books will be published
        if (args.Length > 5 && !args[0].Contains("talk") && !args[0].Equals("speak") && !args[0].Equals("thriller") && !args[0].Equals("book"))
        {
            // Loop through a file and Make the books. This will create large books.
            Console.WriteLine("This would be a loop through a file and create books per line.");
            // Prep the vars.

            List<string> getVerses = new List<string>();
            string[][] myArray = null;
            TextToSpeechClient client = IniGoogleSound();
            string textToSynthesize = "";
            List<string> listOfFilesForBookConversion = new List<string>();


            if (args[0].Equals("publish"))
            {

            }
            else
            {
                _fromBible = bool.Parse(args[6]);
                _AITopicOrUser = bool.Parse(args[5]);
                _HolyBook = args.Length > 7 ? args[7] : "Bible";
                _HolyChapter = args.Length > 8 ? args[8] : "Psalms";
                _startChapter = args.Length > 9 ? int.Parse(args[9]) : 0;
                _endChapter = args.Length > 10 ? int.Parse(args[10]) : 0;
                _HolyVerse = args.Length > 11 ? int.Parse(args[11]) : 0;
                _HolyExtraForSubject = args.Length > 12 ? args[12] : "";

                // If we give a prefix,w e automatically say that we want to publish.
                if (args[13] != null && args[13].Length >= 2)
                {
                    _publishfile = args[13]; // Prefix for the Blob and internet page.
                    _doscommand = "batch"; // We want to write to blob
                }
                if (args[14] != null)
                {
                    _bParagraphs = args[14]; // Amount of paragraphs.
                }
                if (args[15] != null) // If we want to do more chapters of the Bible book part in one swing
                {
                    _LastBibleChapter = args[15]; // Last Chapter
                }

            }



            // <topic><number of books><Chapters><number of examples per book><Images><AITopicOrUser><FromBible><HolyBook><HolyChapters><HolyVerse>
            // "Scrum" 1 1 1 false false true "Bible" "Proverbs" 1 1
            if (_fromBible)
            {
                _speak = false;

                List<string> chapterLooper = new List<string>();
                for (int i = _startChapter; i <= Convert.ToInt16(_LastBibleChapter); i++)
                {
                    chapterLooper = AnswersBible(_HolyChapter, i, _endChapter, _HolyVerse);
                    foreach (var item in chapterLooper)
                        getVerses.Add(item);
                }

                List<string> AddExtraSubjectString = new List<string>();
                foreach (var item in getVerses)
                {
                    string pattern = @"\d+:\d+";

                    // Find all matches of the pattern in the input string
                    MatchCollection matches = Regex.Matches(item, pattern);

                    foreach (Match match in matches)
                    {
                        // Split the match on ':' to get two numbers
                        string[] numbers = match.Value.Split(':');

                        if (numbers.Length == 2)
                        {
                            // Get the last number and convert it to an integer
                            if (int.TryParse(numbers[1], out int lastNumber))
                            {
                                if (lastNumber >= _HolyVerse && lastNumber <= _endChapter) // Take specific verses
                                    AddExtraSubjectString.Add(item + " " + _HolyExtraForSubject);
                                else if (_HolyVerse < 1 && _endChapter < 1) // Take all verses
                                    AddExtraSubjectString.Add(item + " " + _HolyExtraForSubject);

                            }
                        }
                    }
                }
                getVerses.Clear();
                getVerses = AddExtraSubjectString;

                myArray = new string[getVerses.Count][];


                int w = 0;
                foreach (var item in getVerses)
                {
                    myArray[w] = new string[] { getVerses[w], args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString() };
                    w += 1;
                }
                if (_speak)
                {
                    textToSynthesize = "Got the Bible stuff from the cloud.";
                    GlobalMethods.DoSpeak(client, textToSynthesize);
                    Console.WriteLine("Got the Bible stuff from the cloud.");
                }
            }
            else // We want a book published to blob and the internet.
            {
                // "publish" 1 5 1 false "Your own title" "NL" "Publish" "Agile - "
                _language = args[6];
                myArray = new string[1][];
                myArray[0] = new string[] { args[5], args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString() };
                _publishfile = args[8]; // Prefix for the Blob and internet page.
                _doscommand = "batch"; // We want to write to blob
                _AITopicOrUser = true; // We want more books on the given title
                _bParagraphs = args[9]; // How many paragraphs do we want to have in the book chapters?
                _speak = bool.Parse(args[10]); // Do we wanna have speech? 
            }

            string bookSubject = "";
            int numberOfTopics = 0;
            int numberOfChapters = 0;
            int numberOfBooksPerTitle = 0;
            bool withImages = false;

            if (_speak)
            {
                textToSynthesize = "Start making the content files.";
                GlobalMethods.DoSpeak(client, textToSynthesize);

                textToSynthesize = "I will prepare the content files now.";
                GlobalMethods.DoSpeak(client, textToSynthesize);
                Console.WriteLine("ready");
            }
            // Access and print elements from each row
            for (int i = 0; i < myArray.Length; i++)
            {
                Console.WriteLine($"Row {i + 1}:");
                for (int j = 0; j < myArray[i].Length; j++)
                {
                    Console.WriteLine($"    Element {j + 1}: {myArray[i][j]}");
                    int k = j + 1;
                    if (k.Equals(1))
                        bookSubject = myArray[i][j];
                    if (k.Equals(2))
                        numberOfTopics = int.Parse(myArray[i][j]);
                    if (k.Equals(3))
                        numberOfChapters = int.Parse(myArray[i][j]);
                    if (k.Equals(4))
                        numberOfBooksPerTitle = int.Parse(myArray[i][j]);
                    if (k.Equals(5))
                        withImages = bool.Parse(myArray[i][j]);
                }

                _subject = bookSubject;

                // Make the books
                GetSequenceFiles.Add(_subject.ToLower());
            }

            if (_speak)
            {
                textToSynthesize = "It's time to create the content files.";
                GlobalMethods.DoSpeak(client, textToSynthesize);
            }


            listOfFilesForBookConversion = await MakeBookWithVariableStrings(
                GlobalMethods.DeleteFirstNumber(bookSubject), numberOfTopics, numberOfChapters,
                    numberOfBooksPerTitle, _AITopicOrUser, GetSequenceFiles, "Book");

            textToSynthesize = "Before I continue creating the books, please check the files.";
            GlobalMethods.DoSpeak(client, textToSynthesize);
            ConsoleKeyInfo keyInfo;
            keyInfo = Console.ReadKey();

            string returnMessage = "";
            int cList = listOfFilesForBookConversion.Count;
            returnMessage = await MakeTheBooks(listOfFilesForBookConversion, "Beginner", withImages);

            // Say goodbye.
            if (_speak)
            {
                if (_VProvider.Equals(1))
                {
                    speechSynthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult, 3, new System.Globalization.CultureInfo("en-US"));
                    speechSynthesizer.Speak("It's my pleasure to inform you that the books are created.");
                    speechSynthesizer.Speak("Till next time my dear friend..");
                }
                else
                {
                    textToSynthesize = "It's my pleasure to inform you that the books are created.";
                    GlobalMethods.DoSpeak(client, textToSynthesize);
                    textToSynthesize = "Till next time my dear friend..";
                    GlobalMethods.DoSpeak(client, textToSynthesize);
                }
            }
            Console.WriteLine("Ready writing books");
            GetSequenceFiles.Clear();
        }
        // Do the make file for one file given at the dosprompt.
        else if (args.Length >= 2 && args[0].Equals("file"))
        {
            // Create a list to store file names
            List<string> fileNames = new List<string>();
            try
            {
                // TODO: We want to make it also possible to do a batch file with content txt files.
                string bookSubject = args[1];
                _publishfile = args[2];

                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                string credentialsPath = basePath + bookSubject;
                _doscommand = "batch"; // We want to publish the file.


                if (args[3] != null && args[3].Contains("folder")) // More file from a folder
                {
                    string targetFolder = args[4]; // Replace with the actual folder name

                    // Combine the base directory with the target folder path
                    string folderPath = Path.Combine(basePath, targetFolder);

                    // Check if the target folder exists
                    if (Directory.Exists(folderPath))
                    {
                        // Get all files in the target folder
                        string[] files = Directory.GetFiles(folderPath);

                        // Add each file's name to the list
                        foreach (string filePath in files)
                        {
                            string fileName = Path.GetFileName(filePath);
                            fileNames.Add(basePath + @"work\" + fileName);
                        }

                    }
                    else
                    {
                        Console.WriteLine("Target folder does not exist.");
                    }
                }
                else // Just one file
                {
                    List<string> listOfFilesForBookConversion = new List<string> { credentialsPath };
                    var returnMessage = await MakeTheBooks(listOfFilesForBookConversion, "Beginner", false);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            string returnM = await MakeTheBooks(fileNames, "Beginner", false);
        }
        else if (args[0] != null && args[0].Equals("thriller"))
        {
            string bookSubject = args[1];
            int numberOfTopics = int.Parse(args[2]);
            int numberOfChapters = int.Parse(args[3]);
            int numberOfBooksPerTitle = int.Parse(args[4]);
            bool withImages = bool.Parse(args[5]);
            _subject = bookSubject;
            _AITopicOrUser = true;



            // Make the books
            List<string> listOfFilesForBookConversion = await MakeBookWithVariableStringsThriller(bookSubject, numberOfTopics, numberOfChapters,
                numberOfBooksPerTitle, true, null, "Thriller"
                , "Perry Rhodan", "10");

            _doscommand = "batch";
            var returnMessage = await MakeTheBooks(listOfFilesForBookConversion, "Beginner", withImages);
        }
        // "book"
        // Book.txt must be present in root (content of book to be 'rewritten')
        // chapter.txt will be written
        else if (args[0] != null && args[0].Equals("book"))
        {
            string _phrase = "";
            string _publishFile = "";
            string _prefix = "";
            string _typeOfBook = "";

            if (args.Length == 2)
            {
                _phrase = args[1];
            }
            else if (args.Length == 3)
            {
                _phrase = args[1];
                _publishFile = args[2];
            }
            if (args.Length == 4)
            {
                _phrase = args[1];
                _publishFile = args[2];
                _prefix = args[3];
            }
            if (args.Length == 5)
            {
                _phrase = args[1];
                _publishFile = args[2];
                _prefix = args[3];
                _typeOfBook = args[4];
            }
            if (args.Length == 6)
            {
                _phrase = args[1];
                _publishFile = args[2];
                _prefix = args[3];
                _typeOfBook = args[4];
                _language = args[5];
            }
            string appPath = AppDomain.CurrentDomain.BaseDirectory;
            string totalString = "";
            string filePath = "Book.txt"; // Replace with your file path
            string filePathWork = "BookWork.html"; // Replace with your file path
            string theFile = appPath + filePath;
            List<string> newBook = new List<string>();
            List<string> oldBook = new List<string>();
            string chapterTitlesPath = "ChapterTitles.txt";
            string theChapters = appPath + chapterTitlesPath;
            List<string> sTitles = File.ReadAllLines(theChapters).ToList();
            string ChapterPath = "chapter.html"; // Replace with your file path
            try
            {
                GlobalMethods.AddLineFeedsToFile(filePath);
                //List<string> lines = GlobalMethods.ReadAndSplitTextFromFile(filePathWork);
                List<string> lines = GlobalMethods.SplitOnBR(filePathWork);

                int cLines = 0;
                string memory = "";
                string memSum = "";
                string cChapter = "";

                // Print the lines
                foreach (string line in lines)
                {
                    Console.WriteLine($"{line}");
                    //// Define a regular expression pattern to match double empty lines
                    //string pattern = @"\n\s*\n";

                    //// Replace double empty lines with a single empty line
                    //string result = Regex.Replace(line, pattern, "\n\n");

                    //// Replace double carriage returns with a single carriage return
                    //string result2 = Regex.Replace(result, pattern, "\r\n");
                    //oldBook.Add(result2);

                    //// Define a regular expression pattern to match double carriage returns
                    //pattern = "\r\n\r\n";
                    bool nameExists = false;
                    foreach (string title in sTitles)
                    {
                        if (line.Trim().Contains(title))
                        {
                            nameExists = true;
                            break;
                        }
                    }
                    if (nameExists)
                    {
                        string rr = line;
                        newBook.Add(RemoveNonLettersForBook(rr));
                        GlobalMethods.AppendTextToFile(appPath + ChapterPath, "********************************************************************************************\n");
                        GlobalMethods.AppendTextToFile(appPath + ChapterPath, rr);
                        GlobalMethods.AppendTextToFile(appPath + ChapterPath, "********************************************************************************************\n");
                        totalString += "<h1>" + rr + "</h1>";
                    }
                    else
                    {
                        if (cLines <= 1)
                        {

                        }
                        else
                        {
                            memory = line;
                        }
                        string rr = "";
                        string ll = "";

                        string apiKey = Secrets._apiTextAnalysisKey;

                        string endpoint = Secrets._urlTextAnalysis;

                        string adjustedline = line;

                        rr = await GetChatGPTExtraSmallToken("Analyze this text:" + adjustedline + ", and change the text conform these instructions " +
                                       _phrase + " As a " +
                                       "continuation of " + memory + "<br><br>");



                        string rrr = EndHTMLTags(rr);
                        rr = rrr;

                        HtmlDocument doc = new HtmlDocument();
                        doc.LoadHtml(rr);

                        // Find all the <table> elements
                        var tables = doc.DocumentNode.SelectNodes("//table");

                        if (tables != null)
                        {
                            foreach (var table in tables)
                            {
                                // Check if the table has a closing </table> tag
                                if (!table.OuterHtml.Contains("</table>"))
                                {
                                    // Add the closing </table> tag
                                    table.InnerHtml += "</table>";
                                }
                            }
                        }

                        // Get the repaired HTML
                        string repairedHtml = doc.DocumentNode.OuterHtml;
                        rr = repairedHtml;

                        doc = new HtmlDocument();
                        doc.LoadHtml(rr);

                        // Find all the <ul> elements
                        var ulElements = doc.DocumentNode.SelectNodes("//ul");

                        if (ulElements != null)
                        {
                            foreach (var ul in ulElements)
                            {
                                // Check if the <ul> element has a closing </ul> tag
                                if (!ul.OuterHtml.Contains("</ul>"))
                                {
                                    // Add the closing </ul> tag
                                    ul.InnerHtml += "</ul>";
                                }
                            }
                        }

                        // Get the repaired HTML
                        repairedHtml = doc.DocumentNode.OuterHtml;
                        //string finalHtml = $"<div style=\"font-family: 'Courier New', monospace; font-size: 14px; font-weight: normal;\">{repairedHtml}</div>";
                        //rr = finalHtml;

                        rr = repairedHtml;

                        //string removeUnclosed = GlobalMethods.RemoveUnclosedHtmlTags(rr);
                        //rr = removeUnclosed;

                        doc = new HtmlDocument();
                        doc.LoadHtml(rr);

                        adjustedline = await GlobalMethods.AnalyzeAndHighlightLeadingWords(rr, apiKey, endpoint);
                        rr = adjustedline;

                        var emphasizedText = GlobalMethods.EmphasizeImportantWords(rr);
                        rr = emphasizedText;

                        // Ensure proper structure for tables
                        GlobalMethods.EnsureProperTableStructure(doc);

                        // Ensure proper structure for unordered lists
                        GlobalMethods.EnsureProperListStructure(doc);

                        // Get the repaired HTML
                        rr = doc.DocumentNode.OuterHtml;


                        newBook.Add(RemoveNonLettersForBook(rr));

                        if (_language.Equals("NLL") || _language.Equals("NL")) // What if we wanna NL?
                        {
                            TranslationClient cc = InitializeGoogleTranslation();
                            var responseNL = cc.TranslateText(rr, "nl");
                            rr = responseNL.TranslatedText;
                        }

                        // What if Chapter

                        if (_typeOfBook.Length >= 3 && _typeOfBook.Contains("math")) // Check type of book on math
                        {
                            rr = EndHTMLTags(rr);

                            string lline = line;
                            if (line.Contains("Chapter:") && line.Contains("**"))
                            {
                                totalString += "<br>" +
                                  "<span style=\"font-size: 12pt; font-family: Tahoma; font-weight: normal;\">" +
                                  "<h1>" + line + "</h1>" +
                                  "</span>" + "<hr>EXAMPLES<hr>" + rr + "<hr>";
                                GlobalMethods.AppendTextToFile(appPath + ChapterPath,
                                    "<br>" +
                                    "<span style=\"font-size: 12pt; font-family: Tahoma; font-weight: normal;\">" +
                                    "<h1>" + line + "</h1>" +
                                    "</span>" + "<hr>EXAMPLES<hr>" + rr + "<hr>");
                                Console.WriteLine("<br>" + line + "<h3>EXAMPLES<h3>" + rr + "\n\n");
                            }
                            if (line.Contains("Paragraph:") && line.Contains("**")) // What if paragraph
                            {
                                totalString += "<br>" +
                                  "<span style=\"font-size: 12pt; font-family: Tahoma; font-weight: normal;\">" +
                                  "<h2>" + line + "</h2>" +
                                  "</span>" + "<hr>EXAMPLES<hr>" + rr + "<hr>";
                                GlobalMethods.AppendTextToFile(appPath + ChapterPath,
                                    "<br>" +
                                    "<span style=\"font-size: 12pt; font-family: Tahoma; font-weight: normal;\">" +
                                    "<h2>" + line + "</h2>" +
                                    "</span>" + "<hr>EXAMPLES<hr>" + rr + "<hr>");
                                Console.WriteLine("<br>" + line + "<h3>EXAMPLES<h3>" + rr + "\n\n");
                            }
                            if ((!line.Contains("Paragraph:") && !line.Contains("**")) && (!line.Contains("Chapter:") && !line.Contains("**"))) // What if not paragraph and chapter
                            {
                                totalString += "<br>" +
                                   "<span style=\"font-size: 12pt; font-family: Tahoma; font-weight: normal;\">" +
                                   line +
                                   "</span>" + "<hr>EXAMPLES<hr>" + rr + "<hr>";
                                GlobalMethods.AppendTextToFile(appPath + ChapterPath,
                                    "<br>" +
                                    "<span style=\"font-size: 12pt; font-family: Tahoma; font-weight: normal;\">" +
                                    line +
                                    "</span>" + "<hr>EXAMPLES<hr>" + rr + "<hr>");
                                Console.WriteLine("<br>" + line + "<h3>EXAMPLES<h3>" + rr + "\n\n");
                            }

                        }
                        else // if not a mathbook, just elaboration on the lines.
                        {

                            if (line.StartsWith("Chapter:") && line.Contains("**"))
                            {
                                totalString += "<br>" +
                                  "<span style=\"font-size: 12pt; font-family: Tahoma; font-weight: normal;\">" +
                                  "<h1>" + rr + "</h1>";
                                GlobalMethods.AppendTextToFile(appPath + ChapterPath,
                                    "<br>" +
                                    "<span style=\"font-size: 12pt; font-family: Tahoma; font-weight: normal;\">" +
                                    "<h1>" + rr + "</h1>");

                            }
                            if (line.StartsWith("Paragraph:") && line.Contains("**")) // What if paragraph
                            {
                                totalString += "<br>" +
                                  "<span style=\"font-size: 12pt; font-family: Tahoma; font-weight: normal;\">" +
                                  "<h2>" + rr + "</h2>";
                                GlobalMethods.AppendTextToFile(appPath + ChapterPath,
                                    "<br>" +
                                    "<span style=\"font-size: 12pt; font-family: Tahoma; font-weight: normal;\">" +
                                    "<h2>" + rr + "</h2>");

                            }
                            if ((!line.Contains("Paragraph:") && !line.Contains("**")) && (!line.Contains("Chapter:") && !line.Contains("**"))) // What if not paragraph and chapter
                            {
                                totalString += "<br>" +
                                   "<span style=\"font-size: 12pt; font-family: Tahoma; font-weight: normal;\">" +
                                   rr + "<hr>";
                                GlobalMethods.AppendTextToFile(appPath + ChapterPath,
                                    "<br>" +
                                    "<span style=\"font-size: 12pt; font-family: Tahoma; font-weight: normal;\">" +
                                    rr + "<hr>");

                            }
                        }
                        Console.WriteLine("<br>" + rr + "\n\n");
                        cLines++;
                    }

                    try
                    {
                        // Build up some memory
                        memory = "";
                        if (cLines > 5)
                        {
                            // When there are more than 5 lines, use the last five lines
                            memory += lines[cLines - 3];
                            memory += lines[cLines - 2];
                            memory += lines[cLines - 1];
                            memory += lines[cLines];
                        }
                        else if (cLines == 4)
                        {
                            // When there are exactly 4 lines
                            memory += lines[cLines - 3];
                            memory += lines[cLines - 2];
                            memory += lines[cLines - 1];
                            memory += lines[cLines];
                        }
                        else if (cLines == 3)
                        {
                            // When there are exactly 3 lines
                            memory += lines[cLines - 2];
                            memory += lines[cLines - 1];
                            memory += lines[cLines];
                        }
                        else if (cLines == 2)
                        {
                            // When there are exactly 2 lines
                            memory += lines[cLines - 1];
                            memory += lines[cLines];
                        }
                        else if (cLines == 1)
                        {
                            // When there is exactly 1 line
                            memory += lines[cLines];
                        }

                        memSum = await GetChatGPTExtraSmallToken("Create a a short summary of:" + memory);
                        memory = memSum.ToString();
                        memSum = "";

                    }
                    catch (Exception e) { }

                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found.");
            }
            catch (IOException)
            {
                Console.WriteLine("An error occurred while reading the file.");
            }

            // we want to publish to website
            if (args.Length >= 10)
            {
                string fName = _prefix + _publishFile + ".html";
                string doBlob = "";
                if (_prefix.Length > 0 && _prefix.Contains("Bible - ")) // First parts of the Bible
                {
                    doBlob = await GlobalMethods.writeFileToBlob(totalString
                       , GlobalMethods.DeleteFirstNumber(fName).Replace("\"", ""),
                       @"https://dailybiblestorage.blob.core.windows.net/aibookengine/", "aibookengine");
                }
                else if (_prefix.Length > 0 && _prefix.Contains("Bible -- ")) // Second parts of the Bible
                {
                    doBlob = await GlobalMethods.writeFileToBlob(totalString
                       , GlobalMethods.DeleteFirstNumber(fName).Replace("\"", ""),
                       @"https://dailybiblestorage.blob.core.windows.net/aibookengine2/", "aibookengine2");
                }
                else // No Bible books
                {
                    doBlob = await GlobalMethods.writeFileToBlob(totalString
                       , GlobalMethods.DeleteFirstNumber(fName).Replace("\"", ""),
                       @"https://dailybiblestorage.blob.core.windows.net/aibookengine3/", "aibookengine3");
                }

            }

        }
        // <program> "voicebook"
        // Reading a book and speak the content out loud.
        else if (args[0] != null && args[0].Equals("voicebook"))
        {
            string textToSynthesize = "";
            TextToSpeechClient client = IniGoogleSound();
            _language = args[1];
            _AILevel = 3;
            float speed = 0.85f;
            try
            {
                textToSynthesize = "It's my pleasure to read a book for you.";

                if (_speak)
                {
                    if (_language.Equals("NLL"))
                    {
                        TranslationClient cc = InitializeGoogleTranslation();
                        var responseNL = cc.TranslateText(RemoveNonLettersForTalk(textToSynthesize), "nl");
                        textToSynthesize = responseNL.TranslatedText;
                        GlobalMethods.DoSpeakNL(client, textToSynthesize, speed);
                    }
                    else if (_language.Equals("DE"))
                    {
                        TranslationClient cc = InitializeGoogleTranslation();
                        var responseDE = cc.TranslateText(RemoveNonLettersForTalk(textToSynthesize), "de");
                        textToSynthesize = responseDE.TranslatedText;
                        GlobalMethods.DoSpeakDE(client, textToSynthesize, speed);
                    }
                    else
                        GlobalMethods.DoSpeakUSMail(client, textToSynthesize, speed);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Argruments error:" + ex.Message);
                Environment.Exit(0);

            }

            string appPath = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = "Bookvoice.txt"; // Replace with your file path
            string theFile = appPath + filePath;
            List<string> newBook = new List<string>();
            List<string> oldBook = new List<string>();
            string chapterTitlesPath = "ChapterTitles.txt";
            string theChapters = appPath + chapterTitlesPath;
            List<string> sTitles = File.ReadAllLines(theChapters).ToList();
            string ChapterPath = "chapter.txt"; // Replace with your file path
            try
            {
                List<string> lines = GlobalMethods.ReadAndSplitTextFromFile(filePath);


                // Print the lines
                foreach (string line in lines)
                {
                    Console.WriteLine($"{line}");
                    // Define a regular expression pattern to match double empty lines
                    string pattern = @"\n\s*\n";

                    // Replace double empty lines with a single empty line
                    string result = Regex.Replace(line, pattern, "\n\n");

                    // Replace double carriage returns with a single carriage return
                    string result2 = Regex.Replace(result, pattern, "\r\n");
                    oldBook.Add(result2);

                    // Define a regular expression pattern to match double carriage returns
                    pattern = "\r\n\r\n";
                    bool nameExists = false;
                    foreach (string title in sTitles)
                    {
                        if (line.Trim().Contains(title))
                        {
                            nameExists = true;
                            break;
                        }
                    }
                    if (nameExists)
                    {
                        string rr = line;
                        textToSynthesize = "   .:Chapter, " + rr;

                        if (_speak)
                        {
                            if (_language.Equals("NLL"))
                            {
                                TranslationClient cc = InitializeGoogleTranslation();
                                var responseNL = cc.TranslateText(RemoveNonLettersForTalk(textToSynthesize), "nl");
                                textToSynthesize = responseNL.TranslatedText;
                                GlobalMethods.DoSpeakNL(client, textToSynthesize, speed);
                            }
                            else if (_language.Equals("DE"))
                            {
                                TranslationClient cc = InitializeGoogleTranslation();
                                var responseDE = cc.TranslateText(RemoveNonLettersForTalk(textToSynthesize), "de");
                                textToSynthesize = responseDE.TranslatedText;
                                GlobalMethods.DoSpeakDE(client, textToSynthesize, speed);
                            }
                            else
                                GlobalMethods.DoSpeakUSMail(client, textToSynthesize, speed);
                        }

                    }
                    else
                    {
                        if (_speak)
                        {
                            if (_language.Equals("NLL"))
                            {
                                TranslationClient cc = InitializeGoogleTranslation();
                                var responseNL = cc.TranslateText(RemoveNonLettersForTalk(line), "nl");
                                textToSynthesize = responseNL.TranslatedText;
                                GlobalMethods.DoSpeakNL(client, textToSynthesize, speed);
                            }
                            else
                                GlobalMethods.DoSpeakUSMail(client, line, speed);
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found.");
            }
            catch (IOException)
            {
                Console.WriteLine("An error occurred while reading the file.");
            }
            textToSynthesize = "Finished reading. Till next time my dear friend.";
            GlobalMethods.DoSpeakUSMail(client, textToSynthesize, 0.80f);
        }
        // Only the word "batch" needs to be given.
        // Subject WILL be overwritten.
        // It will read a text file called FileBatch.txt line by line.
        // "Agile_Coach" 1 2 1 false (line format in the file)
        // param 1 = subject (unerscores needed)
        // 2 amount of book, always put on 1
        // 3 Amount of chapters, can be whatever you want, do under 23
        // 4 amount of same books on the topic (content will be different)
        // 5 images
        else if ((args[0] != null) && (args[0].Equals("batch") || args[0].Equals("batchvar")))
        {
            List<string> getVerses = new List<string>();
            string[][] myArray = null;
            TextToSpeechClient client = IniGoogleSound();
            string textToSynthesize = "";

            if (args[0].Equals("batchvar"))
                _AITopicOrUser = true;

            string appPath = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = "FileBatch.txt"; // Replace with your file path
            string theFile = appPath + filePath;
            List<string> lines = new List<string>();

            string filenamefromcommandline = "";

            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        lines.Add(line);
                    }
                    myArray = new string[lines.Count][];
                }

                string _subject = "";
                int _books = 0;
                int _chapters = 0;
                int _examples = 0;
                bool _images = false;
                int w = 0;

                foreach (var item in lines)
                {
                    //string[] parameters = item.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    string[] parameters = item.Split("\" \"");

                    if (parameters.Length == 6)
                    {
                        _subject = parameters[0].Replace("_", " ");
                        _books = int.Parse(parameters[1]);
                        _chapters = int.Parse(parameters[2]);
                        _examples = int.Parse(parameters[3]);
                        _images = bool.Parse(parameters[4].Replace("\"", ""));
                        _language = args[5];
                    }
                    if (parameters.Length == 13)
                    {
                        if (parameters[6].Equals("Publish"))
                        {
                            _subject = parameters[0].Replace("_", " ");
                            _books = int.Parse(parameters[1]);
                            _chapters = int.Parse(parameters[2]);
                            _examples = int.Parse(parameters[3]);
                            _images = bool.Parse(parameters[4].Replace("\"", ""));
                            _language = parameters[5];

                            _publishfile = parameters[7];
                            _doscommand = "batch";
                            _thrillerStuff = parameters[8];
                            _extraSummary = parameters[9];
                            _titleStuff = parameters[10].Replace("\"", "");
                            _IsThriller = parameters[11].Replace("\"", ""); // We go for making the content file for a thriller?
                            _bParagraphs = parameters[12].Replace("\"", ""); // How many paragraphs
                        }
                        else
                        {
                            Console.Write("Wrong command.");
                            Environment.Exit(0);
                        }
                    }
                    string _subjectt = _subject;

                    // Make the books
                    GetSequenceFiles.Add(_subjectt.ToLower());

                }

                if (_speak)
                {
                    textToSynthesize = "It's time to create the content files.";
                    GlobalMethods.DoSpeak(client, textToSynthesize);
                }

                List<string> listOfFilesForBookConversion = new List<string>();
                listOfFilesForBookConversion = await MakeBookWithVariableStrings(
                    GlobalMethods.DeleteFirstNumber(_subject), _books, _chapters,
                        _examples, _AITopicOrUser, GetSequenceFiles, "Book");

                if (_speak)
                {
                    textToSynthesize = "Before I continue creating the books, please check the files.";
                    GlobalMethods.DoSpeak(client, textToSynthesize);
                }
                ConsoleKeyInfo keyInfo;
                keyInfo = Console.ReadKey();

                string returnMessage = "";
                int cList = listOfFilesForBookConversion.Count;
                returnMessage = await MakeTheBooks(listOfFilesForBookConversion, "Beginner", false);

                // Say goodbye.
                if (_speak)
                {
                    if (_VProvider.Equals(1))
                    {
                        speechSynthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult, 3, new System.Globalization.CultureInfo("en-US"));
                        speechSynthesizer.Speak("It's my pleasure to inform you that the books are created.");
                        speechSynthesizer.Speak("Till next time my dear friend..");
                    }
                    else
                    {
                        textToSynthesize = "It's my pleasure to inform you that the books are created.";
                        GlobalMethods.DoSpeak(client, textToSynthesize);
                        textToSynthesize = "Till next time my dear friend..";
                        GlobalMethods.DoSpeak(client, textToSynthesize);
                    }
                }
                Console.WriteLine("Ready writing books");
                GetSequenceFiles.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }

            if (_speak)
            {
                textToSynthesize = "File done, lines:" + lines.Count.ToString();
                GlobalMethods.DoSpeak(client, textToSynthesize);
            }
            Console.WriteLine("File done, lines:" + lines.Count.ToString());
        }
        else if (args[0] != null && args[0].Contains("convertDocxToHtml"))
        {
            try
            {
                string appPath = AppDomain.CurrentDomain.BaseDirectory;
                string filePath = appPath + "talkfilebook_20250315203125834.docx";
                string fileHtml = appPath + "talkfilebook_20250315203125834.html";
                ConvertWordToHtml.ConvertWToHtml(filePath, fileHtml);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error converter:" + ex.Message);
            }
        }
        else if (args[0] != null && args[0].Contains("talkBookConvertHtmlToPdf"))
        {
            string appPath = AppDomain.CurrentDomain.BaseDirectory;
            string filename = "book_20250323223005401";
            string chapterTitlesPathHtml = filename + ".html";
            string chapterTitlesPathPdf = filename + ".pdf";
            string outputFilePathHtml = appPath + chapterTitlesPathHtml;
            string outputFilePathPdf = appPath + chapterTitlesPathPdf;
            ConvertHmlToPdf.ConvertToPdfAspose(outputFilePathHtml, outputFilePathPdf);
        }
        else if (args[0] != null && args[0].Contains("talkBookComplete"))
        {
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
                iimage = GlobalMethods.GetSubStringForImages("##Create a Isaac Asimov Caves of Steel geometry mathematical oriented SF image", "##");
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
                makingImage = "Create a Isaac Asimov Caves of Steel geometry mathematical oriented SF image ";
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
                string getResponse = "";
                string getSummary = "";
                string sFore = "";
                string bigStory = "";
                #endregion

                string sPrevious = "";
                string line = "";
                for(int i = 0; i < lines.Count; i++)
                {
                    sFore = lines[i].ToString();
                    line = sFore;
                    
                    #region Create Image in the lines
                    // Prep quote
                    // 
                    if(_examples.Contains("doclearn"))
                    {
                        iimage = GlobalMethods.GetSubStringForImages(line,
                            "Write an exciting long elaborated detailed book chapter about Microsoft AI 900 exam prep on the title – ");
                    }
                    if (_examples.Contains("doclonghtml"))
                    {
                        iimage = GlobalMethods.GetSubStringForImages(line,
                            "Write an exciting long elaborated detailed book chapter about Microsoft AI 900 exam prep on the title – ");
                    }
                    if(_examples.Contains("dochtml"))
                    {
                       
                        iimage = GlobalMethods.GetSubStringForImages(line,
                           "Write an extensive and detailed book chapter in the style of Isaac Asimovs The Caves of Steel and The Robots of Dawn. The chapter must be large and immersive, featuring richly developed characters with nuanced psychological depth. Include intelligent, thought-provoking dialogue that explores complex social, ethical, or technological themes. The interactions between characters should be subtle, sharp, and layered with tension or unspoken motives, leading to unforeseen twists and turns in the narrative. Incorporate vivid and atmospheric descriptions of futuristic urban or planetary settings—sprawling Cities, Spacer environments, or high-tech interiors—grounded in Asimovs clean, minimalistic prose. Ensure that the tone reflects the sociological, investigative, and philosophical essence of Asimovs Robot Series. Write this chapter on the title – ");
                    }
                    sClean =
                            iimage.Replace(":", "-").Replace(",", "").Replace("?", "").Replace("!", "")
                            .Replace("\"", "").Replace(";", "");
                    getQuote = await GetChatGPTSmallToken("Create a catchy smart quote on " + sClean);
                    sQuote = GlobalMethods.CleanStringBeforeFirstQuote(getQuote);
                    imagePath = "";

                    // Do image
                    //
                    if (_examples.Contains("dochtml"))
                    {
                        makingImage = "Create an Isaac Asimoc Caves of Steel geometry mathematical oriented SF image on the title - ";
                    }
                    if (_examples.Contains("doclonghtml"))
                    {
                        makingImage = "Create an artificial intelligence image on the topic - ";
                    }
                    if (_examples.Contains("doclearn"))
                    {
                        makingImage = "Create a mathematical Artificial Intelligence oriented image on the topic - ";
                    }
                    Simage = await GetDalleGood(makingImage
                               + sQuote);
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
                    #endregion

                    #region Append Titles in the lines
                    // Write title of chapter
                    // 
                    if (_examples.Contains("doclearn"))
                    {
                        HtmlGenerator.AppendToBody(outputFilePathHtml, "<div style='page-break-after: always;'></div>", "Quoted text added successfully.");
                        HtmlGenerator.AppendHeaderToHtml(outputFilePathHtml, iimage, "h1", "Tahoma");
                    }
                    else if (_examples.Contains("doclonghtml"))
                    {
                        HtmlGenerator.AppendToBody(outputFilePathHtml, "<div style='page-break-after: always;'></div>", "Quoted text added successfully.");
                        HtmlGenerator.AppendHeaderToHtml(outputFilePathHtml, iimage, "h1", "Tahoma");
                    }
                    else if(_examples.Contains("dochtml"))
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
                    if (_examples.Contains("doclearn")) // When we do a knowledge book
                    {
                        imagePath = appPath + sClean + ".jpg";
                        HtmlGenerator.AppendImageToHtml(outputFilePathHtml, imagePath);
                        getQuote = await GetChatGPTSmallToken("Create a catchy smart intelligent thought provoking quote of ONE LINE on: " + sClean);
                        sQuote = GlobalMethods.CleanStringBeforeFirstQuote(getQuote);
                        HtmlGenerator.InsertQuotedText(outputFilePathHtml, getQuote, true, true, "white", false, "black", "Garamond", 22);
                    }
                    else if (_examples.Contains("doclonghtml"))
                    {
                        imagePath = appPath + sClean + ".jpg";
                        HtmlGenerator.AppendImageToHtml(outputFilePathHtml, imagePath);
                        getQuote = await GetChatGPTSmallToken("Create a catchy smart intelligent thought provoking quote of ONE LINE on: " + sClean);
                        sQuote = GlobalMethods.CleanStringBeforeFirstQuote(getQuote);
                        HtmlGenerator.InsertQuotedText(outputFilePathHtml, getQuote, true, true, "white", false, "black", "Garamond", 22);
                    }
                    else if(_examples.Contains("dochtml"))
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

                    #region Determine the chapters
                    // Line specifics
                    // 

                    if (_examples.Contains("doclonghtml"))
                    {
                        List<string> sForPlot = new List<string>();
                        string sForOrg = sFore;
                        if (liness >= 0)
                        {
                            sForPlot.Add(lines[i + 1].ToString());
                            sForPlot.Add(lines[i + 2].ToString());
                            sForPlot.Add(lines[i + 3].ToString());
                            sForPlot.Add(lines[i + 4].ToString());
                            sForPlot.Add(lines[i + 5].ToString());
                            sForPlot.Add(lines[i + 6].ToString());
                            i += 6;
                            int iLine = 1;
                            string sPlotters = "";
                            foreach (string sLine in sForPlot)
                            {
                                if (liness >= 1)
                                {
                                    sFore += "  and write on this plotline " +
                                    sLine +
                                    " and build further on " + sPrevious +
                                    "Write an extensive elaborate long professional chapter on AI 900 and use html lists and tables to create a readable format. Us inline examples.";
                                    sPrevious = sPlotters;
                                }
                                else
                                {
                                    sFore += "  and write on this plotline " +
                                    sLine + bookPlot +
                                    " and build further on " + sPlotters +
                                    " Write an extensive elaborate long professional chapter on AI 900 and use html lists and tables to create a readable format. Use inline examples.";



                                }
                                string front = "Make sure the text is put in an easy to read overview. Like this:"
                                + "<h3>Introduction</h3><font face=\"Arial\" size=\"3\">content</font>"
                                + "<h3>paragraph title</h3><font face=\"Arial\" size=\"3\">content</font>"
                                + "<h3>Example</h3><font face=\"Arial\" size=\"3\">content</font>"
                                + "<h3>Tips</h3><font face=\"Arial\" size=\"3\">content</font>"
                                + "<h3>Conclusion</h3><font face=\"Arial\" size=\"3\">content</font>"
                                 + " and use HTML TABLES and HTML LISTS when needed to even add more structure to the content."
                                + "Keep the font the same size and as the body font."
                                + "<p>paragraph</p>"
                                + " but do not mention the chapter number and title at the start of the chapter.";

                                getResponse = await LargeGPT.CallLargeChatGPT(sFore + front, "o1") + "\n\n";
                                getResponse.Replace(sForOrg + sLine, "");
                                sPlotters += getResponse;
                                sFore = sForOrg;

                                if (iLine == 1)
                                {
                                    // Writing text and quote
                                    getQuote = await GetChatGPTSmallToken("Create a catchy smart intelligent thought provoking quote on: " + sClean);
                                    sQuote = GlobalMethods.CleanStringBeforeFirstQuote(getQuote);
                                    HtmlGenerator.InsertQuotedText(outputFilePathHtml, sQuote, false, true, "white", false, "black", "Garamond", 22);
                                }
                                else
                                {
                                    HtmlGenerator.AppendToBody(outputFilePathHtml, "<div style='page-break-after: always;'></div>", "Quoted text added successfully.");
                                }
                                HtmlGenerator.AppendBoldTextToHtml(outputFilePathHtml, sLine, false, "Arial", 20);
                                HtmlGenerator.AppendTextToHtmlDocument(outputFilePathHtml, getResponse, "Arial", 14);
                                iLine += 1;
                            }
                            sPrevious = sPlotters;
                        }
                        
                       
                    }
                    else if(_examples.Contains("dochtml"))
                    {
                        if (liness >= 1)
                        {
                            sFore += " and continue the story naturally from the previous chapter: " +
                                getResponse +
                                ". Make it a thought-provoking continuation, rich in narrative complexity and emotional subtlety. " +
                                "Ensure the dialogue between characters is sharp, intelligent, and layered with hidden motives and psychological nuance. " +
                                "Reveal character intentions gradually through voice, pacing, and body language—tension should simmer beneath the surface. " +
                                "Include unexpected twists grounded in personal or sociopolitical dilemmas that echo the themes of identity, fear, and societal control. " +
                                "Describe characters’ physical presence, posture, and movement in a way that enhances emotional impact. " +
                                "Build the scenes vividly in the futuristic, urbanized, stratified world of *The Caves of Steel*, incorporating enclosed cityscapes, artificial lighting, and mechanized routines. " +
                                "Use clean, elegant prose inspired by Asimov’s style to maintain authenticity while deepening complexity.";
                        }
                        else
                        {
                            sFore += " and base this first chapter around the plot: " +
                                bookPlot +
                                ". Begin with an immersive, psychological narrative set in the universe of *The Caves of Steel*. " +
                                "Craft a strong, intelligent opening with dialogue that reveals more than it says—characters should carry secrets, prejudices, fears, and hopes. " +
                                "Explore the underlying tensions between humans and robots, urban claustrophobia, and class divisions. " +
                                "Describe each setting—corridors, dwellings, transportation systems, and surveillance mechanisms—with crisp, atmospheric clarity. " +
                                "Characters should be introduced with detailed attention to facial expression, body posture, and emotional restraint or conflict. " +
                                "Allow for surprises in character behavior that hint at deeper philosophical or ethical debates consistent with Asimov’s world. " +
                                "Use minimalistic yet evocative language to create the distinctive tone of an Earth bound by steel and suspicion.";
                        }
                        sFore += " Ensure the chapter balances narrative momentum with deep philosophical undercurrents, evoking questions of humanity, logic, and moral ambiguity.";


                    }
                    else if (_examples.Contains("doclearn")) // Educational book
                    {
                        if (liness >= 1)
                        {
                            sFore += " and Continue the educational learning chapter about Mirosoft AI-900 Exam Prep based on the previous chapter " +
                            getResponse +
                            " and make it a natural continuation"
                            + " and make it a thought provoking educational intelligent chapter about Microsoft AI-900 Exam Prep with" +
                            " many inline examples and formulas." +
                            "Use examples from other literature reviews and examples from real life in organizations." +
                            " Write as a Microsoft AI-900 expert teacher and base all content on the content found in the AI-900 Exam Prep.";
                        }
                        else
                        {
                            sFore += " and base this first educational elaborate extensive very long learning chapter about Microsoft AI-900 around the plot - "
                                + bookPlot
                                + " and make it a thought provoking educational intelligent elaborate extensive very long chapter about Microsoft AI-900 Exam Prep with" +
                                " many inline examples." +
                                "Use examples from other literature reviews and examples from real life in organizations." +
                                " Write as a Microsoft AI-900 expert teacher and base all content on the content found in the AI-900 Exam Prep.";
                        }
                    }
                    else
                    {

                    }
                    #endregion

                    #region Write the chapter content in the lines
                    if (_examples.Contains("doclearn"))
                    {
                        string front = "Make sure the text is put in an easy to read overview."
                            + "Like this:"
                            + "<h3>Introduction</h3><font face=\"Arial\" size=\"3\">content</font>"
                            + "<h3>paragraph title</h3><font face=\"Arial\" size=\"3\">content</font>"
                            + "<h3>Example</h3><font face=\"Arial\" size=\"3\">content</font>"
                            + "<h3>Tips</h3><font face=\"Arial\" size=\"3\">content</font>"
                            + "<h3>Conclusion</h3><font face=\"Arial\" size=\"3\">content</font>"
                            + " and use html tables and lists when needed to even add more structure to the content."
                            + "Keep the font the same size and as the body font."
                            + "<p>paragraph</p>"
                            + " but do not mention the chapter number and title at the start of the chapter.";

                        getResponse = await LargeGPT.CallLargeChatGPT(front + sFore, "o1") + "\n\n";
                        //getResponse = await LargeGPT.GetGrok(front + sFore) + "\n\n";
                        //Console.WriteLine("\n\n" + "CHAPTER TEXT" + "\n\n" + getResponse);

                        getResponse.Replace(line, "");

                        // Writing text and quote
                        getQuote = await GetChatGPTSmallToken("Create a catchy smart intelligent thought provoking quote on: " + sClean);
                        sQuote = GlobalMethods.CleanStringBeforeFirstQuote(getQuote);
                        HtmlGenerator.InsertQuotedText(outputFilePathHtml, sQuote, false, true, "white", false, "black", "Garamond", 22);

                        HtmlGenerator.AppendBoldTextToHtml(outputFilePathHtml, "The Theory", false, "Arial", 20);
                        HtmlGenerator.AppendTextToHtmlDocument(outputFilePathHtml, getResponse, "Arial", 14);

                        string sForeExample = getResponse;
                        front = "Give extensive examples with elaborative long text based on the previous part."
                            + "Like this:"
                            + "<h3>Introduction</h3><font face=\"Arial\" size=\"3\">content</font>"
                            + "<h3>paragraph title</h3><font face=\"Arial\" size=\"3\">content</font>"
                            + "<h3>Example</h3><font face=\"Arial\" size=\"3\">content</font>"
                            + "<h3>Tips</h3><font face=\"Arial\" size=\"3\">content</font>"
                            + "<h3>Conclusion</h3><font face=\"Arial\" size=\"3\">content</font>"
                            + " and use html tables and lists when needed to even add more structure to the content."
                            + "Keep the font the same size and as the body font."
                            + "<p>paragraph</p>"
                            + " but do not mention the chapter number and title at the start of the chapter."
                            + " Build further with elaborate detailed examples on this part:" + sForeExample;

                        getResponse = await LargeGPT.CallLargeChatGPT(front + sForeExample, "o1") + "\n\n";

                        HtmlGenerator.AppendToBody(outputFilePathHtml, "<div style='page-break-after: always;'></div>", "Quoted text added successfully.");
                        HtmlGenerator.AppendBoldTextToHtml(outputFilePathHtml, "Examples", false, "Arial", 20);

                        // Writing text and quote
                        getQuote = await GetChatGPTSmallToken("Create a catchy smart intelligent thought provoking quote on: " + sClean);
                        sQuote = GlobalMethods.CleanStringBeforeFirstQuote(getQuote);
                        HtmlGenerator.InsertQuotedText(outputFilePathHtml, sQuote, false, true, "white", false, "black", "Garamond", 22);
                        HtmlGenerator.AppendTextToHtmlDocument(outputFilePathHtml, getResponse, "Arial", 14);


                    }
                    else if(_examples.Contains("dochtml"))
                    {
                        string front = "Make sure the text is put in an easy to read overview. Like this:"
                            + "<p>paragraph</p>"
                            + " but do not mention the chapter number and title at the start of the chapter.";

                        getResponse = await LargeGPT.CallLargeChatGPT(front + sFore, "o1") + "\n\n";
                        //getResponse = await LargeGPT.GetGrok(front + sFore) + "\n\n";
                        //Console.WriteLine("\n\n" + "CHAPTER TEXT" + "\n\n" + getResponse);

                        getResponse.Replace(line, "");

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
                }
                ConvertHmlToPdf.ConvertToPdfAspose(outputFilePathHtml, outputFilePathPdf);
                //ConvertHmlToPdf.ConvertToPdf_Dink(outputFilePathHtml, outputFilePathPdf, appPath);
                byte[] pdfBytes = File.ReadAllBytes(outputFilePathPdf);
                string result = await GlobalMethods.WritePdfToBlobAsync(pdfBytes, "ASIMOV - Steel and Stars - The Aurora Paradox.pdf", "mindscripted");
                Console.WriteLine("PDF upload to Blob:" + result);
                //HtmlGenerator.AppendClosingHtmlTags("output.html");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:" + ex.Message);
            }
           
        }
        else if (args[0] != null && args[0].Contains("PdfUploadToBlob"))
        {
            string appPath = AppDomain.CurrentDomain.BaseDirectory;
            string chapterTitlesPathPdf = "AI - Microsoft AI-900 Exam Prep - AN AI Perspective" + ".pdf";
            string outputFilePathPdf = appPath + chapterTitlesPathPdf;
            Console.WriteLine("Starting PDF logic.");
            try
            {
                byte[] pdfBytes = File.ReadAllBytes(outputFilePathPdf);
                string result = await GlobalMethods.WritePdfToBlobAsync(pdfBytes, "AI - Microsoft AI-900 Exam Prep - AN AI Perspective.pdf", "mindscripted");
                Console.WriteLine("PDF upload to Blob:" + result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        else if(args[0] != null && args[0].Contains("ConvertHtmlToPdfAndUpload"))
        {
            string appPath = AppDomain.CurrentDomain.BaseDirectory;
            // Create the Word document
            string chapterTitlesPathHtml = "Perry rhodan the shadow fractal" + ".html";
            string chapterTitlesPathPdf = "Perry rhodan the shadow fractal" + ".pdf";
            string outputFilePathHtml = appPath + chapterTitlesPathHtml;
            string outputFilePathPdf = appPath + chapterTitlesPathPdf;
            Console.WriteLine("Starting PDF logic.");
            try
            {
                ConvertHmlToPdf.ConvertToPdfAspose(outputFilePathHtml, outputFilePathPdf);
                Console.WriteLine("Pdf converted, starting the upload to blob");
                byte[] pdfBytes = File.ReadAllBytes(outputFilePathPdf);
                string result = await GlobalMethods.WritePdfToBlobAsync(pdfBytes, "RHODAN - NC 1 - 1.The Shadow Fractal.pdf", "mindscripted");
                Console.WriteLine("PDF upload to Blob:" + result);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        // "talk" "subject" "US" 0.85 3
        // "talkfile" (reads the file Filetalk.txt) and saves output to a file.
        else if (args[0] != null && args[0].Contains("talk"))
        {
            if (args[0].Equals("talk"))
            {
                // "talk" "subject" "US" 0.85 3
                string question = args[1];
                _speed = float.Parse(args[3]);
                _language = args[2];
                _AILevel = int.Parse(args[4]);
                _VProvider = 2;
                CheckLevelOfAIAnswer(speechSynthesizer,
                "Not implemented level 1 AI",
                "Not implemented level 2 AI",
                question);
            }
            else if (args[0].Equals("talkfile")) // Speaks out the subject from a file and save  answers to a file.
            {
                // Bookvars
                //-----------------------------------
                liness = 0;
                getResponse = "";
                sFore = "";
                bigStory = "";
                //--------------------------------------

                string appPath = AppDomain.CurrentDomain.BaseDirectory;
                string filePath = "FileTalk.txt"; // Replace with your file path
                List<string> lines = new List<string>();
                _language = args[1];
                _talkfile_Quite = args[2];
                _prompt_provider = args[3];
                _Images = args[4];
                _elaborate = args[5];
                _Replace_InConclusion = args[6];

                string filename = System.DateTime.Now.ToString("yyyyMMddHHmmssfff");
                string chapterTitlesPath = "talkfile_conversation" + filename + ".docx";
                //string chapterTitlesPath = "talkfile_conversation20250302001811548.docx";
                _talkfile = appPath + chapterTitlesPath;
                string cc = GlobalMethods.CreateWordDocument(chapterTitlesPath);

                _loop_discussion = 100;
                _Replace_InConclusion = "true";

                try
                {
                    // Read all lines from the file
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            // Add each line to the list
                            lines.Add(line);
                        }
                    }

                    string repeatedString = new string('#', 50);

                    // Before the question string !!!
                    string talkfilePrefix = "FileTalkPrefix.txt";
                    string _talkfilePrefix = appPath + talkfilePrefix;
                    string questionFront = "";
                    string makingImage = "";
                    string firstPartOfTextWhenElaborate = "";
                    string secondPartOfTextWhenElaborate = "";
                    string secondQuestionFromFile = "";
                    string foreWordFromFile = "";
                    string introductionFromFile = "";
                    string afterWordFromFile = "";

                    if (File.Exists(_talkfilePrefix))
                    {
                        // Open the file and read the first line
                        using (StreamReader sr = new StreamReader(_talkfilePrefix))
                        {
                            questionFront = sr.ReadLine();
                            Console.WriteLine("First line: " + questionFront);
                            makingImage = sr.ReadLine();
                            Console.WriteLine("Second line: " + makingImage);
                            firstPartOfTextWhenElaborate = sr.ReadLine();
                            Console.WriteLine("Third line: " + firstPartOfTextWhenElaborate);
                            secondPartOfTextWhenElaborate = sr.ReadLine();
                            Console.WriteLine("Fourth line: " + secondPartOfTextWhenElaborate);
                            secondQuestionFromFile = sr.ReadLine();
                            Console.WriteLine("Fifth line: " + secondQuestionFromFile);
                            foreWordFromFile = sr.ReadLine();
                            Console.WriteLine("Sixth line: " + foreWordFromFile);
                            introductionFromFile = sr.ReadLine();
                            Console.WriteLine("Seventh line: " + introductionFromFile);
                            afterWordFromFile = sr.ReadLine();
                            Console.WriteLine("Eight line: " + afterWordFromFile);
                            sSteeringFirstChapter = sr.ReadLine();
                            Console.WriteLine("Nine line: " + sSteeringFirstChapter);
                        }
                    }
                    else
                    {
                        Console.WriteLine("File not found: " + _talkfilePrefix);
                    }
                    if (_elaborate.Contains("true"))
                    {
                        // Foreword
                        Console.WriteLine(repeatedString + '\n');
                        Console.WriteLine("Creating Foreword...");
                        GlobalMethods.AppendHeaderToWordExtendedWithPageBreak(_talkfile, "ForeWord", "Heading 1", "Time New Roman");
                        string foreword = await GetChatGPTExtraSmallToken(foreWordFromFile);

                        GlobalMethods.AppendTextToWordDocumentCorrectFormatSplit(_talkfile, foreword, "Times New Roman", 12);
                        Console.WriteLine("Created Foreword...");
                        Console.WriteLine(repeatedString + '\n');

                        // Introduction
                        Console.WriteLine(repeatedString + '\n');
                        Console.WriteLine("Creating Introduction...");
                        GlobalMethods.AppendHeaderToWordExtendedWithPageBreak(_talkfile, "Introduction", "Heading 1", "Times New Roman");
                        string introduction = await GetChatGPTExtraSmallToken(introductionFromFile);
                        GlobalMethods.AppendTextToWordDocumentCorrectFormatSplit(_talkfile, introduction, "Times New Roman", 12);
                        Console.WriteLine("Created Introduction...");
                        Console.WriteLine(repeatedString + '\n');

                    }

                    // Optional: Print lines to console for verification

                    foreach (string l in lines)
                    {
                        // Splitting the line into parts
                        string[] parts = l.Split("\" \"");

                        // Assuming the format is always correct and parts length is at least 5

                        string question = parts[1].Trim('"');
                        _speed = float.Parse(parts[3]);
                        _language = parts[2].Trim('"');
                        _AILevel = Convert.ToInt16(parts[4].Replace("\"", ""));

                        // For demonstration, just printing the values
                        Console.WriteLine($"Question: {question.Replace("_", " ")}, Speed: {_speed}, Language: {_language}, AILevel: {_AILevel}");



                        Console.WriteLine(repeatedString + '\n');
                        string shortQ = question.Replace("_", " ").Replace(questionFront, "");
                        GlobalMethods.AppendHeaderToWordExtendedWithPageBreak(_talkfile, shortQ, "Heading 1", "Times New Roman");
                        Console.WriteLine(question.Replace("_", " ") + '\n');
                        Console.WriteLine(repeatedString + '\n');

                        // Quote part
                        string iimage = GlobalMethods.GetSubStringForImages(question,
                            questionFront);
                        string sClean =
                                iimage.Replace(":", "-").Replace(",", "").Replace("?", "").Replace("!", "")
                                .Replace("\"", "").Replace(";", "");
                        string getQuote = await GetChatGPTSmallToken("Create a catchy smart quote on " + sClean);
                        string sQuote = GlobalMethods.CleanStringBeforeFirstQuote(getQuote);
                        string imagePath = "";

                        // If we wanna have images, do so.
                        if (_Images.Contains("true"))
                        {

                            string Simage = await GetDalleGood(makingImage
                                + sQuote);
                            if (Simage.Contains("Bad Request")) // Probably from words and length
                            {
                                Simage = await GetDalleGood(makingImage
                                + sQuote);
                            }
                            await GlobalMethods.GetImageFromURL(Simage, _talkfile, sClean);

                            bool success = false;
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

                            imagePath = appPath + sClean + ".jpg";
                            GlobalMethods.AddImageToWordDocument(_talkfile, imagePath);
                        }
                        GlobalMethods.InsertQuotedText(_talkfile, sQuote, true, false, "White", false, "Black"); // Quote without Page Break

                        string subHeader = "";
                        if (_elaborate.Contains("true"))
                        {
                            subHeader = firstPartOfTextWhenElaborate;
                            GlobalMethods.AppendBoldTextToWord(_talkfile, subHeader, false, "Times New Roman", 16);
                        }
                        getQuote = await GetChatGPTSmallToken("Create a catchy smart intelligent thought provoking quote on: " + sClean);
                        sQuote = GlobalMethods.CleanStringBeforeFirstQuote(getQuote);
                        GlobalMethods.InsertQuotedText(_talkfile, sQuote, false, false, "White", false, "Black", "Garamond", 14); // Quote without Page Break

                        CheckLevelOfAIAnswer(speechSynthesizer,
                            "Not implemented level 1 AI",
                            "Not implemented level 2 AI",
                            question.Replace("_", " "));

                        if (_elaborate.Contains("true"))
                        {
                            bool do200 = true;
                            if (_loop_discussion.Equals(100))
                            {
                                subHeader = secondPartOfTextWhenElaborate;
                                GlobalMethods.AppendBoldTextToWord(_talkfile, subHeader, true, "Times New Roman", 16);
                                getQuote = await GetChatGPTSmallToken("Create a catchy smart intelligent thought provoking quote on: " + sClean);
                                sQuote = GlobalMethods.CleanStringBeforeFirstQuote(getQuote);
                                GlobalMethods.InsertQuotedText(_talkfile, sQuote, false, false, "White", false, "Black", "Garamond", 14); // Quote without Page Break

                                string secondQuestion =
                                        secondQuestionFromFile + sClean;
                                secondQuestion = secondQuestion.Replace("\n", "");

                                //_code_blocks = "true";
                                CheckLevelOfAIAnswer(speechSynthesizer,
                                    "Not implemented level 1 AI",
                                    "Not implemented level 2 AI",
                                    secondQuestion.Replace("_", " "));
                                //_code_blocks = "false";

                                do200 = false;
                            }
                        }
                    }

                    if (_elaborate.Contains("true"))
                    {
                        // Afterword
                        Console.WriteLine(repeatedString + '\n');
                        Console.WriteLine("Creating Afterword...");
                        GlobalMethods.AppendHeaderToWordExtendedWithPageBreak(_talkfile, "Afterword", "Heading 1", "Times New Roman");
                        string afterword = await GetChatGPTExtraSmallToken(afterWordFromFile);
                        GlobalMethods.AppendTextToWordDocumentCorrectFormatSplit(_talkfile, afterword, "Times New Roman", 12);
                        Console.WriteLine("Created Afterword...");
                    }

                }
                catch (IOException e)
                {
                    Console.WriteLine("An error occurred while reading the file:");
                    Console.WriteLine(e.Message);
                }

            }
            else if (args[0].Equals("talkold")) // Speaks out the subject from a file and save  answers to a file.
            {

                string appPath = AppDomain.CurrentDomain.BaseDirectory;
                string filePath = "FileTalk.txt"; // Replace with your file path
                List<string> lines = new List<string>();
                _language = args[1];
                _talkfile_Quite = args[2];
                _prompt_provider = args[3];
                _Images = args[4];
                _elaborate = args[5];
                _Replace_InConclusion = args[6];

                string filename = System.DateTime.Now.ToString("yyyyMMddHHmmssfff");
                string chapterTitlesPath = "talkfile_conversation" + filename + ".docx";
                //string chapterTitlesPath = "talkfile_conversation20240720215142404.docx";
                _talkfile = appPath + chapterTitlesPath;
                string cc = GlobalMethods.CreateWordDocument(chapterTitlesPath);

                // Load the alphabet images
                _images = GlobalMethods.LoadAlphabetImages(appPath);

                // Display the loaded images count
                Console.WriteLine($"Loaded {_images.Count} images.");

                //string sStyle = "Write in the style of high-class British English Shakespeare literature and ";
                string sStyle = "Write cunning, witty, intelligent, thought provoking and ";
                string repeatedString = new string('#', 50);

                // Foreword
                Console.WriteLine(repeatedString + '\n');
                Console.WriteLine("Creating Foreword...");
                GlobalMethods.AppendHeaderToWordExtendedWithPageBreak(_talkfile, "ForeWord", "Heading 1");
                string foreword = await GetChatGPTExtraSmallToken(
                    sStyle + "Create a foreword without using the name foreword on the subject of the influence of the Philosophy of Plato on the Philosophy of the world development after his time.");

                char firstChar = GlobalMethods.GetFirstCharacter(foreword);
                string remainingString;
                System.Drawing.Image image;
                GlobalMethods.ExtractFirstCharacter(foreword, out firstChar, out remainingString);

                // Retrieve the corresponding image from the dictionary
                if (_images.TryGetValue(firstChar, out image))
                {
                    Console.WriteLine($"Image for '{firstChar}' found.");
                    string appPathh = AppDomain.CurrentDomain.BaseDirectory;
                    GlobalMethods.AddImageToWordDocumentOriginalWrap(_talkfile, appPathh + firstChar + ".jpg", "test",
                        100, 100, "Left");
                    GlobalMethods.AppendTextToWordDocumentCorrectFormatSplit(_talkfile, remainingString);
                }
                else
                {
                    GlobalMethods.AppendTextToWordDocumentCorrectFormatSplit(_talkfile, remainingString);
                }
                Console.WriteLine("Created Foreword...");
                Console.WriteLine(repeatedString + '\n');

                // Introduction
                Console.WriteLine(repeatedString + '\n');
                Console.WriteLine("Creating Introduction...");
                GlobalMethods.AppendHeaderToWordExtendedWithPageBreak(_talkfile, "Introduction", "Heading 1");

                string introduction = await GetChatGPTSmallToken(
                     sStyle + "Create a very large essay as introduction on the subject of the influence of the Philosophy of Plato on the Philosophy of the world development after his time.");

                firstChar = GlobalMethods.GetFirstCharacter(introduction);
                GlobalMethods.ExtractFirstCharacter(introduction, out firstChar, out remainingString);

                //Retrieve the corresponding image from the dictionary
                if (_images.TryGetValue(firstChar, out image))
                {
                    Console.WriteLine($"Image for '{firstChar}' found.");
                    string appPathh = AppDomain.CurrentDomain.BaseDirectory;
                    GlobalMethods.AddImageToWordDocumentOriginalWrap(_talkfile, appPathh + firstChar + ".jpg", "test",
                        170, 170, "Left");
                    GlobalMethods.AppendTextToWordDocumentCorrectFormatSplit(_talkfile, remainingString);
                }
                else
                {
                    GlobalMethods.AppendTextToWordDocumentCorrectFormatSplit(_talkfile, introduction);
                }
                Console.WriteLine("Created Introduction...");
                Console.WriteLine(repeatedString + '\n');
                Console.WriteLine(repeatedString + '\n');


                try
                {
                    // Read all lines from the file
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            // Add each line to the list
                            lines.Add(line);
                        }
                    }

                    // Optional: Print lines to console for verification
                    foreach (string l in lines)
                    {
                        // Splitting the line into parts
                        string[] parts = l.Split("\" \"");

                        // Assuming the format is always correct and parts length is at least 5

                        string question = parts[1].Trim('"');
                        _speed = float.Parse(parts[3]);
                        _language = parts[2].Trim('"');
                        _AILevel = Convert.ToInt16(parts[4].Replace("\"", ""));

                        // For demonstration, just printing the values
                        Console.WriteLine($"Question: {question.Replace("_", " ")}, Speed: {_speed}, Language: {_language}, AILevel: {_AILevel}");


                        string repeatedStringSecond = new string('-', 50);

                        _loop_discussion = 100;
                        int fontSize = 15;
                        string questionFront = "Write a large essay in the context of ancient philosophy on Plato's ";
                        string iimage = GlobalMethods.GetSubStringForImages(question,
                            questionFront);
                        string sClean =
                                iimage.Replace(":", "-").Replace(",", "").Replace("?", "").Replace("!", "")
                                .Replace("\"", "").Replace(";", "").Replace("-", ""); // This we do to create clean image strings.

                        Console.WriteLine(repeatedString + '\n');
                        GlobalMethods.AppendHeaderToWordExtendedWithPageBreak(_talkfile,
                            sClean, "Heading 1");
                        Console.WriteLine(question.Replace("_", " ") + '\n');
                        Console.WriteLine(repeatedString + '\n');

                        string imagePath = "";

                        string sSummary = "Write a short summary of 4 short lines and not more than 320 characters of the essence of this Bible ";


                        string qq = "Give a thought provoking " +
                                        "quote without source for " + sClean;

                        string getQuote = await GetChatGPTSmallToken(qq);

                        string sQuote = GlobalMethods.CleanStringBeforeFirstQuote(getQuote);
                        sQuote = GlobalMethods.CleanStringAfterLastQuote(getQuote);

                        // If we wanna have images, do so.
                        if (_Images.Contains("true"))
                        {

                            string Simage = await GetDalleGood("Create an image from ancient antiquity times around Plato, its architecture and people around "
                                + sQuote);
                            if (Simage.Contains("Bad Request")) // Probably from words and length
                            {
                                Simage = await GetDalleGood("Create an image from ancient antiquity times around Plato, its architecture and people around "
                                + sQuote);
                            }
                            await GlobalMethods.GetImageFromURL(Simage, _talkfile, sClean);

                            bool success = false;
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

                            imagePath = appPath + sClean + ".jpg";
                            GlobalMethods.AddImageToWordDocument(_talkfile, imagePath);
                        }

                        perkament = appPath + "perkament.jpg";
                        perkamentOut = appPath + "perkamentOut2.jpg";
                        perkamentOutFinal = appPath + "perkamentOut.jpg";
                        imagePathQuote = perkament; // Set your image path
                        outputPath = perkamentOut;
                        quote = sQuote;

                        // Quote
                        GlobalMethods.CreateQuoteBoxWithBackground(imagePathQuote, outputPath, sQuote.Replace("\n\n", "")
                            .Replace("\n", ""), fontSize);

                        long quality = 75L;
                        GlobalMethods.LowerImageFileSize(outputPath, perkamentOutFinal, quality);

                        Console.WriteLine($"Image Quote image created at: {outputPath}");
                        GlobalMethods.AddImageToWordDocumentOriginal(_talkfile, perkamentOutFinal, sQuote);

                        using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(_talkfile, true))
                        {
                            GlobalMethods.InsertPageBreak(wordDoc);
                        }

                        //GlobalMethods.AddImageToWordDocumentOverlay(_talkfile, perkamentOut, imagePath);

                        string subHeader = "Analysis of the Title";
                        GlobalMethods.AppendBoldTextToWord(_talkfile, subHeader, false, "Old English Text MT", 20);


                        getQuote = await GetChatGPTSmallToken(qq);
                        sQuote = GlobalMethods.CleanStringBeforeFirstQuote(getQuote);
                        sQuote = GlobalMethods.CleanStringAfterLastQuote(getQuote);

                        // Quote
                        GlobalMethods.CreateQuoteBoxWithBackground(imagePathQuote, outputPath, sQuote.Replace("\n\n", "")
                            .Replace("\n", ""), fontSize);

                        GlobalMethods.LowerImageFileSize(outputPath, perkamentOutFinal, quality);

                        Console.WriteLine($"Image Quote image created at: {outputPath}");
                        GlobalMethods.AddImageToWordDocumentOriginal(_talkfile, perkamentOutFinal, sQuote);
                        GlobalMethods.AddEmptyLineToWordDocument(_talkfile);


                        CompletionRequest completion = new CompletionRequest();

                        question = sStyle + questionFront + sClean;
                        //GlobalMethods.InsertQuotedText(_talkfile, sQuote, false, true, "Black", false, "Black"); // Quote without Page Break

                        //string firstLetter = "Do NOT start your answer with" + _first_letter;

                        _with_bible_letter = "true";
                        CheckLevelOfAIAnswer(speechSynthesizer,
                            "Not implemented level 1 AI",
                            "Not implemented level 2 AI",
                            question.Replace("_", " "));
                        _with_bible_letter = "false";

                        if (_elaborate.Contains("true"))
                        {
                            bool do200 = true;
                            if (_loop_discussion.Equals(100))
                            {
                                subHeader = "Influence on the Development of Thought";
                                GlobalMethods.AppendBoldTextToWord(_talkfile, subHeader, true, "Old English Text MT", 20);


                                getQuote = await GetChatGPTSmallToken(qq);
                                sQuote = GlobalMethods.CleanStringBeforeFirstQuote(getQuote);
                                sQuote = GlobalMethods.CleanStringAfterLastQuote(getQuote);

                                GlobalMethods.CreateQuoteBoxWithBackground(imagePathQuote, outputPath, sQuote.Replace("\n\n", "")
                                    .Replace("\n", ""), fontSize);

                                GlobalMethods.LowerImageFileSize(outputPath, perkamentOutFinal, quality);

                                Console.WriteLine($"Image Quote image created at: {outputPath}");
                                GlobalMethods.AddImageToWordDocumentOriginal(_talkfile, perkamentOutFinal, sQuote);
                                GlobalMethods.AddEmptyLineToWordDocument(_talkfile);

                                string secondQuestion =
                                        @"Give a a medium size essay about the development of the Western Philosophy resulting from  " + sClean +
                                        " and how it was applied by other philosophers with some examples.";
                                secondQuestion = sStyle + secondQuestion.Replace("\n", "");
                                //GlobalMethods.InsertQuotedText(_talkfile, sQuote, false, true, "Black", false, "Black");

                                _with_bible_letter = "true";
                                CheckLevelOfAIAnswer(speechSynthesizer,
                                    "Not implemented level 1 AI",
                                    "Not implemented level 2 AI",
                                     secondQuestion.Replace("_", " "));
                                _with_bible_letter = "false";

                                subHeader = "Shakespeare, A Poem on " + sClean;
                                GlobalMethods.AppendBoldTextToWord(_talkfile, subHeader, true, "Old English Text MT", 20);

                                string shakeSpearQuestion =
                                        @"Give a thought provoking " +
                                        " short Poem Shakespeare style in Rhyme form iambic pentameter. Do not use more than 6 verses about this " + sClean;
                                secondQuestion = sStyle + shakeSpearQuestion.Replace("\n", "");

                                _with_perkament = "true";
                                CheckLevelOfAIAnswer(speechSynthesizer,
                                    "Not implemented level 1 AI",
                                    "Not implemented level 2 AI",
                                     secondQuestion.Replace("_", " "));
                                _with_perkament = "false";

                                do200 = false;
                            }
                            if (do200)
                            {
                                _loop_discussion = 200;
                                string connS = Secrets.cloudStorageConnString;
                                CloudStorageAccount account = CloudStorageAccount.Parse(connS);
                                var blobClient = account.CreateCloudBlobClient();
                                CloudBlobContainer blobContainer = blobClient.GetContainerReference("kentekenccontrole");
                                blobContainer.CreateIfNotExistsAsync();
                                await UploadTextToBlobAsync(blobContainer, "aidiscussion.txt", _discuss_answer);
                                string chunk =
                                    @"Give a deep and thought provoking " +
                                    "thorough analysis from the knowledge of the Kabballah, Mishnah and the Gemara. Write witty, cunning, intelligent and high society British: ";
                                await UploadTextToBlobAsync(blobContainer, "chunkQuestionChatGPT.txt", chunk);
                                CheckLevelOfAIAnswer(speechSynthesizer,
                                "Not implemented level 1 AI",
                                "Not implemented level 2 AI",
                                question.Replace("_", " "));
                                _loop_discussion = 100;
                            }
                        }

                    }
                    // Afterword
                    Console.WriteLine(repeatedString + '\n');
                    Console.WriteLine("Creating Afterword...");
                    GlobalMethods.AppendHeaderToWordExtendedWithPageBreak(_talkfile, "Afterword", "Heading 1");
                    string afterword = await GetChatGPTExtraSmallToken(
                        sStyle + "Create a very large essay as afterthought on the subject of the influence of the Philosophy of Plato on the Philosophy of the world development after his time.");

                    firstChar = GlobalMethods.GetFirstCharacter(afterword);
                    GlobalMethods.ExtractFirstCharacter(afterword, out firstChar, out remainingString);

                    // Retrieve the corresponding image from the dictionary
                    if (_images.TryGetValue(firstChar, out image))
                    {
                        Console.WriteLine($"Image for '{firstChar}' found.");
                        string appPathh = AppDomain.CurrentDomain.BaseDirectory;
                        GlobalMethods.AddImageToWordDocumentOriginalWrap(_talkfile, appPathh + firstChar + ".jpg", "test",
                            100, 100, "Left");
                        GlobalMethods.AppendTextToWordDocumentCorrectFormatSplit(_talkfile, remainingString);
                    }
                    else
                    {
                        GlobalMethods.AppendTextToWordDocumentCorrectFormatSplit(_talkfile, remainingString);
                    }
                    Console.WriteLine("Created Afterword...");
                    GlobalMethods.RemoveEmptyPages(_talkfile);
                    GlobalMethods.RemovePageBreaksOnEmptyPages(_talkfile);
                }
                catch (IOException e)
                {
                    Console.WriteLine("An error occurred while reading the file:");
                    Console.WriteLine(e.Message);
                }


            }
            else if (args[0].Equals("talkbible")) // Speaks out the subject from a file and save  answers to a file.
            {

                string appPath = AppDomain.CurrentDomain.BaseDirectory;
                string filePath = "FileTalk.txt"; // Replace with your file path
                List<string> lines = new List<string>();
                _language = args[1];
                _talkfile_Quite = args[2];
                _prompt_provider = args[3];
                _Images = args[4];
                _elaborate = args[5];
                _Replace_InConclusion = args[6];

                string filename = System.DateTime.Now.ToString("yyyyMMddHHmmssfff");
                //string chapterTitlesPath = "talkfile_conversation" + filename + ".docx";
                string chapterTitlesPath = "talkfile_conversation20250111180318669.docx";
                _talkfile = appPath + chapterTitlesPath;
                //string cc = GlobalMethods.CreateWordDocument(chapterTitlesPath);

                // Load the alphabet images
                _images = GlobalMethods.LoadAlphabetImages(appPath);

                // Display the loaded images count
                Console.WriteLine($"Loaded {_images.Count} images.");

                //string sStyle = "Write in the style of high-class British English Shakespeare literature and ";
                string sStyle = "Write cunning, witty, intelligent, thought provoking and ";
                string repeatedString = new string('#', 50);

                // Foreword
                //Console.WriteLine(repeatedString + '\n');
                //Console.WriteLine("Creating Foreword...");
                //GlobalMethods.AppendHeaderToWordExtendedWithPageBreak(_talkfile, "ForeWord", "Heading 1");
                //string foreword = await GetChatGPTExtraSmallToken(
                //    sStyle + "Create a foreword without calling it a foreword for the title: The Zohar Behind Proverbs Chapter 7 to 9");

                //char firstChar = GlobalMethods.GetFirstCharacter(foreword);
                //string remainingString;
                //GlobalMethods.ExtractFirstCharacter(foreword, out firstChar, out remainingString);

                //// Retrieve the corresponding image from the dictionary
                //if (_images.TryGetValue(firstChar, out System.Drawing.Image image))
                //{
                //    Console.WriteLine($"Image for '{firstChar}' found.");
                //    string appPathh = AppDomain.CurrentDomain.BaseDirectory;
                //    GlobalMethods.AddImageToWordDocumentOriginalWrap(_talkfile, appPathh + firstChar + ".jpg", "test",
                //        100, 100, "Left");
                //    GlobalMethods.AppendTextToWordDocumentCorrectFormatSplit(_talkfile, remainingString);
                //}
                //else
                //{
                //    GlobalMethods.AppendTextToWordDocumentCorrectFormatSplit(_talkfile, remainingString);
                //}
                //Console.WriteLine("Created Foreword...");
                //Console.WriteLine(repeatedString + '\n');

                char firstChar;
                string remainingString;
                System.Drawing.Image image;

                // Introduction

                Console.WriteLine(repeatedString + '\n');
                Console.WriteLine("Creating Introduction...");
                GlobalMethods.AppendHeaderToWordExtendedWithPageBreak(_talkfile, "Introduction", "Heading 1");

                string introduction = await GetChatGPTSmallToken(
                     sStyle + "Create a large essay as introduction for the title: The Zohar Behind the Proverbs Chapters 5 and 6.");

                firstChar = GlobalMethods.GetFirstCharacter(introduction);
                GlobalMethods.ExtractFirstCharacter(introduction, out firstChar, out remainingString);

                //Retrieve the corresponding image from the dictionary
                if (_images.TryGetValue(firstChar, out image))
                {
                    Console.WriteLine($"Image for '{firstChar}' found.");
                    string appPathh = AppDomain.CurrentDomain.BaseDirectory;
                    GlobalMethods.AddImageToWordDocumentOriginalWrap(_talkfile, appPathh + firstChar + ".jpg", "test",
                        170, 170, "Left");
                    GlobalMethods.AppendTextToWordDocumentCorrectFormatSplit(_talkfile, remainingString);
                }
                else
                {
                    GlobalMethods.AppendTextToWordDocumentCorrectFormatSplit(_talkfile, introduction);
                }
                Console.WriteLine("Created Introduction...");
                Console.WriteLine(repeatedString + '\n');
                Console.WriteLine(repeatedString + '\n');


                try
                {
                    /*
                    // Read all lines from the file
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            // Add each line to the list
                            lines.Add(line);
                        }
                    }

                    // Optional: Print lines to console for verification
                    foreach (string l in lines)
                    {
                        // Splitting the line into parts
                        string[] parts = l.Split("\" \"");

                        // Assuming the format is always correct and parts length is at least 5

                        string question = parts[1].Trim('"');
                        _speed = float.Parse(parts[3]);
                        _language = parts[2].Trim('"');
                        _AILevel = Convert.ToInt16(parts[4].Replace("\"", ""));

                        // For demonstration, just printing the values
                        Console.WriteLine($"Question: {question.Replace("_", " ")}, Speed: {_speed}, Language: {_language}, AILevel: {_AILevel}");


                        string repeatedStringSecond = new string('-', 50);

                        _loop_discussion = 100;
                        int fontSize = 15;
                        string questionFront = "Write a large essay in the context of The Torah and Zohar on ";
                        string iimage = GlobalMethods.GetSubStringForImages(question,
                            questionFront);
                        string sClean =
                                iimage.Replace(":", "-").Replace(",", "").Replace("?", "").Replace("!", "")
                                .Replace("\"", "").Replace(";", "").Replace("-", ""); // This we do to create clean image strings.

                        Console.WriteLine(repeatedString + '\n');
                        GlobalMethods.AppendHeaderToWordExtendedWithPageBreak(_talkfile,
                            sClean, "Heading 1");
                        Console.WriteLine(question.Replace("_", " ") + '\n');
                        Console.WriteLine(repeatedString + '\n');

                        string imagePath = "";
                        string onlyProverbs = GlobalMethods.CleanStringAfterLastNumber(sClean);

                        string sSummary = "Write a short summary of 4 short lines and not more than 320 characters of the essence of this Bible ";
                        string gSummary = "";
                        do // Prevent being the prompt too large for chatGPT
                        {
                            gSummary = await GetChatGPTSmallToken(sSummary + onlyProverbs);
                        } while (gSummary.Length > 320);

                        string qq = "Give a thought provoking " +
                                        "quote without source for " + onlyProverbs +
                                        " and take into account " + gSummary.Replace("\n", "");
                        string getQuote, sQuote;

                        sQuote = "";
                        getQuote = "";
                        List<string> gQ = new List<string>();
                        while (sQuote.Length <= 2)
                        {
                            gQ = await CreateQuote(qq, getQuote, sQuote);
                            sQuote = gQ[1];
                            getQuote = "";
                        }



                        // If we wanna have images, do so.
                        if (_Images.Contains("true"))
                        {

                            string Simage = await GetDalleGood("Create a medieval biblical Zohar Kabbalah mystical image WITHOUT TEXT based on Bible "
                                + onlyProverbs);
                            if (Simage.Contains("Bad Request")) // Probably from words and length
                            {
                                Simage = await GetDalleGood("Create a medieval biblical Zohar Kabbalah mystical image WITHOUT TEXT based on Bible "
                                + onlyProverbs);
                            }
                            await GlobalMethods.GetImageFromURL(Simage, _talkfile, sClean);

                            bool success = false;
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

                            imagePath = appPath + sClean + ".jpg";
                            GlobalMethods.AddImageToWordDocument(_talkfile, imagePath);
                        }

                        perkament = appPath + "perkament.jpg";
                        perkamentOut = appPath + "perkamentOut2.jpg";
                        perkamentOutFinal = appPath + "perkamentOut.jpg";
                        imagePathQuote = perkament; // Set your image path
                        outputPath = perkamentOut;
                        quote = sQuote;

                        // Quote
                        GlobalMethods.CreateQuoteBoxWithBackground(imagePathQuote, outputPath, sQuote.Replace("\n\n", "")
                            .Replace("\n", ""), fontSize);

                        long quality = 75L;
                        GlobalMethods.LowerImageFileSize(outputPath, perkamentOutFinal, quality);

                        Console.WriteLine($"Image Quote image created at: {outputPath}");
                        if (_Images.Contains("true"))
                        {
                            GlobalMethods.AddImageToWordDocumentOriginal(_talkfile, perkamentOutFinal, sQuote);
                        }

                        using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(_talkfile, true))
                        {
                            GlobalMethods.InsertPageBreak(wordDoc);
                        }

                        //GlobalMethods.AddImageToWordDocumentOverlay(_talkfile, perkamentOut, imagePath);

                        string subHeader = "Analysis from the Zohar";
                        GlobalMethods.AppendBoldTextToWord(_talkfile, subHeader, false);


                        sQuote = "";
                        getQuote = "";
                        while (sQuote.Length <= 2)
                        {
                            gQ = await CreateQuote(qq, getQuote, sQuote);
                            sQuote = gQ[1];
                            getQuote = "";
                        }

                        // Quote
                        GlobalMethods.CreateQuoteBoxWithBackground(imagePathQuote, outputPath, sQuote.Replace("\n\n", "")
                            .Replace("\n", ""), fontSize);

                        GlobalMethods.LowerImageFileSize(outputPath, perkamentOutFinal, quality);

                        Console.WriteLine($"Image Quote image created at: {outputPath}");

                        if (_Images.Contains("true"))
                        {
                            GlobalMethods.AddImageToWordDocumentOriginal(_talkfile, perkamentOutFinal, sQuote);
                        }


                        CompletionRequest completion = new CompletionRequest();

                        question = sStyle + questionFront + onlyProverbs + " and take into account " + gSummary.Replace("\n", "");
                        gSummary = GlobalMethods.CleanStringBeforeFirstQuote(gSummary.Replace("\n", ""));
                        gSummary = GlobalMethods.CleanStringAfterLastQuote(gSummary);
                        GlobalMethods.InsertQuotedText(_talkfile, gSummary, false, true, "Black", false, "Black"); // Quote without Page Break

                        //string firstLetter = "Do NOT start your answer with" + _first_letter;

                        _with_bible_letter = "true";
                        CheckLevelOfAIAnswer(speechSynthesizer,
                            "Not implemented level 1 AI",
                            "Not implemented level 2 AI",
                            question.Replace("_", " "));
                        _with_bible_letter = "false";

                        if (_elaborate.Contains("true"))
                        {
                            bool do200 = true;
                            if (_loop_discussion.Equals(100))
                            {
                                subHeader = "Apply in daily life";
                                GlobalMethods.AppendBoldTextToWord(_talkfile, subHeader, true);


                                sQuote = "";
                                getQuote = "";
                                while (sQuote.Length <= 2)
                                {
                                    gQ = await CreateQuote(qq, getQuote, sQuote);
                                    sQuote = gQ[1];
                                    getQuote = "";
                                }

                                GlobalMethods.CreateQuoteBoxWithBackground(imagePathQuote, outputPath, sQuote.Replace("\n\n", "")
                                    .Replace("\n", ""), fontSize);

                                GlobalMethods.LowerImageFileSize(outputPath, perkamentOutFinal, quality);

                                Console.WriteLine($"Image Quote image created at: {outputPath}");

                                if (_Images.Contains("true"))
                                {
                                    GlobalMethods.AddImageToWordDocumentOriginal(_talkfile, perkamentOutFinal, sQuote);
                                }

                                string secondQuestion =
                                        questionFront + " how to apply this into our daily life " + onlyProverbs
                                        + " and take into account " + gSummary.Replace("\n", "");
                                secondQuestion = sStyle + secondQuestion.Replace("\n", "");
                                GlobalMethods.InsertQuotedText(_talkfile, gSummary, false, true, "Black", false, "Black");

                                _with_bible_letter = "true";
                                CheckLevelOfAIAnswer(speechSynthesizer,
                                    "Not implemented level 1 AI",
                                    "Not implemented level 2 AI",
                                     secondQuestion.Replace("_", " "));
                                _with_bible_letter = "false";

                                subHeader = "Shakespeare, A Poem on " + onlyProverbs;
                                GlobalMethods.AppendBoldTextToWord(_talkfile, subHeader, true);

                                string shakeSpearQuestion =
                                        @"Give a thought provoking " +
                                        " short Poem Shakespeare style in Rhyme form iambic pentameter. Do not use more than 6 verses about this " + onlyProverbs
                                        + " and take into account " + gSummary.Replace("\n", "") + " with its surrounding Proverbs.";
                                secondQuestion = sStyle + shakeSpearQuestion.Replace("\n", "");

                                _with_perkament = "true";
                                CheckLevelOfAIAnswer(speechSynthesizer,
                                    "Not implemented level 1 AI",
                                    "Not implemented level 2 AI",
                                     secondQuestion.Replace("_", " "));
                                _with_perkament = "false";

                                do200 = false;
                            }
                            if (do200)
                            {
                                _loop_discussion = 200;
                                string connS = Secrets.cloudStorageConnString;
                                CloudStorageAccount account = CloudStorageAccount.Parse(connS);
                                var blobClient = account.CreateCloudBlobClient();
                                CloudBlobContainer blobContainer = blobClient.GetContainerReference("kentekenccontrole");
                                blobContainer.CreateIfNotExistsAsync();
                                await UploadTextToBlobAsync(blobContainer, "aidiscussion.txt", _discuss_answer);
                                string chunk =
                                    @"Give a deep and thought provoking " +
                                    "thorough analysis from the knowledge of the Kabballah, Mishnah and the Gemara. Write witty, cunning, intelligent and high society British: ";
                                await UploadTextToBlobAsync(blobContainer, "chunkQuestionChatGPT.txt", chunk);
                                CheckLevelOfAIAnswer(speechSynthesizer,
                                "Not implemented level 1 AI",
                                "Not implemented level 2 AI",
                                question.Replace("_", " "));
                                _loop_discussion = 100;
                            }
                        }

                    }
                    */

                    // Afterword
                    Console.WriteLine(repeatedString + '\n');
                    Console.WriteLine("Creating Afterword...");
                    GlobalMethods.AppendHeaderToWordExtendedWithPageBreak(_talkfile, "Afterword", "Heading 1");
                    string afterword = await GetChatGPTExtraSmallToken(
                        sStyle + "Create a large essay as after thoughts for the title: The Zohar Behind the Proverbs Chapters 5 and 6.");

                    firstChar = GlobalMethods.GetFirstCharacter(afterword);
                    GlobalMethods.ExtractFirstCharacter(afterword, out firstChar, out remainingString);

                    // Retrieve the corresponding image from the dictionary
                    if (_images.TryGetValue(firstChar, out image))
                    {
                        Console.WriteLine($"Image for '{firstChar}' found.");
                        string appPathh = AppDomain.CurrentDomain.BaseDirectory;
                        GlobalMethods.AddImageToWordDocumentOriginalWrap(_talkfile, appPathh + firstChar + ".jpg", "test",
                            100, 100, "Left");
                        GlobalMethods.AppendTextToWordDocumentCorrectFormatSplit(_talkfile, remainingString);
                    }
                    else
                    {
                        GlobalMethods.AppendTextToWordDocumentCorrectFormatSplit(_talkfile, remainingString);
                    }
                    Console.WriteLine("Created Afterword...");
                    GlobalMethods.RemoveEmptyPages(_talkfile);
                    GlobalMethods.RemovePageBreaksOnEmptyPages(_talkfile);
                }
                catch (IOException e)
                {
                    Console.WriteLine("An error occurred while reading the file:");
                    Console.WriteLine(e.Message);
                }


            }
            else if (args[0] != null && args[0].Contains("talkelaborate")) // TODO: Needs to be documented
            {


                string appPath = AppDomain.CurrentDomain.BaseDirectory;
                string filePath = "FileTalk.txt"; // Replace with your file path
                List<string> lines = new List<string>();
                _language = args[1];
                _talkfile_Quite = args[2];
                _prompt_provider = args[3];
                _elaborate = args[4];

                string filename = System.DateTime.Now.ToString("yyyyMMddHHmmssfff");
                string chapterTitlesPath = "talkfile_conversation" + filename + ".docx";
                _talkfile = appPath + chapterTitlesPath;
                string cc = GlobalMethods.CreateWordDocument(_talkfile);


                try
                {
                    // Read all lines from the file
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            // Add each line to the list
                            lines.Add(line);
                        }
                    }

                    // Optional: Print lines to console for verification
                    foreach (string l in lines)
                    {
                        // Splitting the line into parts
                        string[] parts = l.Split("\" \"");

                        // Assuming the format is always correct and parts length is at least 5

                        string question = parts[1].Trim('"');
                        _speed = float.Parse(parts[3]);
                        _language = parts[2].Trim('"');
                        _AILevel = Convert.ToInt16(parts[4].Replace("\"", ""));


                        // Your CheckLevelOfAIAnswer method call here
                        // You need to define this method and the speechSynthesizer object
                        // CheckLevelOfAIAnswer(speechSynthesizer, "Not implemented level 1 AI", "Not implemented level 2 AI", question);

                        // For demonstration, just printing the values
                        Console.WriteLine($"Question: {question.Replace("_", " ")}, Speed: {_speed}, Language: {_language}, AILevel: {_AILevel}");
                        string repeatedString = new string('#', 50);


                        string repeatedStringSecond = new string('-', 50);

                        _loop_discussion = 100;

                        string iimage = GlobalMethods.GetSubStringForImages(question, "");

                        Console.WriteLine(repeatedString + '\n');
                        GlobalMethods.AppendHeaderTotWordExtended(_talkfile, iimage, "Heading 1");
                        Console.WriteLine(question.Replace("_", " ") + '\n');
                        Console.WriteLine(repeatedString + '\n');

                        string getQuote = await GetChatGPTSmallToken("Create a catchy smart quote on:" + iimage);
                        GlobalMethods.InsertQuotedText(_talkfile, getQuote, true, false, "Black", true, "00008B");

                        string Simage = await GetDalleGood("Create a a mathematical mystical image without text from: " + iimage);
                        await GlobalMethods.GetImageFromURL(Simage, _talkfile, iimage);


                        CheckLevelOfAIAnswer(speechSynthesizer,
                            "Not implemented level 1 AI",
                            "Not implemented level 2 AI",
                            question.Replace("_", " "));

                        if (_elaborate.Contains("true"))
                        {
                            string connS = Secrets.cloudStorageConnString;
                            CloudStorageAccount account = CloudStorageAccount.Parse(connS);
                            var blobClient = account.CreateCloudBlobClient();
                            CloudBlobContainer blobContainer = blobClient.GetContainerReference("kentekenccontrole");
                            blobContainer.CreateIfNotExistsAsync();

                            // First elaboration
                            await UploadTextToBlobAsync(blobContainer, "aidiscussion.txt", _discuss_answer); // Save original analysis to blob
                            _discuss_answer_double = _discuss_answer;
                            _SomeMoreThoughts = "Elaboration";
                            _loop_discussion = 200;
                            string chunk = "First give a brief summary of the part itself and then a critical thorough analysis: ";
                            await UploadTextToBlobAsync(blobContainer, "chunkQuestionGoogle.txt", chunk);


                            CheckLevelOfAIAnswer(speechSynthesizer,
                            "Not implemented level 1 AI",
                            "Not implemented level 2 AI",
                            question.Replace("_", " "));

                            //------------------------------
                            ////Second elaboration on the original text
                            //await UploadTextToBlobAsync(blobContainer, "aidiscussion.txt", _discuss_answer_double); // Set back the original analysis
                            //_SomeMoreThoughts = "Elaboration";
                            //chunk = "Check the correctness and give elaborate well thought out replies on: ";
                            //await UploadTextToBlobAsync(blobContainer, "chunkQuestionChatGPT.txt", chunk);

                            //CheckLevelOfAIAnswer(speechSynthesizer,
                            //"Not implemented level 1 AI",
                            //"Not implemented level 2 AI",
                            //question.Replace("_", " "));

                            //// Third elaboration
                            //string dTrip = _discuss_answer; // for if we also wanna critique elaboration
                            ////Second elaboration on the original text
                            //await UploadTextToBlobAsync(blobContainer, "aidiscussion.txt", dTrip); // Set back the original analysis
                            //_SomeMoreThoughts = "Critique Elaboration";
                            //chunk = "Check the correctness and of the statements and give elaborate well thought out replies: ";
                            //await UploadTextToBlobAsync(blobContainer, "chunkQuestionChatGPT.txt", chunk);

                            //CheckLevelOfAIAnswer(speechSynthesizer,
                            //"Not implemented level 1 AI",
                            //"Not implemented level 2 AI",
                            //question.Replace("_", " "));
                            // ------------------------------

                            // -- Google extra enhancements to the text, as critical notes
                            //string sd = _prompt_provider;
                            //await UploadTextToBlobAsync(blobContainer, "aidiscussion.txt", _discuss_answer_double);
                            //if (_prompt_provider.Contains("Google"))
                            //    _prompt_provider = "ChatGPT";
                            //else
                            //    _prompt_provider = "Google";

                            //CheckLevelOfAIAnswer(speechSynthesizer,
                            //"Not implemented level 1 AI",
                            //"Not implemented level 2 AI",
                            //question.Replace("_", " "));
                            //_prompt_provider = sd;
                            ////----------------------------------------------------------------

                            _loop_discussion = 100;
                        }

                    }
                }
                catch (IOException e)
                {
                    Console.WriteLine("An error occurred while reading the file:");
                    Console.WriteLine(e.Message);
                }
            }
            // TODO: Needs to be documented
            else if (args[0].Equals("talkbig")) // Speaks out the subject from a file and save  answers to a file.
            {
                string appPath = AppDomain.CurrentDomain.BaseDirectory;
                string filePath = "FileBig.txt"; // Replace with your file path
                List<string> lines = new List<string>();
                _language = args[1];
                _talkfile_Quite = args[2];
                _prompt_provider = args[3];

                string filename = System.DateTime.Now.ToString("yyyyMMddHHmmssfff");
                string chapterTitlesPath = "talkfile_conversation" + filename + ".docx";
                _talkfile = appPath + chapterTitlesPath;
                string cc = GlobalMethods.CreateWordDocument(_talkfile);


                try
                {
                    // Read all lines from the file
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            // Add each line to the list
                            lines.Add(line);
                        }
                    }

                    // Optional: Print lines to console for verification
                    foreach (string l in lines)
                    {
                        // Splitting the line into parts
                        string[] parts = l.Split("\" \"");

                        // Assuming the format is always correct and parts length is at least 5

                        string question = parts[1].Trim('"');
                        _speed = float.Parse(parts[3]);
                        _language = parts[2].Trim('"');
                        _AILevel = Convert.ToInt16(parts[4].Replace("\"", ""));

                        // Your CheckLevelOfAIAnswer method call here
                        // You need to define this method and the speechSynthesizer object
                        // CheckLevelOfAIAnswer(speechSynthesizer, "Not implemented level 1 AI", "Not implemented level 2 AI", question);

                        // For demonstration, just printing the values
                        Console.WriteLine($"Question: {question.Replace("_", " ")}, Speed: {_speed}, Language: {_language}, AILevel: {_AILevel}");
                        string repeatedString = new string('#', 50);



                        string repeatedStringSecond = new string('-', 50);

                        _loop_discussion = 100;

                        string iimage = GlobalMethods.GetSubStringForImages(question, "");

                        Console.WriteLine(repeatedString + '\n');
                        GlobalMethods.AppendHeaderTotWordExtended(_talkfile, iimage, "Heading 1");
                        Console.WriteLine(question.Replace("_", " ") + '\n');
                        Console.WriteLine(repeatedString + '\n');

                        string getQuote = await GetChatGPTSmallToken("Create a catchy smart quote on:" + iimage);
                        GlobalMethods.InsertQuotedText(_talkfile, getQuote, true, false, "Black", true, "00008B");

                        string Simage = await GetDalleGood("Create a a mathematical mystical image without text from: " + iimage);
                        await GlobalMethods.GetImageFromURL(Simage, _talkfile, iimage);
                        //GlobalMethods.AddImageToExistingDocument(_talkfile, iimage + ".jpg");

                        GlobalMethods.AppendTextToWordDocumentCorrectFormatSplit(_talkfile, repeatedStringSecond);
                        GlobalMethods.AppendTextToWordDocumentCorrectFormatSplit(_talkfile, "ChatGPT");
                        GlobalMethods.AppendTextToWordDocumentCorrectFormatSplit(_talkfile, repeatedStringSecond);

                        _prompt_provider = "ChatGPT";
                        CheckLevelOfAIAnswer(speechSynthesizer,
                            "Not implemented level 1 AI",
                            "Not implemented level 2 AI",
                            question.Replace("_", " "));

                        GlobalMethods.AppendTextToWordDocumentCorrectFormatSplit(_talkfile, repeatedStringSecond);
                        GlobalMethods.AppendTextToWordDocumentCorrectFormatSplit(_talkfile, "Google");
                        GlobalMethods.AppendTextToWordDocumentCorrectFormatSplit(_talkfile, repeatedStringSecond);

                        string biggerGoogleQuestion = "Add to the answer on this question relevant information from Science, Chemistry, Biology, Astrology and Spiritual Sources." + question;

                        _prompt_provider = "Google";
                        CheckLevelOfAIAnswer(speechSynthesizer,
                            "Not implemented level 1 AI",
                            "Not implemented level 2 AI",
                            biggerGoogleQuestion.Replace("_", " "));

                    }
                }
                catch (IOException e)
                {
                    Console.WriteLine("An error occurred while reading the file:");
                    Console.WriteLine(e.Message);
                }

            }
            // Let AI discuss with itself. ChatGPT and Google.
            else if (args[0].Contains("talkdiscuss"))
            {
                string appPath = AppDomain.CurrentDomain.BaseDirectory;
                string filePath = "FileDiscuss.txt"; // Replace with your file path
                List<string> lines = new List<string>();
                _language = args[1];
                _talkfile_Quite = args[2];
                _prompt_provider = args[3];

                string filename = System.DateTime.Now.ToString("yyyyMMddHHmmssfff");
                string chapterTitlesPath = "talkfile_conversation" + filename + ".docx";
                _talkfile = appPath + chapterTitlesPath;
                string cc = GlobalMethods.CreateWordDocument(_talkfile);
                try
                {
                    // Read all lines from the file
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            // Add each line to the list
                            lines.Add(line);
                        }
                    }

                    // Optional: Print lines to console for verification
                    foreach (string l in lines)
                    {
                        // Splitting the line into parts
                        string[] parts = l.Split("\" \"");

                        // Assuming the format is always correct and parts length is at least 5

                        string question = parts[1].Trim('"');
                        _speed = float.Parse(parts[3]);
                        _language = parts[2].Trim('"');
                        _AILevel = Convert.ToInt16(parts[4].Replace("\"", ""));

                        // Your CheckLevelOfAIAnswer method call here
                        // You need to define this method and the speechSynthesizer object
                        // CheckLevelOfAIAnswer(speechSynthesizer, "Not implemented level 1 AI", "Not implemented level 2 AI", question);

                        // For demonstration, just printing the values
                        Console.WriteLine($"Question: {question.Replace("_", " ")}, Speed: {_speed}, Language: {_language}, AILevel: {_AILevel}");
                        string repeatedString = new string('#', 50);
                        GlobalMethods.AppendHeaderTotWordExtended(_talkfile, question.Replace("_", " "), "Header 1");
                        Console.WriteLine(repeatedString + '\n');

                        _loop_discussion = 0;
                        for (int i = 0; i < 2; i++)
                        {
                            GlobalMethods.AppendHeaderTotWordExtended(_talkfile, _prompt_provider + ":" + _loop_discussion.ToString(), "Header 3");

                            int iL = _loop_discussion;
                            _loop_discussion = 200;
                            CheckLevelOfAIAnswer(speechSynthesizer,
                                "Not implemented level 1 AI",
                                question.Replace("_", " "),
                                question.Replace("_", " "));
                            _loop_discussion = iL;

                            if (_loop_discussion.Equals(0))
                            {
                                string connS = Secrets.cloudStorageConnString;
                                CloudStorageAccount account = CloudStorageAccount.Parse(connS);
                                var blobClient = account.CreateCloudBlobClient();
                                CloudBlobContainer blobContainer = blobClient.GetContainerReference("kentekenccontrole");
                                blobContainer.CreateIfNotExistsAsync();
                                //string sd = await WriteFileToBlobF(_discuss_answer, "aidiscussion.txt", "kentekenccontrole");
                                await UploadTextToBlobAsync(blobContainer, "aidiscussion.txt", _discuss_answer);
                            }

                            if (_prompt_provider.Contains("Google"))
                                _prompt_provider = "ChatGPT";
                            else
                                _prompt_provider = "Google";

                            _loop_discussion += 1;
                        }
                        GlobalMethods.AddPageBreak(_talkfile);
                    }
                }
                catch (IOException e)
                {
                    Console.WriteLine("An error occurred while reading the file:");
                    Console.WriteLine(e.Message);
                }
            }
        }
        // "startrek" opens up the Enterprise computer for conversation.
        else if (args[0] != null && args[0].Contains("startrek"))
        {
            try
            {
                TextToSpeechClient client = IniGoogleSound();
                string textToSynthesize = "Please, start communicating with me.";
                GlobalMethods.DoSpeak(client, textToSynthesize);
                string filename = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                string chapterTitlesPath = "startrek_conversation" + filename + ".txt";
                string appPath = AppDomain.CurrentDomain.BaseDirectory;
                string theChapters = appPath + chapterTitlesPath;

                while (true)
                {
                    var speechConfig = SpeechConfig.FromSubscription(speechKey, speechRegion);
                    speechConfig.SpeechRecognitionLanguage = "en-US";
                    using var audioConfig = Microsoft.CognitiveServices.Speech.Audio.AudioConfig.FromDefaultMicrophoneInput();
                    using var speechRecognizer = new SpeechRecognizer(speechConfig, audioConfig);
                    Console.Clear();
                    Console.WriteLine("Speak into your microphone.");
                    var speechRecognitionResult = await speechRecognizer.RecognizeOnceAsync();

                    // Check if the recognized text starts with the word "computer"
                    if (speechRecognitionResult.Text.StartsWith("computer", StringComparison.OrdinalIgnoreCase))
                    {

                        GlobalMethods.PlayAudio("affirmative.wav");
                        var speechConfigC = SpeechConfig.FromSubscription(speechKey, speechRegion);
                        speechConfigC.SpeechRecognitionLanguage = "en-US";
                        using var audioConfigC = Microsoft.CognitiveServices.Speech.Audio.AudioConfig.FromDefaultMicrophoneInput();
                        using var speechRecognizerC = new SpeechRecognizer(speechConfigC, audioConfigC);
                        Console.Clear();
                        Console.WriteLine("Ask the question");
                        var speechRecognitionResultC = await speechRecognizerC.RecognizeOnceAsync();
                        StartrekResult(speechRecognitionResultC, appPath, chapterTitlesPath);

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        else
        {
            // Lets talk!
            // "speak"
            // Example "Make three books about math, three chapters, no images"
            // Will be translated to "math" 1 3 1 false
            // Down commands neglect the given subject in voice command.
            // Example "Make three books about math, three chapters, no images" math will be overwritten with own title.
            // Possible command 1.1: "speak" 3 "Your own title"
            // Possible command 1.2: "speak" 3 "Your own title" "NL"
            // Possible command 1.3: "speak" 3 "Your own title" "NL" 0.9
            // Possible command 1.4: "speak" 3 "Your own title" "NL" "Publish" "Agile - "
            // Possible command 2: "speak" 3
            // param 1: you want to speak
            // param 2: AI level of lecture
            // param 3: Yiour own title that will overrule what you tell the computer
            // param 4: Language (for now default US, NL, BG and DE)
            // param 5: Speed of talk. If you want to have the lecture slow.
            if (args[0] != null && args[0].Contains("speak")) // One argrument: "speak" initiating voice command.
            {
                try
                {
                    TextToSpeechClient client = IniGoogleSound();

                    string textToSynthesize = "Please, give your command to create books.";
                    GlobalMethods.DoSpeak(client, textToSynthesize);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                _AILevel = int.Parse(args[1]);
                try
                {
                    // Prep the voice.
                    var speechConfig = SpeechConfig.FromSubscription(speechKey, speechRegion);
                    speechConfig.SpeechRecognitionLanguage = "en-US";

                    using var audioConfig = Microsoft.CognitiveServices.Speech.Audio.AudioConfig.FromDefaultMicrophoneInput();
                    //using var audioConfig = AudioConfig.FromWavFileInput("Recording.wav");
                    using var speechRecognizer = new SpeechRecognizer(speechConfig, audioConfig);

                    Console.WriteLine("Speak into your microphone.");
                    var speechRecognitionResult = await speechRecognizer.RecognizeOnceAsync();
                    OutputSpeechRecognitionResult(speechRecognitionResult);

                    // Prep the vars
                    string bookSubject = "";
                    bool AITopic = true;
                    List<string> theFiles = new List<string>();
                    if (args.Length.Equals(3))
                    {
                        _speak = true;
                        _topic = args[2];
                        bookSubject = args[2];
                        AITopic = false;
                        theFiles.Add(bookSubject);
                    }
                    else if (args.Length.Equals(4))
                    {
                        _speak = true;
                        _language = args[3];
                        _topic = args[2];
                        bookSubject = args[2];
                        AITopic = false;
                        theFiles.Add(bookSubject);
                    }
                    else if (args.Length.Equals(6))
                    {
                        _language = args[3];
                        _topic = args[2];
                        bookSubject = args[2];
                        AITopic = false;
                        theFiles.Add(bookSubject);
                        _publishfile = args[5];
                        _doscommand = "batch";
                    }
                    else if (args.Length.Equals(5))
                    {
                        _speak = true;
                        _speed = float.Parse(args[4]);
                        _language = args[3];
                        _topic = args[2];
                        bookSubject = args[2];
                        AITopic = false;
                        theFiles.Add(bookSubject);
                    }
                    else
                    {
                        _speak = true;
                        bookSubject = _topic.Replace("Response from AI:", "").Trim();
                    }

                    _bParagraphs = "3";

                    int numberOfTopics = nBook;
                    int numberOfChapters = 0;
                    if (nChapters.Equals(3))
                    {
                        numberOfChapters = nChapters + 1;
                    }
                    else
                        numberOfChapters = nChapters;

                    int numberOfBooksPerTitle = nExamples;
                    bool withImages = nImages;
                    _subject = bookSubject;

                    // Do nice to the user.

                    if (_speak)
                    {
                        if (_VProvider.Equals(1))
                        {
                            speechSynthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult, 3, new System.Globalization.CultureInfo("en-US"));
                            speechSynthesizer.Speak(await GetChatGPTSmallToken("Say in a polite way " +
                                 "that you are ready to create the books on the topic " + bookSubject + " and ask the user to hit the Y to continue of the N to cancel."));
                        }
                        else
                        {
                            TextToSpeechClient client = IniGoogleSound();
                            string textToSynthesize = await GetChatGPTSmallToken("Say in a polite way " +
                                 "that you are ready to create the books on the topic " + bookSubject + " and ask the user to hit the Y to continue of the N to cancel.");
                            GlobalMethods.DoSpeak(client, textToSynthesize);
                        }
                    }
                    Console.WriteLine("Ready to make the Books? (y/n)");
                    ConsoleKeyInfo keyInfo;
                    keyInfo = Console.ReadKey();

                    if (keyInfo.KeyChar.Equals('y'))
                    {
                        if (_speak)
                        {
                            if (_VProvider.Equals(1))
                            {
                                speechSynthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult, 3, new System.Globalization.CultureInfo("en-US"));
                                speechSynthesizer.Speak("I will now start creating the books on the topic:" + bookSubject);
                            }
                            else
                            {
                                TextToSpeechClient client = IniGoogleSound();
                                string textToSynthesizee = "I will now start creating the books on the topic:" + bookSubject;
                                GlobalMethods.DoSpeak(client, textToSynthesizee);
                            }
                        }
                        List<string> listOfFilesForBookConversion = await MakeBookWithVariableStrings(bookSubject, numberOfTopics, numberOfChapters,
                            numberOfBooksPerTitle, AITopic, theFiles, "Book");

                        TextToSpeechClient clientt = IniGoogleSound();
                        string textToSynthesize = "Check book before creating.";
                        GlobalMethods.DoSpeak(clientt, textToSynthesize);
                        keyInfo = Console.ReadKey();

                        string returnMessage = "";
                        int cList = listOfFilesForBookConversion.Count;
                        returnMessage = await MakeTheBooks(listOfFilesForBookConversion, "Beginner", withImages);

                        if (_speak)
                        {
                            if (_VProvider.Equals(1))
                            {
                                speechSynthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult, 3, new System.Globalization.CultureInfo("en-US"));
                                speechSynthesizer.Speak("It's my pleasure to inform you that the books are created.");
                                speechSynthesizer.Speak("Till next time my dear friend..");
                            }
                            else
                            {
                                TextToSpeechClient client = IniGoogleSound();
                                string textToSynthesizee = "It's my pleasure to inform you that the books are created.";
                                GlobalMethods.DoSpeak(client, textToSynthesizee);
                                textToSynthesize = "Till next time my dear friend..";
                                GlobalMethods.DoSpeak(client, textToSynthesize);
                            }
                        }

                        Console.WriteLine("Ready writing books");
                    }
                    else
                    {
                        if (_VProvider.Equals(1))
                        {
                            speechSynthesizer.Speak("See you later!");
                            Console.WriteLine("Program stopped.");
                        }
                        else
                        {
                            TextToSpeechClient client = IniGoogleSound();
                            string textToSynthesize = "See you later!";
                            GlobalMethods.DoSpeak(client, textToSynthesize);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            // "Scrum" 2 3 1 false
            // param 1: the title of the book(s)
            // param 2: the amount (variations on the title)
            // param 3: amount of chapters
            // param 4: examples of same book (content differs)
            // param 5: images
            else // Lets NOT talk! The old fashioned command prompt.
            {
                if (args.Length < 5)
                {
                    string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "commandsdocumentation.txt");

                    try
                    {
                        // Check if the file exists
                        if (File.Exists(filePath))
                        {
                            // Open the file for reading
                            using (StreamReader reader = new StreamReader(filePath))
                            {
                                string line;

                                // Read and display each line in the file
                                while ((line = reader.ReadLine()) != null)
                                {
                                    Console.WriteLine(line);
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("The file 'commanddocumentation.txt' does not exist in the app directory.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");
                    }

                    return;
                }
                // Prep the vars.
                string bookSubject = args[0];
                int numberOfTopics = int.Parse(args[1]);
                int numberOfChapters = int.Parse(args[2]);
                int numberOfBooksPerTitle = int.Parse(args[3]);
                bool withImages = bool.Parse(args[4]);
                _subject = bookSubject;

                // Make the books
                List<string> listOfFilesForBookConversion = await MakeBookWithVariableStrings(bookSubject, numberOfTopics, numberOfChapters,
                    numberOfBooksPerTitle, true, null, "Book");

                TextToSpeechClient client = IniGoogleSound();
                string textToSynthesize = "Check book before creating.";
                GlobalMethods.DoSpeak(client, textToSynthesize);
                ConsoleKeyInfo keyInfo;
                keyInfo = Console.ReadKey();

                // Say goodbye.
                string returnMessage = "";
                int cList = listOfFilesForBookConversion.Count;
                returnMessage = await MakeTheBooks(listOfFilesForBookConversion, "Beginner", withImages);

                if (_speak)
                {
                    if (_VProvider.Equals(1))
                    {
                        speechSynthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult, 3, new System.Globalization.CultureInfo("en-US"));
                        speechSynthesizer.Speak("It's my pleasure to inform you that the books are created.");
                        speechSynthesizer.Speak("Till next time my dear friend..");
                    }
                    else
                    {
                        client = IniGoogleSound();
                        textToSynthesize = "It's my pleasure to inform you that the books are created.";
                        GlobalMethods.DoSpeak(client, textToSynthesize);
                        textToSynthesize = "Till next time my dear friend..";
                        GlobalMethods.DoSpeak(client, textToSynthesize);
                    }
                }
                Console.WriteLine("Ready writing books");
            }
        }
    }

    private static void MakeAnImageOfTheFirstLetterInAString(string foreword)
    {
        string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string inputText = foreword;
        char firstLetter = '\0';
        foreach (char c in inputText)
        {
            if (char.IsLetter(c))
            {
                firstLetter = c;
                break;
            }
        }
        string firstLetterImagePath = Path.Combine(appDirectory, $"{char.ToUpper(firstLetter)}.jpg");

        // Check if the image exists
        if (!File.Exists(firstLetterImagePath))
        {
            Console.WriteLine($"Image for the letter '{firstLetter}' not found.");

        }
        GlobalMethods.AddImageToWordDocument(_talkfile, firstLetterImagePath);
    }

    private static async Task<List<string>> CreateQuote(string qq, string getQuote, string sQuote)
    {
        List<string> varrs = new List<string>();
        getQuote = await GetChatGPTSmallToken(qq);
        sQuote = GlobalMethods.CleanStringBeforeFirstQuote(getQuote);
        sQuote = GlobalMethods.CleanStringAfterLastQuote(getQuote);
        varrs.Add(getQuote);
        varrs.Add(sQuote);
        return varrs;
    }

    public static async Task<string> WriteFileToBlobF(string content, string fileName, string containerName)
    {
        try
        {
            string connectionString = Secrets.cloudStorageConnString;
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);
            var blobClient = storageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference(containerName);
            await container.CreateIfNotExistsAsync();
            var blob = container.GetBlockBlobReference(fileName);

            // Use HttpClient to upload the text
            using (var httpClient = new HttpClient())
            using (var contentStream = new StringContent(content))
            {
                contentStream.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("text/plain");
                var response = await httpClient.PutAsync(blob.Uri, contentStream);
                if (!response.IsSuccessStatusCode)
                {
                    return $"Failed to upload: {response.StatusCode}";
                }
            }
            return "Success";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Ends HTML tags. </summary>
    ///
    /// <remarks>   Shadow, 4/2/2024. </remarks>
    ///
    /// <param name="rr">   The rr. </param>
    ///
    /// <returns>   A string. </returns>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    private static string EndHTMLTags(string rr)
    {
        string fixedLists = GlobalMethods.FixLists(rr);
        rr = fixedLists;
        string fixedHtml = GlobalMethods.FixTables(rr);
        rr = fixedHtml;
        return rr;
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Initializes the google sound. </summary>
    ///
    /// <remarks>   Shadow, 4/2/2024. </remarks>
    ///
    /// <returns>   A TextToSpeechClient. </returns>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    private static TextToSpeechClient IniGoogleSound()
    {
        string basePath = AppDomain.CurrentDomain.BaseDirectory;
        string credentialsPath = basePath + Secrets._jsonFile;

        // Load your service account credentia
        // ls
        GoogleCredential credential = GoogleCredential.FromFile(credentialsPath);

        // Create a client to interact with the Text-to-Speech API
        TextToSpeechClientBuilder builder = new TextToSpeechClientBuilder();
        builder.CredentialsPath = credentialsPath;
        TextToSpeechClient client = builder.Build();
        return client;
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Synthesize speech. </summary>
    ///
    /// <remarks>   Shadow, 4/2/2024. </remarks>
    ///
    /// <param name="text">         The text. </param>
    /// <param name="speakingRate"> The speaking rate. </param>
    /// <param name="client">       The client. </param>
    /// <param name="languageCode"> The language code. </param>
    /// <param name="lName">        The name. </param>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static void SynthesizeSpeech(string text, float speakingRate, TextToSpeechClient client
        , string languageCode, string lName)
    {
        // Create SSML with the speaking rate
        string ssml = $"<speak><prosody rate=\"{speakingRate}\">{text}</prosody></speak>";

        // Convert the SSML to speech
        SynthesizeSpeechResponse response = client.SynthesizeSpeech(
            input: new SynthesisInput
            {
                Text = ssml // Do not specify InputType
            },
            voice: new VoiceSelectionParams
            {
                LanguageCode = "en-US", // Replace with your desired language code
                Name = "en-US-Wavenet-D", // Replace with the desired voice name
                SsmlGender = SsmlVoiceGender.Female
            },
            audioConfig: new Google.Cloud.TextToSpeech.V1.AudioConfig
            {
                AudioEncoding = AudioEncoding.Linear16
            });

        // Save the synthesized speech to a file
        byte[] audioData = response.AudioContent.ToByteArray();
        File.WriteAllBytes("output.wav", audioData);
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Initializes the google translation. </summary>
    ///
    /// <remarks>   Shadow, 4/2/2024. </remarks>
    ///
    /// <returns>   A TranslationClient. </returns>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    private static TranslationClient InitializeGoogleTranslation()
    {
        // Set the path to your JSON key file
        string basePath = AppDomain.CurrentDomain.BaseDirectory;
        string credentialsPath = basePath + Secrets._jsonFile;

        // Load your service account credentials
        GoogleCredential credential = GoogleCredential.FromFile(credentialsPath);

        // Create a client to interact with the Translation API
        TranslationClientBuilder builder = new TranslationClientBuilder();
        builder.CredentialsPath = credentialsPath;
        TranslationClient client = builder.Build();
        return client;
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Answers bible. </summary>
    ///
    /// <remarks>   Shadow, 4/2/2024. </remarks>
    ///
    /// <param name="sBook">        The book. </param>
    /// <param name="sChapter">     The chapter. </param>
    /// <param name="eChapter">     The chapter. </param>
    /// <param name="eHolyVerse">   The holy verse. </param>
    ///
    /// <returns>   A List&lt;string&gt; </returns>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static List<string> AnswersBible(string sBook, int sChapter, int eChapter, int eHolyVerse)
    {
        string AllTheAnswers = "";
        List<string> GetAnswers = new List<string>();
        try
        {
            string responseText = "";
            List<string> BibleArray = new List<string>();

            responseText = Writeyourownbooktest.GlobalMethods.GetHttpReturnFromAPIRestLink(Secrets._BibleAPI
                            + sBook + " " + sChapter.ToString() + ":");

            List<string> lines = responseText.Split(new[] { "<br>" }, StringSplitOptions.RemoveEmptyEntries).ToList();

            for (int iW = 0; iW <= lines.Count - 1; iW++)
            {
                string pattern = @"[^\n\r:,\.\s\w]+|[\r\n\t]+";
                string replacement = "";
                string output = "";
                output = Regex.Replace(lines[iW].ToString(), pattern, replacement);

                GetAnswers.Add(GlobalMethods.RemoveLeadingNumbers(Writeyourownbooktest.GlobalMethods.DeleteFirstSpace(
                    Writeyourownbooktest.GlobalMethods.DeleteFirstColonSpace(Writeyourownbooktest.GlobalMethods.AddSpaceBetweenNumbersAndText(
                    Writeyourownbooktest.GlobalMethods.DeleteFirstNumber(output))))));
            }
            foreach (var item in GetAnswers)
            {

                AllTheAnswers += item + '\n';
            }

           
            string aa = AllTheAnswers.ToString();
            return GetAnswers;
        }
        catch (Exception ex)
        {
            string er = ex.Message;
            AllTheAnswers = "Error:" + er;
            GetAnswers.Add(AllTheAnswers);
            return GetAnswers;
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Searches for the first number index. </summary>
    ///
    /// <remarks>   Shadow, 4/2/2024. </remarks>
    ///
    /// <param name="input">    The input. </param>
    ///
    /// <returns>   The found number index. </returns>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    static int FindFirstNumberIndex(string input)
    {
        for (int i = 0; i < input.Length; i++)
        {
            if (char.IsDigit(input[i]))
            {
                return i;
            }
        }
        return -1; // Return -1 if no number is found
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// This example requires environment variables named "SPEECH_KEY" and "SPEECH_REGION".
    /// </summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    static string speechKey = Secrets._SpeechKey;
    /// <summary>   The speech region. </summary>
    static string speechRegion = "westeurope";

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Output speech recognition result. </summary>
    ///
    /// <remarks>
    /// Shadow, 12/5/2023. Basically this method makes the receiving of speech possible.
    /// </remarks>
    ///
    /// <param name="speechRecognitionResult">  The speech recognition result. </param>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    static async void OutputSpeechRecognitionResult(Microsoft.CognitiveServices.Speech.SpeechRecognitionResult speechRecognitionResult)
    {
        switch (speechRecognitionResult.Reason)
        {
            case ResultReason.RecognizedSpeech:
                Console.WriteLine($"RECOGNIZED: Text={speechRecognitionResult.Text}");
                speak(speechRecognitionResult.Text);
                break;
            case ResultReason.NoMatch:
                Console.WriteLine($"NOMATCH: Speech could not be recognized.");
                break;
            case ResultReason.Canceled:
                var cancellation = CancellationDetails.FromResult(speechRecognitionResult);
                Console.WriteLine($"CANCELED: Reason={cancellation.Reason}");

                if (cancellation.Reason == CancellationReason.Error)
                {
                    Console.WriteLine($"CANCELED: ErrorCode={cancellation.ErrorCode}");
                    Console.WriteLine($"CANCELED: ErrorDetails={cancellation.ErrorDetails}");
                    Console.WriteLine($"CANCELED: Did you set the speech resource key and region values?");
                }
                break;
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Startrek result. </summary>
    ///
    /// <remarks>   Shadow, 4/2/2024. </remarks>
    ///
    /// <param name="speechRecognitionResult">  The speech recognition result. </param>
    /// <param name="appPath">                  Full pathname of the application file. </param>
    /// <param name="sFile">                    The file. </param>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    static async void StartrekResult(Microsoft.CognitiveServices.Speech.SpeechRecognitionResult speechRecognitionResult,
        string appPath, string sFile)
    {
        switch (speechRecognitionResult.Reason)
        {
            case ResultReason.RecognizedSpeech:
                GlobalMethods.PlayAudio("working.wav");
                Console.WriteLine($"RECOGNIZED: Text={speechRecognitionResult.Text}");
                TextToSpeechClient client = IniGoogleSound();
                string textToSynthesize = speechRecognitionResult.Text;
                string[] words = textToSynthesize.Split(' ');
                
                // Check if the first word is "computer" (case-insensitive)
                if (words.Length > 0 && words[0].Equals("computer", StringComparison.OrdinalIgnoreCase))
                {
                    // Remove the first word and join the remaining words
                    textToSynthesize = string.Join(" ", words.Skip(1));
                }
                if (words.Length > 0 && words[0].Contains("shut", StringComparison.OrdinalIgnoreCase)
                    && words[1].Contains("down", StringComparison.OrdinalIgnoreCase))
                {
                    textToSynthesize = "Good bye";
                    GlobalMethods.DoSpeak(client, textToSynthesize);
                    Console.Write("Good bye.");
                    Environment.Exit(0);
                }
                Console.WriteLine("Question asked to the computer:" + textToSynthesize);
                string repeatedString = new string('#', 50);
                GlobalMethods.AppendTextToFile(appPath + sFile, repeatedString);
                GlobalMethods.AppendTextToFile(appPath + sFile, textToSynthesize); // Save question.
                GlobalMethods.AppendTextToFile(appPath + sFile, repeatedString);
                string responseText = GetRESTAPICallContent(Secrets._ChatGPTAPI
                                + textToSynthesize);
                GlobalMethods.AppendTextToFile(appPath + sFile, RemoveNonLettersForTalk(responseText) + '\n' + '\n'); // Save conversation.
                GlobalMethods.DoSpeakUS(client, RemoveNonLettersForTalk(responseText), 0.85f);
                GlobalMethods.PlayAudio("transfercomplete.wav");
                break;
            case ResultReason.NoMatch:
                Console.WriteLine($"NOMATCH: Speech could not be recognized.");
                break;
            case ResultReason.Canceled:
                var cancellation = CancellationDetails.FromResult(speechRecognitionResult);
                Console.WriteLine($"CANCELED: Reason={cancellation.Reason}");

                if (cancellation.Reason == CancellationReason.Error)
                {
                    Console.WriteLine($"CANCELED: ErrorCode={cancellation.ErrorCode}");
                    Console.WriteLine($"CANCELED: ErrorDetails={cancellation.ErrorDetails}");
                    Console.WriteLine($"CANCELED: Did you set the speech resource key and region values?");
                }
                break;
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Speaks. </summary>
    ///
    /// <remarks>   Shadow, 12/5/2023. LETS TALK BABY! </remarks>
    ///
    /// <param name="text"> The text. </param>
    ///
    /// <returns>   A string. </returns>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    static async Task<string> speak(string text)
    {
        System.Speech.Synthesis.SpeechSynthesizer speechSynthesizer = new System.Speech.Synthesis.SpeechSynthesizer();
        try
        {
            // Important: transforms whatever voice string to the first prep of the final command.
            string properQuestion = "Transform the given string:  \"" + text + "\" into the format like \"Topic title " +
                "is hacking. Number of books is 3, Number of chapters is 18. Images is yes\"\r\n\r\n";

            string answer = GetRESTAPICallContent(Secrets._ChatGPTAPI
                            + properQuestion);
            answer.Replace("Response from AI:", "");
            string getSubject = answer;
            int startIndex = getSubject.IndexOf("Topic title is ") + "Topic title is ".Length;
            int endIndex = getSubject.IndexOf("Number of books");

            // Now we need to stringrape a bit to get the final command.
            if (startIndex >= 0 && endIndex >= 0)
            {
                // Extract the substring between the two positions
                

                string extractedText = getSubject.Substring(startIndex, endIndex - startIndex);

                // Add quotation marks around the extracted text
                string result = extractedText;
                answer.Replace("Topic title is", "").Replace("Number of books is", "").Replace("Number of chapters", "")
                    .Replace("Images is", "");

                string _answer = answer.Replace("Topic title is", "").Replace("Number of books is", "").Replace("Number of chapters is", "")
                    .Replace("Images is", "1 ").Replace(",", "").Replace(".", "").
                    Replace("Number of chapters is", "").Replace("  ", " ");

                Console.WriteLine(answer.Replace("Topic title is", "").Replace("Number of books is", "").Replace("Number of chapters is", "")
                     .Replace("Images is", "1 ").Replace(",", "").Replace(".", "").
                     Replace("Number of chapters is", "").Replace("  ", " "));

                if (_speak)
                {
                    if (_VProvider.Equals(1))
                    {
                        // We have the final command, do nice to the user.
                        speechSynthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult, 3, new System.Globalization.CultureInfo("en-US"));
                        speechSynthesizer.Speak(answer.Replace("Response from AI:", ""));
                        string secondanswer = GetRESTAPICallContent(Secrets._ChatGPTAPI
                                    + "Say in a polite way " +
                            "that you are ready to create the books and ask the user to hit the Y to continue of the N to cancel." +
                            "Finish with that you are happy to be of service.");
                        speechSynthesizer.Speak(secondanswer.Replace("Response from AI:", ""));
                    }
                    else
                    {
                        TextToSpeechClient client = IniGoogleSound();
                        string textToSynthesize = answer.Replace("Response from AI:", "");
                        GlobalMethods.DoSpeak(client, textToSynthesize);
                        string secondanswer = GetRESTAPICallContent(Secrets._ChatGPTAPI
                                   + "Say in a polite way " +
                           "that you are ready to create the books and ask the user to hit the Y to continue of the N to cancel." +
                           "Finish with that you are happy to be of service.");
                        textToSynthesize = secondanswer.Replace("Response from AI:", "");
                        GlobalMethods.DoSpeak(client, textToSynthesize);
                    }
                }
                Console.WriteLine("Is the subject for your book correct or try again? (y/n)");

                // Get user input y or n
                ConsoleKeyInfo keyInfo;
                keyInfo = Console.ReadKey();

                if (keyInfo.KeyChar.Equals('y'))
                {
                    // Prep the vars for the final book creation. Get them from the final command string.
                    string p1 = "";
                    int p2 = 0;
                    int p3 = 0;
                    int p4 = 0;
                    string p5 = "";

                    MatchCollection matches = Regex.Matches(_answer, @"\d+");


                    // Check if at least three numbers were found
                    if (matches.Count >= 3)
                    {
                        // Parse and store the extracted numbers in separate variables
                        p2 = int.Parse(matches[0].Value);
                        p3 = int.Parse(matches[1].Value);
                        p4 = int.Parse(matches[2].Value);
                    }
                    int firstNumberIndex = FindFirstNumberIndex(_answer);
                    if (firstNumberIndex != -1)
                    {
                        // Extract the first part before the first number
                        string firstPart = _answer.Substring(0, firstNumberIndex);
                        p1 = firstPart.Trim();
                    }
                    string[] words = _answer.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    // Check if there are any words in the array
                    if (words.Length > 0)
                    {
                        // Get the last word (last element) in the array
                        string lastWord = words[words.Length - 1];
                        p5 = lastWord.Trim();
                    }

                    // Here we have all the parameters. Let's go....
                    _topic = p1;
                    nBook = p2;
                    nChapters = p3;
                    nExamples = p4;
                    if (p5.Contains("yes") || p5.Contains("Yes")) { p5 = "true"; }
                    if (p5.Contains("no") || p5.Contains("No")) { p5 = "false"; }
                    nImages = Convert.ToBoolean(p5);
                    _params = p1 + ":" + p2.ToString() + ":" + p3.ToString() + ":" + p4.ToString() + ":" + p5;
                    return _params;
                }
                else
                {
                    Console.WriteLine("You want to try again.");
                }
            }
            else
            {
                Console.WriteLine("Couldn't find the specified text in the input.");

            }
        }
        catch (Exception e)
        {
            return e.Message;
        }
        return "";

    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Query if 's' is numeric. </summary>
    ///
    /// <remarks>   Shadow, 4/2/2024. </remarks>
    ///
    /// <param name="s">    The string. </param>
    ///
    /// <returns>   True if numeric, false if not. </returns>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    static bool IsNumeric(string s)
    {
        return double.TryParse(s, out _);
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Gets restapi call content. </summary>
    ///
    /// <remarks>   Shadow, 12/5/2023. The usual helper about Web response stuff. </remarks>
    ///
    /// <param name="uri">  URI of the resource. </param>
    ///
    /// <returns>   The restapi call content. </returns>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static string GetRESTAPICallContent(string uri)
    {

        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
        string getResponse;

        try
        {
            WebResponse webResponse = request.GetResponse();
            Stream webStream = webResponse.GetResponseStream();
            StreamReader responseReader = new StreamReader(webStream);
            string response = responseReader.ReadToEnd();
            getResponse = response;
            responseReader.Close();
            return response;
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Makes book with static string. </summary>
    ///
    /// <remarks>   Shadow, 12/4/2023. Create the content files. Easy stuff. </remarks>
    ///
    /// <returns>   True if it succeeds, false if it fails. </returns>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    private static async Task<bool> MakeBookWithStaticString()
    {
        string makeTableOfContents = @"Provide a table of contents of 5 chapters for a book about The History of Computers.
                Use this structure:
                <nr>:X <title>/
                <nr>:<nr> <paragraph_title with underscore between the words><content copy of paragraph_title without the underscores>/
                <nr>:<nr> <paragraph_title with underscore between the words><content copy of paragraph_title without the underscores>/
                <nr>:<nr> <paragraph_title with underscore between the words><content copy of paragraph_title without the underscores>/
                <nr>:<nr> <paragraph_title with underscore between the words><content copy of paragraph_title without the underscores>/
                Like this example structure:
                1.:X Introduction/
                1:1 The_field_of_Math The field of Math/
                1:2 Math_to_the_Max Math to the Max/
                1:3 New_Formulas New Formulas/
                1:4 New_Formulas New Formulas/
                2:X The Team/
                2:1 Members_in_the_Team Members of the Team/
                2:2 Specialities_of_the_Team Specialities of the Team/
                2:3 Goals_of_the_team Goals of the Team/
                2:4 Goals_of_the_team Goals of the Team/";


        string subjectDescription = makeTableOfContents;

        for (int i = 1; i < 3; i++)
        {
            Console.WriteLine("Generating Table of Contents..." + i.ToString());

            string outputFileName = "TableOfContents" +
            DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + ".txt";

            using (StreamWriter sw = new StreamWriter(outputFileName))
            {
                string chapterTitle = await GetChatGPTSmallToken(subjectDescription);
                sw.WriteLine(chapterTitle);

            }
            Console.WriteLine($"Table of Contents generated and saved to {outputFileName}");
        }
        return true;
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Makes book with variable strings. </summary>
    ///
    /// <remarks>   Shadow, 12/4/2023. Create the content files. Easy stuff. </remarks>
    ///
    /// <param name="chaptersTopic">    The chapters topic. </param>
    /// <param name="amountOfTopics">   The amount of topics. </param>
    /// <param name="chapters">         The chapters. </param>
    /// <param name="amountBooks">      The amount books. </param>
    /// <param name="AITopic">          True to ai topic. </param>
    /// <param name="theFiles">         the files. </param>
    /// <param name="kindOfBook">       The kind of book. </param>
    ///
    /// <returns>   A List&lt;string&gt; </returns>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    private static async Task<List<string>> MakeBookWithVariableStrings(string chaptersTopic, int amountOfTopics, 
        int chapters, int amountBooks, bool AITopic, List<string>? theFiles, string kindOfBook)
    {
        System.Speech.Synthesis.SpeechSynthesizer speechSynthesizer = new System.Speech.Synthesis.SpeechSynthesizer();
        List<string> _chaptersTopics = new List<string>();
        List<string> _filesForConvertionToBooks = new List<string>();
        Console.WriteLine("Book subject given:" + chaptersTopic);
        if (AITopic)
        {
            for (int i = 1; i <= amountOfTopics; i++)
            {
                string tTitle = await GetChatGPTSmallToken("Give a topic title for a book about:" + chaptersTopic);
                _chaptersTopics.Add(tTitle.Trim());
            }
        }
        else
        {
            _chaptersTopics = theFiles;
        }
        List<string> sTitle = new List<string>();
        sTitle.Add("");
        foreach (var item in _chaptersTopics)
        {
            if (_fromBible) // Extra things to do if we try to make Bible books.
            {
                string pattern = @"(\d+:\d+)";

                // Find the first match using the pattern
                Match match = Regex.Match(item, pattern);

                if (match.Success)
                {
                    // Get the matched text
                    string matchedText = match.Value;

                    // Get the index of the matched text in the input string
                    int index = item.IndexOf(matchedText);

                    if (index >= 0)
                    {
                        // Extract everything before the matched text
                        string result = item.Substring(0, index + matchedText.Length);
                        string resultFinal = _publishfile + result;
                        _bPrefix = resultFinal;
                    }
                }
                else
                {
                    Console.WriteLine("No <nr>:<nr> combination found in the input string.");
                }
            }
        

            for (int i = 0; i < amountBooks; i++)
            {
                Console.WriteLine("Generating Table of Contents..." + i.ToString());

                //string outputFileName = i.ToString() + " " + RemoveNonLetters(item) + "_" +
                //DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + ".txt";

                string o = item.Replace(":", "-");
                string outputFileName = RemoveNonLetters(o) + ".txt";
                outputFileName = GlobalMethods.RemoveLeadingNumbers(outputFileName);
                outputFileName = SanitizeFileName(outputFileName.Replace("\r", " ").Replace("\n", " ").Replace("\t", " ").Replace("'", ""));
                StreamWriter sw;
                string allChapters = "";
                try
                {
                    if (_fromBible)
                    {
                        CreateThrillerBookTitles._topic = _bPrefix;
                        CreateThrillerBookTitles.wordsUsed = "";
                        CreateThrillerBookTitles._chapters = chapters;
                        CreateThrillerBookTitles._paragraphs = Convert.ToInt16(_bParagraphs);
                        CreateThrillerBookTitles._fromWhere = "bible";
                        CreateThrillerBookTitles._ai_model = Secrets._ai_model;
                        CreateThrillerBookTitles._ChatGPT = Secrets._ChatGPT;
                        var chapterParagraphTitles = await CreateThrillerBookTitles.CreateTitles();
                        
                        foreach (var chapter in chapterParagraphTitles)
                        {
                            allChapters += $"{chapter.Key.Replace("\"", " ")}" + " about " + _bPrefix + "/" + '\n';
                            foreach (var paragraphTitle in chapter.Value)
                            {
                                string underS = paragraphTitle.Replace(" ", "_");
                                Console.WriteLine($"{chapter.Key}" +
                                    $"{DeleteSingleSemiColon(GlobalMethods.RemoveDigitsAndNonLetters(underS))} " +
                                    $"{DeleteSingleSemiColon(GlobalMethods.RemoveDigitsAndNonLetters(paragraphTitle))}");
                                allChapters +=
                                    $"{underS.Replace("\"", " ")}" + " " +
                                    $"{DeleteSingleSemiColon(GlobalMethods.RemoveDigitsAndNonLetters(paragraphTitle.Replace("\"", " ")))}" + " about " + _bPrefix + "/" + '\n';
                            }
                            Console.WriteLine();
                        }
                        try
                        {
                            File.WriteAllText(outputFileName, allChapters);

                            string directoryPath = Directory.GetCurrentDirectory();
                            string fullFileName = directoryPath + "\\" + outputFileName;
                            _filesForConvertionToBooks.Add(fullFileName);
                        }
                        catch(Exception ex) // Bad code cause abusing the catch. It shortens the title and keeps essence.
                        {
                            int lastIndex = FindLastNumberIndex(outputFileName);

                            // Extract substring after the last number
                            string result = outputFileName.Substring(lastIndex + 1).Trim();
                            string resultFirst = outputFileName.Substring(0, lastIndex + 1).Trim();
                            resultFirst.Replace(".txt", "");

                            string shortter = await GetChatGPTSmallToken(
                                "Copy the same title but make it not longer than 130 characters and keep the essence of the old title:"
                                + result);
                            string fS = resultFirst + " " + shortter + ".txt";
                            fS = RemoveIllegalCharacters(fS);
                            // Save sanitized input to a file, the ai title.
                            File.WriteAllText(fS, allChapters);

                            string directoryPath = Directory.GetCurrentDirectory();
                            string fullFileName = directoryPath + "\\" + fS;
                            _filesForConvertionToBooks.Add(fullFileName);
                        }

                       
                    }
                    else if(_IsThriller.Contains("yes"))
                    {
                        CreateThrillerBookTitles._topic = item.Trim();
                        CreateThrillerBookTitles.wordsUsed = "";
                        CreateThrillerBookTitles._chapters = chapters;
                        CreateThrillerBookTitles._paragraphs = Convert.ToInt16(_bParagraphs);
                        CreateThrillerBookTitles._fromWhere = "thriller";
                        CreateThrillerBookTitles._ai_model = Secrets._ai_model;
                        CreateThrillerBookTitles._ChatGPT = Secrets._ChatGPT;
                        _thrillerCharacters = await GetChatGPTSmallToken("Create a list of 10 characters for a book based on this topic " + item.Trim() + " and mention their age, gender, education and occupation");
                        CreateThrillerBookTitles._characters = _thrillerCharacters;
                        var chapterParagraphTitles = await CreateThrillerBookTitles.CreateTitles();
                        
                        foreach (var chapter in chapterParagraphTitles)
                        {
                            allChapters += $"{chapter.Key.Replace("\"", " ")}" + "/" + '\n';
                            foreach (var paragraphTitle in chapter.Value)
                            {
                                string underS = paragraphTitle.Replace(" ", "_");
                                Console.WriteLine($"{chapter.Key}" +
                                    $"{DeleteSingleSemiColon(GlobalMethods.RemoveDigitsAndNonLetters(underS))} " +
                                    $"{DeleteSingleSemiColon(GlobalMethods.RemoveDigitsAndNonLetters(paragraphTitle))}");
                                allChapters += 
                                    $"{underS.Replace("\"", " ")}" + " " +
                                    $"{DeleteSingleSemiColon(GlobalMethods.RemoveDigitsAndNonLetters(paragraphTitle.Replace("\"", " ")))}" + "/" + '\n';
                            }
                            Console.WriteLine();
                        }
                       
                        File.WriteAllText(outputFileName, allChapters);

                        string directoryPath = Directory.GetCurrentDirectory();
                        string fullFileName = directoryPath + "\\" + outputFileName;
                        _filesForConvertionToBooks.Add(fullFileName);
                    }
                    else
                    {
                        CreateThrillerBookTitles._topic = item.Trim();
                        CreateThrillerBookTitles.wordsUsed = "";
                        CreateThrillerBookTitles._chapters = chapters;
                        CreateThrillerBookTitles._paragraphs = Convert.ToInt16(_bParagraphs);
                        CreateThrillerBookTitles._ai_model = Secrets._ai_model;
                        CreateThrillerBookTitles._ChatGPT = Secrets._ChatGPT;
                        var chapterParagraphTitles = await CreateThrillerBookTitles.CreateTitles();
                       
                        foreach (var chapter in chapterParagraphTitles)
                        {
                            allChapters += $"{chapter.Key.Replace("\"", " ")}" + "/" + '\n';
                            foreach (var paragraphTitle in chapter.Value)
                            {
                                string underS = paragraphTitle.Replace(" ", "_");
                                Console.WriteLine($"{chapter.Key}" +
                                    $"{DeleteSingleSemiColon(GlobalMethods.RemoveDigitsAndNonLetters(underS))} " +
                                    $"{DeleteSingleSemiColon(GlobalMethods.RemoveDigitsAndNonLetters(paragraphTitle))}");
                                allChapters +=
                                    $"{underS.Replace("\"", " ")}" + " " +
                                    $"{DeleteSingleSemiColon(GlobalMethods.RemoveDigitsAndNonLetters(paragraphTitle.Replace("\"", " ")))}" + "/" + '\n';
                            }
                            Console.WriteLine();
                        }

                        File.WriteAllText(outputFileName, allChapters);

                        string directoryPath = Directory.GetCurrentDirectory();
                        string fullFileName = directoryPath + "\\" + outputFileName;
                        _filesForConvertionToBooks.Add(fullFileName);
                    }
                }
                catch (Exception ex) { }

                if (_speak)
                {
                    TextToSpeechClient client = IniGoogleSound();
                    string textToSynthesize = "Finished checking. Writing file.";
                    GlobalMethods.DoSpeak(client, textToSynthesize);
                }

            }
        }
        return _filesForConvertionToBooks;
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Searches for the last number index. </summary>
    ///
    /// <remarks>   Shadow, 4/2/2024. </remarks>
    ///
    /// <param name="str">  The string. </param>
    ///
    /// <returns>   The found number index. </returns>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    static int FindLastNumberIndex(string str)
    {
        for (int i = str.Length - 1; i >= 0; i--)
        {
            if (char.IsDigit(str[i]))
            {
                return i;
            }
        }
        return -1; // No number found
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Removes the illegal characters described by input. </summary>
    ///
    /// <remarks>   Shadow, 4/2/2024. </remarks>
    ///
    /// <param name="input">    The input. </param>
    ///
    /// <returns>   A string. </returns>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    static string RemoveIllegalCharacters(string input)
    {
        // Define the pattern of illegal characters
        string pattern = "[^a-zA-Z0-9 .\\-]";
        // Replace illegal characters with an empty string
        return Regex.Replace(input, pattern, "");
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Gets paragraphs new. </summary>
    ///
    /// <remarks>   Shadow, 4/2/2024. </remarks>
    ///
    /// <param name="basedOn">  The based on. </param>
    /// <param name="number">   Number of. </param>
    /// <param name="cTitle">   The title. </param>
    /// <param name="previous"> The previous. </param>
    ///
    /// <returns>   The paragraphs new. </returns>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    private static async Task<List<string>> GetParagraphsNew(string basedOn, int number, string cTitle, string previous)
    {
        List<string> titleNames = new List<string>();

        for (int i = 0; i < number; i++)
        {
            string pTitle = await GetChatGPTSmallToken("Generate ONE unique titles without the number, exploring a different aspect or perspective of  " + basedOn.Trim()
                + " together with " + cTitle
                + " and take into account previous text " + previous);
            string resultString = Regex.Replace(pTitle, @"\d", "");
            //pTitle = resultString.Replace(":", "").Replace("(", "").Replace(")", "");
            string modifiedTitle = "";
            if (_fromBible)
                modifiedTitle = pTitle + " related to " + GlobalMethods.RemoveLeadingNumbers(cTitle);
            else
                modifiedTitle = pTitle;

            titleNames.Add(modifiedTitle.Trim());
        }

        return titleNames;

    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Gets the paragraphs. </summary>
    ///
    /// <remarks>   Shadow, 4/2/2024. </remarks>
    ///
    /// <param name="basedOn">      The based on. </param>
    /// <param name="number">       Number of. </param>
    /// <param name="cTitle">       The title. </param>
    /// <param name="previous">     The previous. </param>
    /// <param name="characters">   The characters. </param>
    ///
    /// <returns>   The paragraphs. </returns>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    private static async Task<List<string>> GetParagraphs(string basedOn, int number, string cTitle, string previous, string characters)
    {
        string s1 = "";
        string s2 = "";
        string s3 = "";
        string pTitle = "";
        if (_IsThriller.Contains("yes"))
        {
            var TwoLinesfromFile = GlobalMethods.ReadContentOfFileThreeLinesInVars("sTwoLinesChapterTitlesThriller.txt");
            s1 = TwoLinesfromFile.First();
            s2 = TwoLinesfromFile[1];
            s3 = TwoLinesfromFile.Last();
            pTitle = await GetChatGPTSmallToken(s1 + " " + number.ToString() +
                " " + s2 + " and based on " + basedOn.Trim() + 
               " separated by carriage returns.");
        }
        else
        {
            List<string> TwoLinesfromFile = new List<string>();
            TwoLinesfromFile = GlobalMethods.ReadContentOfFileTwoLinesInVars("sTwoLinesChapterTitles.txt");
            s1 = TwoLinesfromFile.First();
            s2 = TwoLinesfromFile.Last();
            pTitle = await GetChatGPTSmallToken(s1 + " " + number.ToString() +
                " " + s2 + " " + basedOn.Trim()
               + " separated by carriage returns.");
        }
        

        pTitle = DeleteSingleSemiColon(pTitle);
        

        string[] lines = pTitle.Split('\n', StringSplitOptions.RemoveEmptyEntries);

        // Create a List<string> to store the extracted title names
        List<string> titleNames = new List<string>();

        // Process each line to add "related to" after the last word in each title
        foreach (string line in lines)
        {
            string[] words = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (words.Length > 0)
            {
                string lastWord = words[words.Length - 1];
                string modifiedTitle = "";
                if (_fromBible)
                    modifiedTitle = line + " related to " + GlobalMethods.RemoveLeadingNumbers(cTitle);
                else
                    modifiedTitle = line;
                if (modifiedTitle.Length >= 10 && GlobalMethods.StartsWithNumberUsingRegex(modifiedTitle))
                    titleNames.Add(modifiedTitle);
            }
        }

        return titleNames;

    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Deletes the single semi colon described by pTitle. </summary>
    ///
    /// <remarks>   Shadow, 4/2/2024. </remarks>
    ///
    /// <param name="pTitle">   The title. </param>
    ///
    /// <returns>   A string. </returns>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static string DeleteSingleSemiColon(string pTitle)
    {
        string pattern = @"(?<![0-9]):|:(?![0-9])";
        string result = Regex.Replace(pTitle, pattern, "");

        return result;
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Makes book with variable strings thriller. </summary>
    ///
    /// <remarks>   Shadow, 4/2/2024. </remarks>
    ///
    /// <param name="chaptersTopic">        The chapters topic. </param>
    /// <param name="amountOfTopics">       The amount of topics. </param>
    /// <param name="chapters">             The chapters. </param>
    /// <param name="amountBooks">          The amount books. </param>
    /// <param name="AITopic">              True to ai topic. </param>
    /// <param name="theFiles">             the files. </param>
    /// <param name="kindOfBook">           The kind of book. </param>
    /// <param name="_topicOfThriller">     The topic of thriller. </param>
    /// <param name="_numberOfCharacters">  Number of characters. </param>
    ///
    /// <returns>   A List&lt;string&gt; </returns>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    private static async Task<List<string>> MakeBookWithVariableStringsThriller(string chaptersTopic, int amountOfTopics,
        int chapters, int amountBooks, bool AITopic, List<string>? theFiles, string kindOfBook,
        string _topicOfThriller, string _numberOfCharacters)
    {
        System.Speech.Synthesis.SpeechSynthesizer speechSynthesizer = new System.Speech.Synthesis.SpeechSynthesizer();
        List<string> _chaptersTopics = new List<string>();
        List<string> _filesForConvertionToBooks = new List<string>();
        List<string> contentFile = new List<string>();
        Console.WriteLine("Book subject given:" + chaptersTopic);
        if (AITopic)
        {
            for (int i = 1; i <= amountOfTopics; i++)
            {
                string tTitle = await GetChatGPTSmallToken("Give a topic title for a book about:" + chaptersTopic);
                _chaptersTopics.Add(tTitle.Trim());
            }
        }
        else
        {
            _chaptersTopics = theFiles;
        }

       

        foreach (var item in _chaptersTopics)
        {
            #region CreateCharacters
            string appPath = AppDomain.CurrentDomain.BaseDirectory;
            string filePathCharacters = "characters.txt"; // Path to the file
            string filePathStorySegments = "storysegmentsWork.txt"; // Path to the file
            string filePathStorySegmentsClean = "storysegments.txt"; // Path to the file
            string _charactersFull = "";

            string sCleanCharacters = "";
            string sCleanSegments = "";

            string makeSegmenStorylines = @"Make a list of " + chapters + @" Storylines for a thriller about "
    + item.Trim()
    + @". Do that in this format and structure:
            <Title>|<Story line>
            <Title>|<Story line>
            <Title>|<Story line>
            And do not include a line like this <Title>|<Plot>|<Story line>
            and remove all leading carriage returns '\n', spaces and other characters.";
            try
            {
                string thrillerSegmentStoryLines = await GetChatGPTSmallToken(makeSegmenStorylines);
                sCleanSegments = thrillerSegmentStoryLines.Replace("\r\nName: < name >, Description: < Role in the story, education and background >\n\n", "")
                    .Replace("\n\n", "").Replace("\r\n\n", "").Replace("\r\n\r\n", "");
                File.WriteAllText(filePathStorySegments, sCleanSegments);
                Console.WriteLine("File written successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            GlobalMethods.Say("Wrote the chapters without characters for character building.");
            // Create characters based on the storyline

            string makeCharacers = @"Make a list of " + _numberOfCharacters + @" characters for a thriller about "
    + item.Trim() + @" and give the characters a gender and a role in this storylines:" + sCleanSegments
    + @". Do that in this format and structure:
< name >|< Role in the story, education and background >
< name >|< Role in the story, education and background >
And do not include a line like this < name >|< Role in the story, education and background >";

            try
            {
                string thrillerCharacters = await GetChatGPTSmallToken(makeCharacers);
                sCleanCharacters = thrillerCharacters.Replace("\r\nName: < name >, Description: < Role in the story, education and background >\n\n", "")
                    .Replace("\n\n", "").Replace("\r\n\n", "").Replace("\r\n\r\n", "");
                File.WriteAllText(filePathCharacters, sCleanCharacters);
                Console.WriteLine("File written successfully.");
                _charactersFull = sCleanCharacters;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            GlobalMethods.Say("Wrote characters based on the chapters.");

            string makeTableOfContents = @"provide a table of contents of " + chapters.ToString() + " chapters, for a book about " + item.Trim() + ". " +
                "Use these characters " + sCleanCharacters + @" at the place of <Characters> consistently throughout the story."
+ " place the Storyline of the chapter between <Storyline> as a consistent story line."
+ "Use this structure:";

            makeTableOfContents += @"
<nr>:X <title>/
<nr>:C <Characters>/
<nr>:P <Plot>/
<nr>:P <Storyline>/
<nr>:<nr> <paragraph_title_with_underscore_between_the_words><content copy of paragraph_title without the underscores>/
<nr>:<nr> <paragraph_title_with_underscore_between_the_words><content copy of paragraph_title without the underscores>/
<nr>:<nr> <paragraph_title_with_underscore_between_the_words><content copy of paragraph_title without the underscores>/
<nr>:X <title>/
<nr>:C <Characters>/
<nr>:P <Plot>/
<nr>:P <Storyline>/
<nr>:<nr> <paragraph_title_with_underscore_between_the_words><content copy of paragraph_title without the underscores>/
<nr>:<nr> <paragraph_title_with_underscore_between_the_words><content copy of paragraph_title without the underscores>/
<nr>:<nr> <paragraph_title_with_underscore_between_the_words><content copy of paragraph_title without the underscores>/
Exactly Like this example structure:
1:X Introduction/
1:C Perry Rhodan the adventurer. Malik the scientist.
1:P Perry is introduced as is the main line of the story
1:S Perry is preparing himself to go on the yourney
1:1 The_field_of_Math The field of Math/
1:2 Math_to_the_Max Math to the Max/
1:3 New_Formulas New Formulas/
2:X The Team/
2:C Perry Rhodan the adventurer. Malik the scientist. Koral the Hacker.
2:P The team is introduced towards the rest of the story
1:S The 
2:1 Members_in_the_Team Members of the Team/
2:2 Specialities_of_the_Team Specialities of the Team/
2:3 Goals_of_the_team Goals of the Team/";

            try
            {
                string thrillerSegmentStoryLines = await GetChatGPTSmallToken(makeTableOfContents);
                makeTableOfContents = thrillerSegmentStoryLines;
                File.WriteAllText(filePathStorySegmentsClean, thrillerSegmentStoryLines);
                Console.WriteLine("File written successfully.");

                try
                {
                    
                   
                    using (StreamWriter writer = new StreamWriter(filePathStorySegmentsClean))
                    {
                            // Write the non-empty line to the cleaned file
                            writer.WriteLine(thrillerSegmentStoryLines);
                    }
                   
                    Console.WriteLine("Empty lines removed and the cleaned file is written successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            GlobalMethods.Say("Wrote the chapters including the characters.");
            // Get the characters for the thriller
            List<Character> characters = ReadCharactersFromFile(appPath + filePathCharacters);

            // Display the characters
            foreach (var character in characters)
            {
                Console.WriteLine($"Name: {character.Name}, Description: {character.Description}");
            }
            static List<Character> ReadCharactersFromFile(string filePath)
            {
                var characters = new List<Character>();
                var lines = File.ReadAllLines(filePath);

                foreach (var line in lines)
                {
                    var parts = line.Split('|');
                    if (parts.Length == 2)
                    {
                        characters.Add(new Character(parts[0], parts[1]));
                    }
                }

                return characters;
            }


            #endregion

            
            #region CleanFile
            
            for (int i = 0; i < amountBooks; i++)
            {
                Console.WriteLine("Generating Table of Contents..." + i.ToString());

                //string outputFileName = i.ToString() + " " + RemoveNonLetters(item) + "_" +
                //DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + ".txt";

                string o = item.Replace(":", "-");
                string outputFileName = RemoveNonLetters(o) + ".txt";
                outputFileName = SanitizeFileName(outputFileName.Replace("\r", " ").Replace("\n", " ").Replace("\t", " ").Replace("'", ""));
                outputFileName = "Z - T - " + outputFileName;
                StreamWriter sw;

                string fileName = Path.GetFileName(outputFileName);
                string directoryPath = Directory.GetCurrentDirectory();
                string fullFileName = directoryPath + "\\" + fileName;

                try
                {

                    using (sw = new StreamWriter(fullFileName))
                    {
                       
                           sw.WriteLine(makeTableOfContents);
                            
                        
                        
                    }
                }
                catch (Exception ex)
                {
                    TextToSpeechClient client = IniGoogleSound();
                    string textToSynthesize = "I encountered a long filename. Will make it shorter.";
                    GlobalMethods.DoSpeak(client, textToSynthesize);

                    string ff = outputFileName.Substring(0, outputFileName.Length - Directory.GetCurrentDirectory().Length + 5);
                    outputFileName = SanitizeFileName(ff);
                    fullFileName = outputFileName + ".txt";
                    using (sw = new StreamWriter(fullFileName))
                    {
                       
                            sw.WriteLine(makeTableOfContents);
                            
                        
                    }
                }
                string publishFilename = "Z - T - " + "storysegments" + ".html";

                string _prefix = publishFilename;
                string doBlob = "";
                if (_prefix.Length > 0 && _prefix.Contains("Bible - ")) // First parts of the Bible
                {
                    doBlob = await GlobalMethods.writeFileToBlob(makeTableOfContents.Replace("\n", "<br>")
                       , GlobalMethods.DeleteFirstNumber(publishFilename).Replace("\"", ""),
                       @"https://dailybiblestorage.blob.core.windows.net/aibookengine/", "aibookengine");
                }
                else if (_prefix.Length > 0 && _prefix.Contains("Bible -- ")) // Second parts of the Bible
                {
                    doBlob = await GlobalMethods.writeFileToBlob(makeTableOfContents.Replace("\n", "<br>")
                       , GlobalMethods.DeleteFirstNumber(publishFilename).Replace("\"", ""),
                       @"https://dailybiblestorage.blob.core.windows.net/aibookengine2/", "aibookengine2");
                }
                else // No Bible books
                {
                    doBlob = await GlobalMethods.writeFileToBlob(makeTableOfContents.Replace("\n", "<br>")
                       , GlobalMethods.DeleteFirstNumber(publishFilename).Replace("\"", ""),
                       @"https://dailybiblestorage.blob.core.windows.net/aibookengine3/", "aibookengine3");
                }
                
                _filesForConvertionToBooks.Add(fullFileName);
                Console.WriteLine($"Table of Contents generated and saved to {fullFileName}");
                TextToSpeechClient clientt = IniGoogleSound();
                string textToSynthesizes = "File written.";
                GlobalMethods.DoSpeak(clientt, textToSynthesizes);
            }
        }
        #endregion

        return _filesForConvertionToBooks;
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

    static string SanitizeFileName(string input)
    {
        char[] invalidChars = Path.GetInvalidFileNameChars();

        // Replace invalid characters with an underscore
        string sanitized = string.Join("_", input.Split(invalidChars, StringSplitOptions.RemoveEmptyEntries));

        // Check if the sanitized string is not empty
        if (!string.IsNullOrEmpty(sanitized))
        {
            // Truncate the sanitized string if it exceeds the maximum allowed length
            int maxFileNameLength = 260; // Windows file system limit
            if (sanitized.Length > maxFileNameLength)
            {
                sanitized = sanitized.Substring(0, maxFileNameLength);
            }

            return sanitized;
        }

        return null; // The input contains only invalid characters
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Gets chat gpt small token. </summary>
    ///
    /// <remarks>   Shadow, 12/4/2023. </remarks>
    ///
    /// <param name="textToAsk">    The text to ask. </param>
    ///
    /// <returns>   The chat gpt small token. </returns>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    private async static Task<string> GetChatGPTSmallToken(string textToAsk)
    {
        bool goOn = true;
        while (goOn)
        {
            try
            {
                var openAI = new OpenAI_API.OpenAIAPI(Secrets._ChatGPT);


                CompletionRequest completion = new CompletionRequest();
                completion.Prompt = textToAsk;
                completion.MaxTokens = 1500;
                completion.Model = Secrets._ai_model; // Set the model ID for GPT-3.5-turbo
                var result = await openAI.Completions.CreateCompletionAsync(completion);
                string answer = "";
                if (result != null)
                {
                    foreach (var item in result.Completions)
                    {
                        answer += item.Text;
                    }
                    goOn = false;
                    return answer;
                }
                else
                {

                    goOn = false;
                    return "No results from BlackBeltBible AI.";
                }
                
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        return "After GoOn";
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A chat gpt request. </summary>
    ///
    /// <remarks>   Shadow, 4/2/2024. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class ChatGPTRequest
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the prompt. </summary>
        ///
        /// <value> The prompt. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string Prompt { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the maximum tokens. </summary>
        ///
        /// <value> The maximum tokens. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int MaxTokens { get; set; } = 100; // Adjust as needed
                                                  // Add other necessary fields as per OpenAI's API documentation
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Call chat gpt 4. </summary>
    ///
    /// <remarks>   Shadow, 4/2/2024. </remarks>
    ///
    /// <param name="prompt">   The prompt. </param>
    ///
    /// <returns>   A string. </returns>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static async Task<string> CallChatGPT4(string prompt)
    {
        try
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.openai.com/v1/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Secrets._ChatGPT);

                var request = new ChatGPTRequest { Prompt = prompt };
                var jsonRequest = System.Text.Json.JsonSerializer.Serialize(request);
                var content = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");

                var finalUrl = client.BaseAddress + "engines/gpt-4.0-turbo/completions";
                Console.WriteLine(finalUrl);

                var response = await client.PostAsync("engines/gpt-4.0-turbo/completions", content);
                response.EnsureSuccessStatusCode();

                var responseString = await response.Content.ReadAsStringAsync();
                return responseString;
            }
        }
        catch (HttpRequestException httpEx)
        {
            // Handle HTTP-specific exception here
            return httpEx.Message;
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A chat gpt response. </summary>
    ///
    /// <remarks>   Shadow, 4/2/2024. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class ChatGPTResponse
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the text. </summary>
        ///
        /// <value> The text. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string Text { get; set; }
        // Add other fields as per the API response
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Gets chat gpt response. </summary>
    ///
    /// <remarks>   Shadow, 4/2/2024. </remarks>
    ///
    /// <param name="prompt">   The prompt. </param>
    ///
    /// <returns>   The chat gpt response. </returns>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public async Task<ChatGPTResponse> GetChatGPTResponse(string prompt)
    {
        var responseString = await CallChatGPT4(prompt);
        var response = System.Text.Json.JsonSerializer.Deserialize<ChatGPTResponse>(responseString);
        return response;
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Gets chat gpt 4. </summary>
    ///
    /// <remarks>   Shadow, 4/2/2024. </remarks>
    ///
    /// <param name="textToAsk">    The text to ask. </param>
    ///
    /// <returns>   The chat gpt 4. </returns>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    private async static Task<string> GetChatGPT4(string textToAsk)
    {
        

        return "";
    }

    private static string GetGooglePrompt(string textToAsk)
    {
        string responseText = GetRESTAPICallContent(Secrets._ChatGoogleAPI
                                + "Wo was Plato.");
        return responseText;

    }
    private static string GetChatGPTBlobPrompt(string textToAsk)
    {
        string responseText = GetRESTAPICallContent(Secrets._ChatGPTAPIBlob
                                + "Wo was Plato.");
        return responseText;

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
            var openAI = new OpenAI_API.OpenAIAPI(Secrets._ChatGPT);


            CompletionRequest completion = new CompletionRequest();
            completion.Prompt = textToAsk;
            completion.MaxTokens = 1000;
            completion.Model = Secrets._ai_model; // Set the model ID for GPT-3.5-turbo
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
    /// <summary>   Removes the non letters described by input. </summary>
    ///
    /// <remarks>   Shadow, 12/4/2023. </remarks>
    ///
    /// <param name="input">    The input. </param>
    ///
    /// <returns>   A string. </returns>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    static string RemoveNonLetters(string input)
    {
        string pattern = "[^a-zA-Z0-9\\s-_:]";

        string replacement = string.Empty;
        Regex regex = new Regex(pattern);

        string result = regex.Replace(input, replacement);
        return result;
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Removes the non letters for talk described by input. </summary>
    ///
    /// <remarks>   Shadow, 4/2/2024. </remarks>
    ///
    /// <param name="input">    The input. </param>
    ///
    /// <returns>   A string. </returns>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    static string RemoveNonLettersForTalk(string input)
    {
        string pattern = "[^a-zA-Z0-9\\s-.:,ÄäÖöÜüß]";

        string replacement = string.Empty;
        Regex regex = new Regex(pattern);

        string result = regex.Replace(input, replacement);
        return result;
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Removes the non letters for book described by input. </summary>
    ///
    /// <remarks>   Shadow, 4/2/2024. </remarks>
    ///
    /// <param name="input">    The input. </param>
    ///
    /// <returns>   A string. </returns>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    static string RemoveNonLettersForBook(string input)
    {
        string pattern = "\"[^a-zA-Z0-9\\s,\":.()?!']\"";

        string replacement = string.Empty;
        Regex regex = new Regex(pattern);
        
        string result = regex.Replace(input, replacement);
        return result;
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Gets chat gpt small token chapters. </summary>
    ///
    /// <remarks>   Shadow, 12/4/2023. </remarks>
    ///
    /// <param name="textToAsk">    The text to ask. </param>
    ///
    /// <returns>   The chat gpt small token chapters. </returns>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    private async static Task<string> GetChatGPTSmallTokenChapters(string textToAsk)
    {

        try
        {
            var openAI = new OpenAI_API.OpenAIAPI(Secrets._ChatGPT);


            CompletionRequest completion = new CompletionRequest();
            completion.Prompt = textToAsk;
            completion.MaxTokens = 2000;
            completion.Model = Secrets._ai_model; // Set the model ID for GPT-3.5-turbo
            var result = await openAI.Completions.CreateCompletionAsync(completion);
            string answer = "";
            if (result != null)
            {
                foreach (var item in result.Completions)
                {
                    answer += item.Text;
                }
                if (IsLineWithOnlyColon(answer))
                {
                    return "";
                }
                else
                {
                    return RemoveEmptyLines(answer).Replace(".:X", ":X").Replace(": X", ":X").Replace(".X", ":X")
                        .Replace(": X ", ":X").Replace("Table of Contents", "").Replace(". X", ":X")
                        .Replace(".:", ":X").TrimStart();
                }
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
    /// <summary>   Gets dalle image 512. </summary>
    ///
    /// <remarks>   Shadow, 12/4/2023. </remarks>
    ///
    /// <param name="textToGenerateImage">  The text to generate image. </param>
    ///
    /// <returns>   The dalle image 512. </returns>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    private async static Task<string> GetDalleImage512(string textToGenerateImage)
    {

        var openAI = new OpenAI_API.OpenAIAPI(Secrets._ChatGPT);

        var imageRequest = new ImageGenerationRequest
        {
            Prompt = textToGenerateImage, // Your prompt
            NumOfImages = 1,
            Size = ImageSize._512 // Image size
        };

        try
        {
            var result = await openAI.ImageGenerations.CreateImageAsync(imageRequest);
            var img = result.Data[0].Url;
            return img;
        }
        catch (Exception ex)
        {
            return "Error: " + ex.Message;
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Gets dalle image 1024. </summary>
    ///
    /// <remarks>   Shadow, 12/4/2023. </remarks>
    ///
    /// <param name="textToGenerateImage">  The text to generate image. </param>
    ///
    /// <returns>   The dalle image 1024. </returns>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    private async static Task<string> GetDalleImage1024(string textToGenerateImage)
    {

        var openAI = new OpenAI_API.OpenAIAPI(Secrets._ChatGPT);

        var imageRequest = new ImageGenerationRequest
        {
            Prompt = textToGenerateImage, // Your prompt
            NumOfImages = 1,
            Size = ImageSize._1024 // Image size
        };

        try
        {
            var result = await openAI.ImageGenerations.CreateImageAsync(imageRequest);
            var img = result.Data[0].Url;
            return img;
        }
        catch (Exception ex)
        {
            return "Error: " + ex.Message;
        }
    }
    private async static Task<string> GetDalleGood(string textForImage)
    {
        string apiKey = Secrets._ChatGPT;  // Replace with your actual OpenAI API key
        string endpoint = "https://api.openai.com/v1/images/generations";
        var client = new HttpClient();
        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiKey);

        var requestBody = new
        {
            model = "dall-e-3",  // Model name
            prompt = textForImage,  // Your prompt
            size = "1024x1024",  // Image size
            quality = "standard",  // Image quality
            n = 1  // Number of images to generate
        };

        string jsonContent = JsonConvert.SerializeObject(requestBody);
        var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

        try
        {
            HttpResponseMessage response = await client.PostAsync(endpoint, content);
            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<dynamic>(responseContent);
                string imageUrl = result.data[0].url;
                Console.WriteLine("Image URL: " + imageUrl);
                return imageUrl;
            }
            else
            {
                Console.WriteLine($"Failed to generate image: {response.StatusCode} - {response.ReasonPhrase}");
                return "Failed:" + response.ReasonPhrase;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            return "Error:" + ex.Message;
        }
        return "Done";
    }
    public async static Task<string> GetDalleGoodForTile(string textForImage)
    {
        string apiKey = Secrets._ChatGPT;  // Replace with your actual OpenAI API key
        string endpoint = "https://api.openai.com/v1/images/generations";
        var client = new HttpClient();
        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiKey);

        var requestBody = new
        {
            model = "dall-e-3",  // Model name
            prompt = textForImage,  // Your prompt
            size = "1024x1024",  // Image size
            quality = "standard",  // Image quality
            n = 1  // Number of images to generate
        };

        string jsonContent = JsonConvert.SerializeObject(requestBody);
        var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

        try
        {
            HttpResponseMessage response = await client.PostAsync(endpoint, content);
            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<dynamic>(responseContent);
                string imageUrl = result.data[0].url;
                Console.WriteLine("Image URL: " + imageUrl);
                return imageUrl;
            }
            else
            {
                Console.WriteLine($"Failed to generate image: {response.StatusCode} - {response.ReasonPhrase}");
                return "Failed:" + response.ReasonPhrase;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            return "Error:" + ex.Message;
        }
        return "Done";
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Gets dalle image 256. </summary>
    ///
    /// <remarks>   Shadow, 12/4/2023. </remarks>
    ///
    /// <param name="textToGenerateImage">  The text to generate image. </param>
    ///
    /// <returns>   The dalle image 256. </returns>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    private async static Task<string> GetDalleImage256(string textToGenerateImage)
    {

        var openAI = new OpenAI_API.OpenAIAPI(Secrets._ChatGPT);

        var imageRequest = new ImageGenerationRequest
        {
            Prompt = textToGenerateImage, // Your prompt
            NumOfImages = 1,
            Size = ImageSize._256 // Image size
        };

        try
        {
            var result = await openAI.ImageGenerations.CreateImageAsync(imageRequest);
            var img = result.Data[0].Url;
            return img;
        }
        catch (Exception ex)
        {
            return "Error: " + ex.Message;
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Query if 'line' is line with only colon. </summary>
    ///
    /// <remarks>   Shadow, 12/4/2023. </remarks>
    ///
    /// <param name="line"> The line. </param>
    ///
    /// <returns>   True if line with only colon, false if not. </returns>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    static bool IsLineWithOnlyColon(string line)
    {
        // Use regular expression to check if the line contains only a colon
        return Regex.IsMatch(line.Trim(), @"^:$");
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Removes the empty lines described by input. </summary>
    ///
    /// <remarks>   Shadow, 12/4/2023. </remarks>
    ///
    /// <param name="input">    The input. </param>
    ///
    /// <returns>   A string. </returns>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    static string RemoveEmptyLines(string input)
    {
        // Use regular expression to remove empty lines.
        string pattern = @"^\s*$[\r\n]*";
        string replacement = string.Empty;
        Regex regex = new Regex(pattern, RegexOptions.Multiline);

        string result = regex.Replace(input, replacement);
        result.Replace(".:X", ":X").Replace(" :X", ":X").Replace(" :X ", ":X");
        return result;
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Makes the books. </summary>
    ///
    /// <remarks>   Shadow, 12/4/2023. </remarks>
    ///
    /// <param name="theBooks">     the books. </param>
    /// <param name="level">        The level. </param>
    /// <param name="withImages">   True to with images. </param>
    ///
    /// <returns>   A string. </returns>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    private static async Task<string> MakeTheBooks(List<string> theBooks, string level, bool withImages)
    {
        System.Speech.Synthesis.SpeechSynthesizer speechSynthesizer = new System.Speech.Synthesis.SpeechSynthesizer();
        try
        {
            foreach (var item in theBooks)
            {
                _Bbook = item.Trim();
                string getBook = await AnswersTextFileGPT4ENG(item, level, withImages);
                int lastIndex = item.LastIndexOf('\\'); // Find the last backslash
                string lastPart = "";
                try
                {

                    if (_doscommand.Contains("batch"))
                    {
                        lastPart = item.Substring(lastIndex + 1); // Get the part after the last backslash
                        string sFileName = "1" + lastPart.Replace("txt", "html");

                        string _prefix = sFileName;
                        string doBlob = "";
                        if (_prefix.Length > 0 && _publishfile.Replace("\"", "").Contains("Bible - ")) // First parts of the Bible
                        {
                            string fFileName = _publishfile.Replace("\"", "") + GlobalMethods.DeleteFirstNumber(sFileName).Replace("\"", "");
                            GlobalMethods.deleteFileFromBlob(fFileName, "aibookengine");
                            fFileName = "_" + fFileName;
                            doBlob = await GlobalMethods.writeFileToBlob(getBook
                            , fFileName,
                               Secrets.partBlob + "aibookengine/", "aibookengine");
                        }
                        else if (_prefix.Length > 0 && _publishfile.Replace("\"", "").Contains("Bible -- ")) // Second parts of the Bible
                        {
                            string fFileName = _publishfile.Replace("\"", "") + GlobalMethods.DeleteFirstNumber(sFileName).Replace("\"", "");
                            GlobalMethods.deleteFileFromBlob(fFileName, "aibookengine2");
                            fFileName = "_" + fFileName;
                            doBlob = await GlobalMethods.writeFileToBlob(getBook
                            , fFileName ,
                               Secrets.partBlob + "aibookengine2/", "aibookengine2");
                        }
                        else if (_prefix.Length > 0 && _publishfile.Replace("\"", "").Contains("Bible --- ")) // Second parts of the Bible
                        {
                            doBlob = await GlobalMethods.writeFileToBlob(getBook
                            , _publishfile.Replace("\"", "") + GlobalMethods.DeleteFirstNumber(sFileName).Replace("\"", ""),
                               Secrets.partBlob + "aibookengine3/", "aibookengine3");
                        }
                        else // No Bible books
                        {
                            doBlob = await GlobalMethods.writeFileToBlob(getBook
                            , _publishfile.Replace("\"", "") + GlobalMethods.DeleteFirstNumber(sFileName).Replace("\"", ""),
                               Secrets.partBlob + "aibookengine4/", "aibookengine4");
                        }                       
                    }
                }
                catch (Exception ex)
                {
                    TextToSpeechClient client = IniGoogleSound();
                    string textToSynthesize = "I encountered a long filename. Will make it shorter.";
                    GlobalMethods.DoSpeak(client, textToSynthesize);

                    lastPart = item.Substring(lastIndex + 1); // Get the part after the last backslash
                    string sFileName = "1" + lastPart.Replace("txt", "html");
                    string ff = sFileName.Substring(0, sFileName.Length - Directory.GetCurrentDirectory().Length + 5);
                    sFileName = SanitizeFileName(ff);

                    string _prefix = sFileName;
                    string doBlob = "";
                    if (_prefix.Length > 0 && _prefix.Contains("Bible - ")) // First parts of the Bible
                    {
                        doBlob = await GlobalMethods.writeFileToBlob(getBook
                        , _publishfile.Replace("\"", "") + GlobalMethods.DeleteFirstNumber(sFileName).Replace("\"", ""),
                           Secrets.partBlob + "aibookengine/", "aibookengine");
                    }
                    else if (_prefix.Length > 0 && _prefix.Contains("Bible -- ")) // Second parts of the Bible
                    {
                        doBlob = await GlobalMethods.writeFileToBlob(getBook
                        , _publishfile.Replace("\"", "") + GlobalMethods.DeleteFirstNumber(sFileName).Replace("\"", ""),
                           Secrets.partBlob + "aibookengine2/", "aibookengine2");
                    }
                    else // No Bible books
                    {
                        doBlob = await GlobalMethods.writeFileToBlob(getBook
                        , _publishfile.Replace("\"", "") + GlobalMethods.DeleteFirstNumber(sFileName).Replace("\"", ""),
                           Secrets.partBlob + "aibookengine3/", "aibookengine3");
                    }
                }


                if (lastIndex >= 0 && lastIndex < item.Length - 1)
                {
                    lastPart = item.Substring(lastIndex + 1); // Get the part after the last backslash
                    string sFileName = "1" + lastPart.Replace("txt", "html");
                    File.WriteAllText(GlobalMethods.DeleteFirstNumber(sFileName), sFileName + "<hr>" + getBook);
                    Console.WriteLine("************************************************************************");
                    Console.WriteLine($"Book content saved to {sFileName}");
                    Console.WriteLine("************************************************************************");

                    if (_VProvider.Equals(1))
                    {
                        speechSynthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult, 3, new System.Globalization.CultureInfo("en-US"));
                        speechSynthesizer.Speak("I have written a finished book to disk.");
                    }
                    else
                    {
                        TextToSpeechClient client = IniGoogleSound();
                        string textToSynthesize = "I have written a finished book to disk.";
                        GlobalMethods.DoSpeak(client, textToSynthesize);
                    }
                }

            }
            return "Ready creating books.";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Answers text file gpt 4 eng. </summary>
    ///
    /// <remarks>   Shadow, 12/4/2023. </remarks>
    ///
    /// <param name="_filePath">        Full pathname of the file. </param>
    /// <param name="_levelOfReader">   The level of reader. </param>
    /// <param name="withImages">       True to with images. </param>
    ///
    /// <returns>   A string. </returns>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static async Task<string> AnswersTextFileGPT4ENG(string _filePath, string _levelOfReader, bool withImages)
    {
        System.Speech.Synthesis.SpeechSynthesizer speechSynthesizer = new System.Speech.Synthesis.SpeechSynthesizer();

        Console.WriteLine("Start writing book:" + _filePath);

        string AllTheAnswers = "";
        string PreviousChapterOrParagraphTitle = "";
        string GetPreviousAnswer = "";
        string GetFullAnswerBasedOnSummary = "";
        string GetBasicSummaryOfCurrent = "";

        int lastIndex = _filePath.LastIndexOf('\\'); // Find the last backslash
        string lastPart = _filePath.Substring(lastIndex + 1); // Get the part after the last backslash
        string sTopicName = lastPart.Replace("txt", "");
        sTopicName = sTopicName.Replace("-", ":");

        string TOC = "";

        // Put some things on "" and Check on null.
        AllTheAnswers = "";
        PreviousChapterOrParagraphTitle = "";
        if (GetPreviousAnswer == null)
            GetPreviousAnswer = "";
        try
        {
            // Get the file with the content.
            string filePath = _filePath;
            string fileContent;

            // Read the file.
            using (StreamReader reader = new StreamReader(filePath))
            {
                fileContent = reader.ReadToEnd(); // read the entire contents of the file
            }

            try
            {
                //*************************************************************************************************************
                // Text structure that will be disected.
                //*************************************************************************************************************
                // 1:X Introduction/
                // 1:1 Why_pray_tell_should_we_add_another_tome_to_the_already_teeming_library_of_AI_literature? Why, pray tell, should we add another tome to the already teeming library of AI literature ?/
                // 1:2 The_disquieting_paradox The Disquieting Paradox/
                // 2:X The Rise of AI /
                // 2:1 Artificial_intelligence_weaves_itself_into_the_very_fabric_of_our_world Artificial Intelligence Weaves Itself into the Very Fabric of Our World/
                // 2:2 Sinister_forces_lurk_in_the_shadows Sinister Forces Lurk in the Shadows/
                //  
                // What will be done:
                //*************************************************************************************************************
                // Separate titles will be put in a string (the ones with the :X).
                // The paragraphs will be put in a string (the one with the _ underscores).
                // The program will build text based upon the titles of the paragraphs.
                // The sAmbiance string will determine HOW the book will be written.
                // The sSummary string will determine HOW the summary will be written.
                //*************************************************************************************************************

                List<string> lines = fileContent.Split(new[] { @"/" }, StringSplitOptions.RemoveEmptyEntries).ToList();
                string sTitle = "";

                int para = 0;
                int tit = 0;

                // Walk through the whole content and get the titles and paragraphs and write the book.
                for (int iW = 0; iW <= lines.Count - 1; iW++)
                {
                    string pattern = @"[^\n\r:,\.\s\w]+|[\r\n\t]+";
                    string replacement = "";
                    string output = "";
                    output = Regex.Replace(lines[iW].ToString(), pattern, replacement);

                    string sumOutput = lines[iW].ToString();

                    string ChapterOrQuestion = @"(\d+:\d+\s*\d*|\d+:\d+)";

                    string outputS = "";

                    string sAmbiance = "";

                    // Dictate the writing style
                    if (_fromBible)
                    {
                        sAmbiance = GlobalMethods.ReadContentOfFile("sAmbianceBible.txt"); // Steer the writing style
                    }
                    else if (_IsThriller.Contains("yes"))
                    {
                        sAmbiance = GlobalMethods.ReadContentOfFile("sAmbianceThriller.txt"); // Steer the writing style
                        sAmbiance += " " + _thrillerCharacters;
                    }
                    else
                    {
                        sAmbiance = GlobalMethods.ReadContentOfFile("sAmbianceBusiness.txt"); // Steer the writing style
                    }
                    

                    // This string will determine how the summary is being build
                    string sSummary = "Write a short summary of approximately 1000 tokens according to ChatGPT about:";

                    if (output.Contains(":X"))
                    {
                        tit += 1;
                        //outputS = Regex.Replace(output, ChapterOrQuestion, "");
                        //outputS = RemoveNonLetters(output);
                        outputS = output;

                        // Add HTML anchor tags to the string
                        string anchorTag = $"<a name=\"{outputS}\"></a>";
                        string formattedString = $"<hr><h2>{anchorTag}Chapter: {outputS.TrimStart()} **</h2>";

                        // Create a separate string with the call to the anchor
                        TOC += $"<a href=\"#{outputS}\">Link to Chapter {outputS}</a><br>";

                        AllTheAnswers += formattedString;

                        if (withImages)
                        {
                            string _img = await GetDalleImage256(outputS.TrimStart());

                            string tableHtml = @"
                            <table style='border-collapse: collapse; border: 5px solid lightblue;'>
                                <tr>
                                    <td>
                                        <img src='" + _img + @"' style='width: 100%; height: auto; display: block;' />
                                    </td>
                                </tr>
                            </table>
                            ";
                            AllTheAnswers += tableHtml + "<hr>";
                        }

                        sTitle = outputS.Replace(":", " ").Trim().Replace("X", "");
                        if (_speak)
                        {
                            if (_VProvider.Equals(1))
                            {
                                speechSynthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult, 3, new System.Globalization.CultureInfo("en-US"));
                                speechSynthesizer.Speak("Writing the title:" + sTitle);
                                CheckLevelOfAIAnswer(speechSynthesizer,
                                "I Wrote a title to the book called " + sTitle,
                                "Tell the user you will write the title " + sTitle + " and give your brief opinion about this title related to " + _topic + ", in maximum 2 sentences.",
                                "Tell the user you will write the title " + sTitle + " and give your full philosophical opinion about this title related to " + _topic);
                            }
                            else
                            {
                                TextToSpeechClient client = IniGoogleSound();
                                string textToSynthesize = "Writing the title:" + sTitle;
                                GlobalMethods.DoSpeak(client, textToSynthesize);
                                CheckLevelOfAIAnswer(speechSynthesizer,
                               "I Wrote a title to the book called " + sTitle,
                               "Tell the user you will write the title " + sTitle + " and give your brief opinion about this title related to " + _topic + ", in maximum 2 sentences.",
                               "Tell the user you will write the title " + sTitle + " and give your full philosophical opinion about this titlerelated to " + _topic);
                            }
                        }
                        else
                        {
                            if (_speak)
                            {
                                if (_VProvider.Equals(1))
                                {
                                    speechSynthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult, 3, new System.Globalization.CultureInfo("en-US"));
                                    speechSynthesizer.Speak("Writing the title:" + sTitle);
                                }
                                else
                                {
                                    TextToSpeechClient client = IniGoogleSound();
                                    string textToSynthesize = "Writing the title:" + sTitle;
                                    GlobalMethods.DoSpeak(client, textToSynthesize);
                                }
                            }

                        }
                        if (_speak)
                        {
                            if (_VProvider.Equals(1))
                            {
                                speechSynthesizer.Speak("I will now start writing the paragraph");
                            }
                            else
                            {
                                TextToSpeechClient client = IniGoogleSound();
                                string textToSynthesize = "I will now start writing the paragraph";
                                GlobalMethods.DoSpeak(client, textToSynthesize);
                            }
                        }

                    }
                    else
                    {
                        if (output.Contains(":C") || output.Contains(":S") || output.Contains(":P"))
                        {
                            // No actions yet for Plot, Characters and Storyline
                        }
                        else
                        {
                            if (_speak)
                            {
                                if (_VProvider.Equals(1))
                                {
                                    speechSynthesizer.Speak("Working on another paragraph.");
                                }
                                else
                                {
                                    TextToSpeechClient client = IniGoogleSound();
                                    string textToSynthesize = "Working on another paragraph.";
                                    GlobalMethods.DoSpeak(client, textToSynthesize);
                                }
                            }
                            //outputS = Regex.Replace(output, ChapterOrQuestion, "");
                            //outputS = RemoveNonLetters(output);
                            outputS = output;
                            string[] words = outputS.Split(' ');
                            string firstWord = words[0]; // get the first word from the array
                            string[] remainingWords = words.Skip(1).ToArray(); // skip the first word and create a new array
                            string outputSA = String.Join(" ", remainingWords); // join the remaining words into a string
                            string integrateIntoStory = " integrate in the story this remark:";
                            string buildUpOn = " building upon:";
                            string basedOn = " and based on this title:";
                            string relatedToTitleOfChapter = " and related to the title of this chapter ";
                            string asAContinuationOf = " build further on the previous part of the story ";
                            string basedUpOnTitleAndParagraphHeader = " and based upon this title and paragraph header:";

                            // If summary is empty, create one upfront.
                            // First part of if is forst part of book. Second part is the rest of the book.
                            if (GetPreviousAnswer.ToString().Contains("XX"))
                            {
                                GetPreviousAnswer = await GetChatGPTSmallToken(sSummary + outputSA.TrimStart());
                                if (_thrillerStuff.Length >= 3)
                                {
                                    GetFullAnswerBasedOnSummary = await GetChatGPTSmallToken(sAmbiance + " and a larger version of:" + GetPreviousAnswer
                                   + integrateIntoStory + _thrillerStuff
                                   + basedOn + sTopicName);
                                }
                                else if (_extraSummary.Length >= 3)
                                {
                                    GetFullAnswerBasedOnSummary = await GetChatGPTSmallToken(sAmbiance + " and a larger version of:" + GetPreviousAnswer
                                    + integrateIntoStory + _extraSummary
                                    + basedOn + sTopicName);
                                }
                                else if (_thrillerStuff.Length >= 3 && _extraSummary.Length >= 3)
                                {
                                    GetFullAnswerBasedOnSummary = await GetChatGPTSmallToken(sAmbiance + " and a larger version of:" + GetPreviousAnswer
                                    + integrateIntoStory + _thrillerStuff + _extraSummary
                                    + basedOn + sTopicName);
                                }
                                else
                                {
                                    GetFullAnswerBasedOnSummary = await GetChatGPTSmallToken(sAmbiance + " and a larger version of:" + GetPreviousAnswer
                                    + basedOn + sTopicName);
                                }

                                string fWord = firstWord.Replace("_", " ").Replace("/ ", "/").Replace("// ", "/").Trim() + " **";
                                string anchorTag = $"<a name=\"{fWord}\"></a>";
                                string formattedString = $"<h3><u>{anchorTag}Chapter: {fWord.TrimStart()}</u></h3>";

                                // Create a separate string with the call to the anchor
                                TOC += $"<a href=\"#{fWord}\">Link to Chapter {fWord}</a><br>";

                                if (_speak)
                                {
                                    if (_language.Equals("NL"))
                                    {
                                        TranslationClient cc = InitializeGoogleTranslation();
                                        var responseNL = cc.TranslateText(GetFullAnswerBasedOnSummary, "nl");
                                        GetFullAnswerBasedOnSummary = responseNL.TranslatedText;
                                    }
                                    else if (_language.Equals("DE"))
                                    {
                                        TranslationClient cc = InitializeGoogleTranslation();
                                        var response = cc.TranslateText(RemoveNonLettersForTalk(GetFullAnswerBasedOnSummary), "de");
                                        GetFullAnswerBasedOnSummary = response.TranslatedText;
                                    }
                                }

                                AllTheAnswers += formattedString;
                                AllTheAnswers += GetFullAnswerBasedOnSummary.ToString();
                            }
                            else
                            {
                                para += 1;
                                if (_thrillerStuff.Length >= 3)
                                {
                                    GetBasicSummaryOfCurrent = await GetChatGPTSmallToken(sSummary + outputSA.TrimStart()
                                    + buildUpOn + GetPreviousAnswer
                                    + integrateIntoStory + _thrillerStuff +
                                    relatedToTitleOfChapter + sTitle);
                                }
                                else if (_extraSummary.Length >= 3)
                                {
                                    GetBasicSummaryOfCurrent = await GetChatGPTSmallToken(sSummary + outputSA.TrimStart()
                                    + buildUpOn + GetPreviousAnswer
                                    + integrateIntoStory + _extraSummary +
                                    relatedToTitleOfChapter + sTitle);
                                }
                                else if (_thrillerStuff.Length >= 3 && _extraSummary.Length >= 3)
                                {
                                    GetBasicSummaryOfCurrent = await GetChatGPTSmallToken(sSummary + outputSA.TrimStart()
                                    + buildUpOn + GetPreviousAnswer
                                    + integrateIntoStory + _thrillerStuff + _extraSummary +
                                    relatedToTitleOfChapter + sTitle);
                                }
                                else
                                {
                                    GetBasicSummaryOfCurrent = await GetChatGPTSmallToken(sSummary + outputSA.TrimStart()
                                    + buildUpOn + GetPreviousAnswer
                                    + relatedToTitleOfChapter + sTitle);
                                }
                                string patternParagraph = @"\w+_\w+"; // Matches words with underscores between them

                                outputS = Regex.Replace(outputS, patternParagraph, "");

                                string fWord = firstWord.Replace("_", " ").Replace("/ ", "/").Replace("// ", "/").Trim();
                                outputS = Regex.Replace(outputS, "^::\\d+\\s+", "");
                                outputS.Replace(".:::", "");
                                outputS = GlobalMethods.RemoveBeforeLetters(outputS);
                                string anchorTag = $"<a name=\"{outputS}\"></a>";
                                string formattedString = $"<h3><u>{anchorTag}Paragraph: {outputS.TrimStart()} **</u></h3>";


                                // TOC += $"<a href=\"#{outputS.TrimStart()}\">Link to Paragraph {outputS.TrimStart()}</a><br>";

                                PreviousChapterOrParagraphTitle = outputS.Trim();

                                if (_fromBible)
                                {
                                    string patternPrefix = @"\w+\s+(\d+-\d+)";

                                    // Find the first match using the pattern
                                    Match match = Regex.Match(lastPart, patternPrefix);

                                    if (match.Success)
                                    {
                                        // Get the matched text
                                        string matchedText = match.Value;

                                        // Get the index of the matched text in the input string
                                        int index = lastPart.IndexOf(matchedText);

                                        if (index >= 0)
                                        {
                                            // Extract everything before the matched text
                                            string result = lastPart.Substring(0, index + matchedText.Length);
                                            string resultFinal = _publishfile + result;
                                            _bPrefix = resultFinal;
                                        }
                                    }
                                    _bPrefix = _bPrefix.Replace("-", ":");

                                    string patternCheckDigits = @"^[^\d]*$";
                                    _bSummary = "12345";
                                    while (!Regex.IsMatch(_bSummary, patternCheckDigits))
                                        _bSummary = await GetChatGPTSmallToken("Give a summary of five lines without numbers of this particular part of the Bible:"
                                                + _bPrefix);

                                    GetFullAnswerBasedOnSummary = await GetChatGPTSmallToken(sAmbiance + "  about this specific part from the Bible: "
                                          + _bPrefix + " " + _bSummary
                                          + " and the titles " + sTitle + " - " + outputS + " and DO NOT USE EXTERNAL SOURCES OR REFERENCES " +
                                          "OUTSIDE THE BIBLE ITSELF.");

                                }
                                else if(_IsThriller.Contains("yes"))
                                {
                                    GetFullAnswerBasedOnSummary = await GetChatGPTSmallToken(sAmbiance
                                            + asAContinuationOf + _SummaryOfPreviousThrillerPart
                                            + " about " + GetBasicSummaryOfCurrent
                                            + " and based on "
                                            + outputS);
                                    _SummaryOfPreviousThrillerPart = GetFullAnswerBasedOnSummary;
                                }
                                else
                                {
                                    //GetFullAnswerBasedOnSummary = await GetChatGPTSmallToken(sAmbiance  
                                    //        + " and based on "
                                    //        + outputS);
                                    GetFullAnswerBasedOnSummary = await GetChatGPTSmallToken(sAmbiance
                                            + asAContinuationOf + GetPreviousAnswer
                                            + " and based on "
                                            + outputS + " and " + sTitle);
                                }


                                // Get the first part of the string without the _ underscores.
                                AllTheAnswers += formattedString;


                                //*************************************************************************************************************
                                // Lazy code. Eliminating bad starts of lines instead of solving the problem. I'll leave it up to the smarties.
                                // Some chapters started with a continuation of the paragraph title as a sentence without capital before
                                // the first line of the text. Find the error and you're less lazy than this old fart.
                                // *************************************************************************************************************
                                if (_speak)
                                {
                                    if (_language.Equals("NL"))
                                    {
                                        TranslationClient cc = InitializeGoogleTranslation();
                                        var responseNL = cc.TranslateText(GetFullAnswerBasedOnSummary, "nl");
                                        GetFullAnswerBasedOnSummary = responseNL.TranslatedText;
                                    }
                                    else if (_language.Equals("DE"))
                                    {
                                        TranslationClient cc = InitializeGoogleTranslation();
                                        var response = cc.TranslateText(RemoveNonLettersForTalk(GetFullAnswerBasedOnSummary), "de");
                                        GetFullAnswerBasedOnSummary = response.TranslatedText;
                                    }
                                }
                                AllTheAnswers +=
                                        WrapListItemsWithLiAndUlTags(CheckFirstPart(GetFullAnswerBasedOnSummary.ToString()));
                                GetPreviousAnswer = GetBasicSummaryOfCurrent;

                                //if(_IsThriller.Contains("yes")) // Get history in Chunks GPT fed and save.
                                //{
                                //    int maxChunkSize = 500; // Maximum length of each chunk

                                //    List<string> chunks = SplitTextIntoChunks(sHis, maxChunkSize);

                                //    foreach (string chunk in chunks)
                                //    {
                                //        // Call your ChatGPT prompt with the current chunk as input
                                //        _SummaryOfPreviousThrillerPart += await GetChatGPTSmallToken("Create a summary of 3 lines based on " + chunk);
                                //        string directoryPath = Directory.GetCurrentDirectory();
                                //        string fullFileName = directoryPath + "\\" + "summaries";

                                //        GlobalMethods.AppendTextToFile(fullFileName, outputS + '\n');
                                //        GlobalMethods.AppendTextToFile(fullFileName, _SummaryOfPreviousThrillerPart + '\n' + '\n');
                                //    }

                                //}

                                // *************************************************************************************************************
                            }
                            Console.WriteLine("Line written:" + GetFullAnswerBasedOnSummary.ToString());

                            if (_speak)
                            {
                                if (_VProvider.Equals(1))
                                {
                                    speechSynthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult, 3, new System.Globalization.CultureInfo("en-US"));
                                    speechSynthesizer.Speak("Writing the paragraph:" + PreviousChapterOrParagraphTitle);
                                    CheckLevelOfAIAnswer(speechSynthesizer,
                                    "I Wrote a paragraph to the book called " + PreviousChapterOrParagraphTitle,
                                    "Tell the user you wrote the paragraph " + PreviousChapterOrParagraphTitle + " and give your brief opinion about this paragraph title related to " + sTitle + " and " + _topic + " in maximum 2 sentences.",
                                    "Tell the user you wrote the paragraph " + PreviousChapterOrParagraphTitle + " and give your full philosophical opinion about this paragraph title related to " + sTitle + " and " + _topic);
                                }
                                else
                                {
                                    CheckLevelOfAIAnswer(speechSynthesizer,
                                    "I Wrote a paragraph to the book called " + PreviousChapterOrParagraphTitle,
                                    "Tell the user you wrote the paragraph " + PreviousChapterOrParagraphTitle + " and give your brief opinion about this paragraph title related to " + sTitle + " and " + _topic + " in maximum 2 sentences.",
                                    "Tell the user you wrote the paragraph " + PreviousChapterOrParagraphTitle + " and give your full philosophical opinion about this paragraph title related to " + sTitle + " and " + _topic);
                                }
                            }
                            else
                            {
                                if (_speak)
                                {
                                    if (_VProvider.Equals(1))
                                    {
                                        speechSynthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult, 3, new System.Globalization.CultureInfo("en-US"));
                                        speechSynthesizer.Speak("I wrote the paragraph:" + PreviousChapterOrParagraphTitle);
                                    }
                                    else
                                    {
                                        TextToSpeechClient client = IniGoogleSound();
                                        string textToSynthesize = "I wrote the paragraph:" + PreviousChapterOrParagraphTitle;
                                        GlobalMethods.DoSpeak(client, textToSynthesize);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string er = ex.Message;
                return "Error:" + er;
            }
        }
        catch (Exception ex)
        {
            string er = ex.Message;
            return "Error:" + er;
        }
        string tableHtmlMain = "";

        if (withImages)
        {
            string _imgMain = await GetDalleImage1024(_subject);

            tableHtmlMain = @"
                        <center>
                        <table style='border-collapse: collapse; border: 10px solid lightblue;'>
                            <tr>
                                <td>
                                    <img src='" + _imgMain + @"' style='width: 100%; height: auto; display: block;' />
                                </td>
                            </tr>
                        </table>
                        </center>
                    ";
        }

        string newText = "Back to top";

        lastIndex = TOC.LastIndexOf("Link to Paragraph");

        if (lastIndex >= 0)
        {
            TOC = TOC.Substring(0, lastIndex) + newText;
        }

        if (withImages)
        {
            AllTheAnswers = tableHtmlMain + "<h1>Index</h1>" + "<hr>" + TOC + "<hr>" + AllTheAnswers;
        }
        else
        {
            AllTheAnswers = "<h1>Index</h1>" + "<hr>" + TOC + "<hr>" + AllTheAnswers;
        }

        return AllTheAnswers;
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Splits text into chunks. </summary>
    ///
    /// <remarks>
    /// Shadow, 2/4/2024. If we want to keep history for Thriller, we need to split in chunks.
    /// </remarks>
    ///
    /// <param name="text">         The text. </param>
    /// <param name="maxChunkSize"> The maximum size of the chunk. </param>
    ///
    /// <returns>   A List&lt;string&gt; </returns>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    static List<string> SplitTextIntoChunks(string text, int maxChunkSize)
    {
        List<string> chunks = new List<string>();

        for (int i = 0; i < text.Length; i += maxChunkSize)
        {
            int length = Math.Min(maxChunkSize, text.Length - i);
            string chunk = text.Substring(i, length);
            chunks.Add(chunk);
        }

        return chunks;
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Check level of an i answer. </summary>
    ///
    /// <remarks>   Shadow, 4/2/2024. </remarks>
    ///
    /// <param name="speechSynthesizer">    The speech synthesizer. </param>
    /// <param name="answer1">              The first answer. </param>
    /// <param name="answer2">              The second answer. </param>
    /// <param name="answer3">              The third answer. </param>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    private static async void CheckLevelOfAIAnswer(System.Speech.Synthesis.SpeechSynthesizer speechSynthesizer, string answer1, string answer2, string answer3)
    {
        string languagestring = "";
        string textToSynthesize = "";
        TextToSpeechClient client = IniGoogleSound();
        if (_AILevel.Equals(1))
        {
            if (_VProvider.Equals(1))
            {
                speechSynthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult, 3, new System.Globalization.CultureInfo("en-US"));
                speechSynthesizer.Speak(answer1);
            }
            else
            {
                textToSynthesize = answer1;
                GlobalMethods.DoSpeak(client, textToSynthesize);
            }
        }
        if (_AILevel.Equals(2))
        {
            if (_VProvider.Equals(1))
            {
                string answer = GetRESTAPICallContent(Secrets._ChatGPTAPI
                        + answer2);
                answer.Replace("Response from AI:", "");
                speechSynthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult, 3, new System.Globalization.CultureInfo("en-US"));
                speechSynthesizer.Speak(answer);
            }
            else
            {
                languagestring = "";
                if (_prompt_provider.Contains("Google"))
                {
                    languagestring = GetGooglePrompt(answer2);
                }
                else if (_prompt_provider.Contains("ChatGPT"))
                    languagestring = GetRESTAPICallContent(Secrets._ChatGPTAPI
                            + answer2);
                else
                {
                    Console.WriteLine("Wrong AI chosen.");
                    return;
                }

            }
            

        }
        if (_AILevel.Equals(3))
        {
            if (_VProvider.Equals(1))
            {
                string answer = GetRESTAPICallContent(Secrets._ChatGPTAPI
                        + answer3);
                answer.Replace("Response from AI:", "");
                speechSynthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult, 3, new System.Globalization.CultureInfo("en-US"));
                speechSynthesizer.Speak(answer);
            }
            else
            {
                languagestring = "";

                if (_loop_discussion.Equals(100)) // For the non Blob calls
                {
                    if (_prompt_provider.Contains("Chato1"))
                    {
                        sFore = answer3;
                        if (liness >= 1)
                        {
                            bigStory += languagestring;
                            sFore += " and Continue the story based on and as a continuation of the previous chapters " +
                            bigStory +
                            " and make it a natural continuation.";
                        }
                        else
                        {
                            sFore += '\n' + sSteeringFirstChapter;
                        }
                        languagestring = await LargeGPT.CallLargeChatGPT(answer3, "o3-mini");
                        liness += 1;
                    }
                    if (_prompt_provider.Contains("ChatGPT"))
                    {
                        if (_with_perkament.Contains("true"))
                        {
                            bool moreThanSixParagraphs = true;
                            while (moreThanSixParagraphs)
                            {
                                languagestring = GetRESTAPICallContent(Secrets._ChatGPTAPI
                                    + answer3 + " Make sure that the poem does not have more than 6 verses.");
                                moreThanSixParagraphs = GlobalMethods.HasMoreThanSixParagraphs(languagestring);
                            }
                        }
                        else // No perkament, normal string work.
                        {
                            languagestring = GetRESTAPICallContent(Secrets._ChatGPTAPI
                           + answer3);
                        }
                        
                        if(_elaborate.Contains("true")) // We want to elaborate on answer.
                        {
                            _discuss_answer = languagestring;
                        }
                    }
                    else if(_prompt_provider.Contains("Google"))
                    {
                        languagestring = "The operation has timed out";
                        while(languagestring.Contains("The operation has timed out"))
                        {
                            languagestring = GetRESTAPICallContent(Secrets._GoogleAPI
                            + answer3);
                        }
                        if (_elaborate.Contains("true")) // We want to elaborate on answer.
                        {
                            _discuss_answer = languagestring;
                        }
                    }
                    else if (_prompt_provider.Contains("Grok"))
                    {
                        languagestring = "The operation has timed out";
                        while (languagestring.Contains("The operation has timed out"))
                        {
                            languagestring = GetRESTAPICallContent(Secrets._GrokAPI
                            + answer3);
                            languagestring = languagestring.Replace("###", "").Replace("**", "").Replace("####", "");
                        }
                        if (_elaborate.Contains("true")) // We want to elaborate on answer.
                        {
                            _discuss_answer = languagestring;
                        }
                    }
                }
                else if(_loop_discussion.Equals(200)) // For the Blob calls
                { 

                    if (_prompt_provider.Contains("Google"))
                    {
                        languagestring = GetGooglePrompt("Create a short summary that is not too big for a ChatGPT prompt for " + answer3);
                    }
                    else if (_prompt_provider.Contains("ChatGPT"))
                    {
                        if (_loop_discussion.Equals(0)) // When 0, always ChatGPT is used.
                        {
                            languagestring = GetRESTAPICallContent(Secrets._ChatGPTAPI
                            + answer3);
                            _discuss_answer = languagestring;
                        }
                        else
                            languagestring = GetChatGPTBlobPrompt(Secrets._ChatGPTAPIBlob
                                + answer3);
                    }
                    else
                    {
                        Console.WriteLine("Wrong AI chosen.");
                        return;
                    }
                }
                else // _loop_discussion standard on 0
                {

                    if (_prompt_provider.Contains("Google"))
                    {
                        languagestring = GetGooglePrompt("Create a short summary that is not too big for a ChatGPT prompt for " + answer3);
                    }
                    else if (_prompt_provider.Contains("ChatGPT"))
                    {
                        if (_loop_discussion.Equals(0)) // When 0, always ChatGPT is used.
                        {
                            languagestring = GetRESTAPICallContent(Secrets._ChatGPTAPI
                            + answer3);
                            _discuss_answer = languagestring;
                        }
                        else
                            languagestring = GetChatGPTBlobPrompt(Secrets._ChatGPTAPIBlob
                                + answer3);
                    }
                    else
                    {
                        Console.WriteLine("Wrong AI chosen.");
                        return;
                    }
                }
            }
        }
        if (_language.Equals("NL") || _language.Equals("NLL"))
        {
            TranslationClient cc = InitializeGoogleTranslation();
            var response = cc.TranslateText(RemoveNonLettersForTalk(languagestring), "nl");
            languagestring = response.TranslatedText;
        }
        else if (_language.Equals("DE") || _language.Equals("DEE"))
        {
            TranslationClient cc = InitializeGoogleTranslation();
            var responseNL = cc.TranslateText(RemoveNonLettersForTalk(languagestring), "nl");
            var response = cc.TranslateText(RemoveNonLettersForTalk(responseNL.TranslatedText), "de");
            languagestring = response.TranslatedText;
        }
        else if (_language.Equals("UK") || _language.Equals("UKK"))
        {
            TranslationClient cc = InitializeGoogleTranslation();
            var response = cc.TranslateText(RemoveNonLettersForTalk(languagestring), "en");
            languagestring = response.TranslatedText;
        }
        else
        {

        }

        languagestring.Replace("Response from AI:", "");
        
        textToSynthesize = languagestring;
        _discuss_answer = textToSynthesize;

        if (_talkfile_Quite.Equals("false"))
        {
            if (_language.Equals("NL"))
            {
                GlobalMethods.DoSpeakNL(client, RemoveNonLettersForTalk(textToSynthesize), _speed);
            }
            else if (_language.Equals("NLL"))
            {
                GlobalMethods.DoSpeakNL(client, RemoveNonLettersForTalk(textToSynthesize), _speed);

            }
            else if (_language.Equals("US"))
            {
                GlobalMethods.DoSpeakUS(client, RemoveNonLettersForTalk(textToSynthesize), _speed);
            }
            else if (_language.Equals("USS"))
            {
                GlobalMethods.DoSpeakUS(client, RemoveNonLettersForTalk(textToSynthesize), _speed);
            }
            else if (_language.Equals("UK"))
            {
                GlobalMethods.DoSpeakUK(client, RemoveNonLettersForTalk(textToSynthesize), _speed);
            }
            else if (_language.Equals("UKK"))
            {
                GlobalMethods.DoSpeakUK(client, RemoveNonLettersForTalk(textToSynthesize), _speed);

            }
            else if (_language.Equals("DE"))
            {
                GlobalMethods.DoSpeakDE(client, RemoveNonLettersForTalk(textToSynthesize), _speed);

            }
            else if (_language.Equals("DEE"))
            {
                GlobalMethods.DoSpeakDE(client, RemoveNonLettersForTalk(textToSynthesize), _speed);
            }
            else if (_language.Equals("BG"))
                GlobalMethods.DoSpeakBG(client, RemoveNonLettersForTalk(textToSynthesize));
            else
                GlobalMethods.DoSpeak(client, RemoveNonLettersForTalk(textToSynthesize));
        }
        Console.WriteLine(textToSynthesize + '\n' + '\n');

        if (_loop_discussion.Equals(100) || _loop_discussion.Equals(200)) // We wanna add in between titles in the text.
        {
            if (_loop_discussion.Equals(200))
            {
                if (_prompt_provider.Contains("Google"))
                    _SomeMoreThoughts = "Critical notes from Google AI";
                else
                    _SomeMoreThoughts = "Some ChatGPT AI thoughts";
                GlobalMethods.AppendBoldTextToWord(_talkfile, _SomeMoreThoughts, false, "Time New Roman", 16);
            }
            if (_Replace_InConclusion.Contains("true"))
            {
                textToSynthesize = GlobalMethods.ReplaceAndCapitalize(textToSynthesize, "In conclusion, ");
                textToSynthesize = GlobalMethods.ReplaceAndCapitalize(textToSynthesize, "In summary, ");
                textToSynthesize = textToSynthesize.Replace("essay", "chapter");
            }
            if(_code_blocks.Contains("true"))
            {
                List<string> codeBlocks = GlobalMethods.ExtractCodeBlocks(textToSynthesize);
                List<string> modifiedCodeBlocks = GlobalMethods.ModifyCodeBlocks(codeBlocks);
                string updatedString = GlobalMethods.ReplaceCodeBlocks(textToSynthesize, modifiedCodeBlocks);
                textToSynthesize = updatedString;

                //GlobalMethods.AppendTextToWordDocumentCorrectFormatSplit(_talkfile, textToSynthesize);

                //foreach (string codeBlock in codeBlocks)
                //{
                //    string Simage = await GetDalleGood("Create an image with this code:"
                //        + codeBlock);
                //    if (Simage.Contains("Bad Request")) // Probably from words and length
                //    {
                //        Simage = await GetDalleGood("Create a Zohar mystical image without text from "
                //        + codeBlock);
                //    }
                //    string sClean = "cImage";
                //    await GlobalMethods.GetImageFromURL(Simage, _talkfile, sClean);
                //    string appPath = AppDomain.CurrentDomain.BaseDirectory;
                //    string imagePath = appPath + sClean + ".jpg";
                //    GlobalMethods.AddImageToWordDocument(_talkfile, imagePath);
                //}
            }
            else
            {
                if (_with_perkament.Contains("true"))
                {
                    GlobalMethods.CreateQuoteBoxWithBackground(imagePathQuote, outputPath, 
                        textToSynthesize.TrimStart('\n'), 13);

                    long quality = 75L;
                    GlobalMethods.LowerImageFileSize(outputPath, perkamentOutFinal, quality);

                    Console.WriteLine($"Image Quote image created at: {outputPath}");
                    GlobalMethods.AddImageToWordDocumentOriginal(_talkfile, perkamentOutFinal, "test");
                }
                else
                {
                    if (_with_bible_letter.Contains("true"))
                    {
                        string sText = textToSynthesize.Replace("\n\n", "").Replace("\n", "");
                        char firstChar = GlobalMethods.GetFirstCharacter(textToSynthesize);
                        string remainingString;
                        GlobalMethods.ExtractFirstCharacter(textToSynthesize, out firstChar, out remainingString);

                        // Retrieve the corresponding image from the dictionary
                        if (_images.TryGetValue(firstChar, out System.Drawing.Image image))
                        {
                            Console.WriteLine($"Image for '{firstChar}' found.");
                            string appPath = AppDomain.CurrentDomain.BaseDirectory;
                            GlobalMethods.AddImageToWordDocumentOriginalWrap(_talkfile, appPath + firstChar + ".jpg", "test",
                                110, 110, "Left");
                            GlobalMethods.AppendTextToWordDocumentCorrectFormatSplit(_talkfile, remainingString);
                        }
                        else
                        {
                            GlobalMethods.AppendTextToWordDocumentCorrectFormatSplit(_talkfile, textToSynthesize);
                        }
                    }
                    else // No perkament, no Bible letter, the normal stuff.
                    {
                        GlobalMethods.AppendTextToWordDocumentCorrectFormatSplit(_talkfile, textToSynthesize, "Times New Roman", 12);
                    }
                       
                }
                
            }
        }
        else
            GlobalMethods.AppendTextToFile(_talkfile, RemoveNonLettersForTalk(textToSynthesize) + '\n' + '\n'); // Save conversation.
        
    }
    private static async Task UploadTextToBlobAsync(CloudBlobContainer blobContainer, string fileName, string contentToUpload)
    {
        // Create a reference to the blob
        CloudBlockBlob blockBlob = blobContainer.GetBlockBlobReference(fileName);

        // Upload text directly to the blob
        await blockBlob.UploadTextAsync(contentToUpload);
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Wrap list items with li and ul tags. </summary>
    ///
    /// <remarks>   Shadow, 12/4/2023. </remarks>
    ///
    /// <param name="input">    The input. </param>
    ///
    /// <returns>   A string. </returns>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    private static string WrapListItemsWithLiAndUlTags(string input)
        {
            StringBuilder result = new StringBuilder();
            bool inList = false;

            using (StringReader reader = new StringReader(input))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (IsListItem(line))
                    {
                        if (!inList)
                        {
                            result.AppendLine("<ul>");
                            inList = true;
                        }
                        result.AppendLine($"<li>{line}</li>");
                    }
                    else
                    {
                        if (inList)
                        {
                            result.AppendLine("</ul>");
                            inList = false;
                        }
                        result.AppendLine(line);
                    }
                }
                if (inList)
                {
                    result.AppendLine("</ul>");
                }
            }

            return result.ToString();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Query if 'line' is list item. </summary>
        ///
        /// <remarks>   Shadow, 12/4/2023. </remarks>
        ///
        /// <param name="line"> The line. </param>
        ///
        /// <returns>   True if list item, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private static bool IsListItem(string line)
        {
            // Use regular expression to check if the line starts with a number followed by a period
            return Regex.IsMatch(line.Trim(), @"^\d+\.\s");
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Check first part. </summary>
        ///
        /// <remarks>   Shadow, 12/4/2023. </remarks>
        ///
        /// <param name="input">    The input. </param>
        ///
        /// <returns>   A string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private static string CheckFirstPart(string input)
        {
            try
            {


                // Define a regular expression pattern to match a non-capitalized word followed by a period (.)
                string pattern = @"[^A-Z][^.]*\.";

                // Use Regex.Match to find the first match in the input string
                Match match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    // Extract the matched substring and everything after it
                    string result = input.Substring(match.Index + match.Length);

                    return result;
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "xx";
        }
}

////////////////////////////////////////////////////////////////////////////////////////////////////
/// <summary>   A character. </summary>
///
/// <remarks>   Shadow, 4/2/2024. </remarks>
////////////////////////////////////////////////////////////////////////////////////////////////////

class Character
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Gets or sets the name. </summary>
    ///
    /// <value> The name. </value>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public string Name { get; set; }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Gets or sets the description. </summary>
    ///
    /// <value> The description. </value>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public string Description { get; set; }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Constructor. </summary>
    ///
    /// <remarks>   Shadow, 4/2/2024. </remarks>
    ///
    /// <param name="name">         The name. </param>
    /// <param name="description">  The description. </param>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public Character(string name, string description)
    {
        Name = name;
        Description = description;
    }

    #region WordDocument

    #endregion
}


