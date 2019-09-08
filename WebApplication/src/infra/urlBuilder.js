const baseUrl = process.env.VUE_APP_IMG_URL;

function buildUrl(path, size = "w500") {
  return path === null ? null : `${baseUrl}${size}${path}`;
}

export { buildUrl };
