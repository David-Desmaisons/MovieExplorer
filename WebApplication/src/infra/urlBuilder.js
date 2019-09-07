const baseUrl = process.env.VUE_APP_IMG_URL;

function buildUrl(path, size = "w500") {
  return `${baseUrl}${size}${path}`;
}

export { buildUrl };
