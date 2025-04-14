using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Writeyourownbooktest.Models
{
    public class GlobalModels
    {
    }
    public class BookViewModel
    {
        public string MainHtmlImageAtTop { get; set; } = "";
        public string TitleOfBook { get; set; } = "";
        public string FirstPageInitiation { get; set; } = "";
        public string HeaderTitleOfBook { get; set; } = "";
        public string NameOfBook { get; set; } = "";
        public string NumberOfPages { get; set; } = "";
        public string BlobFileName { get; set; } = "Cbookdata.txt";
    }
    public class PlotViewModel
    {
        public string BookDescription { get; set; } = "";
        public string BookPlotLine { get; set; } = "";
        public string SteerPlot { get; set; } = "";
        public string SteeringWriters { get; set; } = "";
        public string BookSteeringWheelUniverse { get; set; } = "";
        public string BlobFileName { get; set; } = "Pdochtml.txt";
    }
    public class PromptViewModel
    {
        public string TitlePrefix { get; set; } = "";
        public string ImagePrefix { get; set; } = "";
        public string FirstForePrompt { get; set; } = "";
        public string SecondRunningPrompt { get; set; } = "";
        public string ExtraTouch { get; set; } = "";
        public string BlobFileName { get; set; } = "Cdochtml.txt";
    }

}