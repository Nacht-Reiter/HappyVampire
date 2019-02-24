import axios from "axios";
import Cookie from "js-cookie";
import mutations from "./store/mutations";
import store from "./store/store";
const getTokenFromCookie = () => {
  return Cookie.get("token");
};
const writeTokenFromCookie = token => {
  Cookie.set("token", token);
};
const removeCookies = () => {
  Cookie.remove("token");
};

const loginWithStart = () => {
  const flag = Cookie.get("userStatus");
  if (flag) {
    mutations.SET_ACCOUNT_TYPE(store.state, flag);
    mutations.SET_AUTHENTICATED(store.state, true);
  }
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
      newConfig.headers.Authorization = `Bearer ${token}`;
      return newConfig;
    },
    e => Promise.reject(e)
  );

export {
  getTokenFromCookie,
  writeTokenFromCookie,
  removeCookies,
  addInterceptor,
  loginWithStart
};
