namespace MovieExplorerApi.Services.DTO
{
    public class UpComingMovieResult
    {
        public int page { get; set; }
        public int total_results { get; set; }
        public MovieResult[] results { get; set; }
        public DateRange dates { get; set; }
    }
}
