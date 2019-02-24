import axios from "axios";
import Cookie from "js-cookie";
const getTokenFromCookie = () => {
  return Cookie.get("token");
};
const writeTokenFromCookie = token => {
  Cookie.set("token", token);
};
const removeCookies = () => {
  Cookie.remove("token");
};

const addInterceptor = () =>
  axios.interceptors.request.use(
    config => {
      // const token = getTokenFromCookie();
      const token = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjQ1NjI5OWQ3YTI2ODE0NWJkOWJiMjA2Zjg4ODlkYWMwMjg0NjhmZTQiLCJ0eXAiOiJKV1QifQ.eyJpc3MiOiJodHRwczovL3NlY3VyZXRva2VuLmdvb2dsZS5jb20vaGFja2F0b24tZGRmNjUiLCJhdWQiOiJoYWNrYXRvbi1kZGY2NSIsImF1dGhfdGltZSI6MTU1MDk2NzQ1OCwidXNlcl9pZCI6IkY5Y0pOR3Q1WVdlTHl1UGFCQ3dOZmJCRWI2cTIiLCJzdWIiOiJGOWNKTkd0NVlXZUx5dVBhQkN3TmZiQkViNnEyIiwiaWF0IjoxNTUwOTY3NDU4LCJleHAiOjE1NTA5NzEwNTgsImVtYWlsIjoiZ3dnZWd3ZWdwQGdtYWlsLmNvbSIsImVtYWlsX3ZlcmlmaWVkIjpmYWxzZSwiZmlyZWJhc2UiOnsiaWRlbnRpdGllcyI6eyJlbWFpbCI6WyJnd2dlZ3dlZ3BAZ21haWwuY29tIl19LCJzaWduX2luX3Byb3ZpZGVyIjoicGFzc3dvcmQifX0.vUjDB_kEE6sF7ZgRlk3g2u137cOEj4WpbppFFNoUorS3RlYOA-n-UpYnsg_usTyb5FHpAjsgHs6XTAdRseZavkDDfeNs4hNHo8cAXpi9TJTm4aN1jNfitOOKQoxAatA3tqoV9FcvwH3cqA7sedhnK4MVdYB8_wawvDT2dn52sFcCGu3LpzH9vctjr-7M_TWNJij5jjA4_473FmT5kUa6Rd18-7LuxHPBhYhvP86ZEl5furROOYFZJKkW6u1a6PeCa5GeybEXuSNj9-LV23EUMydLC22Kj3taNweQQMHXM8I0gMtvrKURoB_EWBKTYbyZX6s9lfQ2lH5ybhHAKh3zsQ";
      console.log(token)
      
      if (!token) {
        return config;
      }
      const newConfig = {
        headers: {},
        ...config
      };
      console.log(token)
      newConfig.headers.Authorization = `Bearer ${token}`;
      return newConfig;
    },
    e => Promise.reject(e)
  );

export {
  getTokenFromCookie,
  writeTokenFromCookie,
  removeCookies,
  addInterceptor
};
