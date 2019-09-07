import axios from "axios";

function getFullUrl(url) {
  const baseUrl = process.env.VUE_APP_BASE_URL;
  return `${baseUrl}${url}`;
}

async function get(url) {
  const response = await axios.get(getFullUrl(url));
  return response.data;
}

async function deleteMethod(url, data) {
  const response = await axios.delete(`${getFullUrl(url)}/${data}`);
  return response.data;
}

async function put(url, id, data) {
  const response = await axios.put(`${getFullUrl(url)}/${id}`, data);
  return response.data;
}

async function post(url, data) {
  const response = await axios.post(getFullUrl(url), data, {
    headers: { "Content-Type": "application/json" }
  });
  return response.data;
}

export { get, post, deleteMethod, put };
