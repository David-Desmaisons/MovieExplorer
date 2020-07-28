//hack utility for flip-card
function isIE11Context() {
  return /Trident/i.test(window.navigator.userAgent);
}

function isChromeContext() {
  return !!window.chrome && !!window.chrome.csi;
}

function getContext() {
  if (isIE11Context()) {
    return "IE11";
  }
  if (isChromeContext()) {
    return "chrome";
  }
  return null;
}

export { getContext };
