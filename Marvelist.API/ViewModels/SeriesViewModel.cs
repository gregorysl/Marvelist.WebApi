﻿using System;
using System.Collections.Generic;

namespace Marvelist.API.ViewModels
{
    public class Mvm
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Thumbnail { get; set; }
        public string Description { get; set; }
        public bool Following { get; set; }
    }
    public class SeriesViewModel : Mvm
    {
        public int ComicCount { get; set; }
    }
    public class SeriesComicsViewModel : Mvm
    {
        public List<ComicsViewModel> Comics { get; set; }
    }
    public class ComicsViewModel : Mvm
    {
        public int IssueNumber { get; set; }
        public string ISBN { get; set; }
        public string UPC { get; set; }
        public string DiamondCode { get; set; }
        public string EAN { get; set; }
        public string ISSN { get; set; }
        public int PageCount { get; set; }
        public DateTime Date { get; set; }
        public float Price { get; set; }
    }
}