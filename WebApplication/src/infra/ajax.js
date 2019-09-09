import axios from "axios";

function getFullUrl(url) {
  const baseUrl = process.env.VUE_APP_BASE_URL;
  return `${baseUrl}api/Movies${url}`;
}

async function get(url) {
  const response = await axios.get(getFullUrl(url));
  return response.data;
}

export { get};
