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
      const token = getTokenFromCookie();
      if (!token) {
        return config;
      }
      const newConfig = {
        headers: {},
        ...config
      };
      console.log(token);
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
