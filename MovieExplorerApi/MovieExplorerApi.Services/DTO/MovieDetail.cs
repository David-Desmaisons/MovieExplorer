﻿using System;

namespace MovieExplorerApi.Services.DTO
{
    public class MovieDetail
    {
        public bool adult { get; set; }
        public string backdrop_path { get; set; }
        public int budget { get; set; }
        public Genre[] genres { get; set; }
        public string homepage { get; set; }
        public int id { get; set; }
        public string imdb_id { get; set; }
        public string original_language { get; set; }
        public string original_title { get; set; }
        public string overview { get; set; }
        public float popularity { get; set; }
        public string poster_path { get; set; }
        public Production_Company[] production_companies { get; set; }
        public Production_Country[] production_countries { get; set; }
        public DateTime release_date { get; set; }
        public int revenue { get; set; }
        public int runtime { get; set; }
        public Spoken_Language[] spoken_languages { get; set; }
        public string status { get; set; }
        public string tagline { get; set; }
        public string title { get; set; }
        public bool video { get; set; }
        public decimal vote_average { get; set; }
        public int vote_count { get; set; }
    }
}