import { get } from "./ajax";

function mapMovie(movie) {
  return {
    ...movie,
    titleForSearch: movie.title.toLowerCase()
  };
}

async function fetchMovies(page) {
  const result = await get(`Movies?start=${page}`);
  const movies = result.results.map(mapMovie);
  const { total_results } = result;
  return {
    movies,
    page,
    total_results
  };
}

export { fetchMovies };
