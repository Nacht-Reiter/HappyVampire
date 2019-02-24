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
      const token = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjNiYmQyOGVkYzNkMTBiOTI5ZjU3NWEyY2E2ODU0OWZjYTZkODg5OTMiLCJ0eXAiOiJKV1QifQ.eyJpc3MiOiJodHRwczovL3NlY3VyZXRva2VuLmdvb2dsZS5jb20vaGFja2F0b24tZGRmNjUiLCJhdWQiOiJoYWNrYXRvbi1kZGY2NSIsImF1dGhfdGltZSI6MTU1MDk3MDg0NCwidXNlcl9pZCI6IjRta1dFaFBuQUFZbnZ2REhaYjZ6NkV0YlhabzEiLCJzdWIiOiI0bWtXRWhQbkFBWW52dkRIWmI2ejZFdGJYWm8xIiwiaWF0IjoxNTUwOTcwODQ0LCJleHAiOjE1NTA5NzQ0NDQsImVtYWlsIjoiZ29vZ2Vub3Q5OTBAZ21haWwuY29tIiwiZW1haWxfdmVyaWZpZWQiOmZhbHNlLCJmaXJlYmFzZSI6eyJpZGVudGl0aWVzIjp7ImVtYWlsIjpbImdvb2dlbm90OTkwQGdtYWlsLmNvbSJdfSwic2lnbl9pbl9wcm92aWRlciI6InBhc3N3b3JkIn19.OucwynSa-SgW6i_FEIgz5M_rV6RhGKID2LZyGLWCyeHaNeQx-QFR2rzsYWLrEXnzab3OTJCF4K1p8ZHzco4RrM1Q5k7EE_6RNN5LpZpPL5ISSqsf3sPTclQ4-yGcQOKTu_jj_4S5L3AWnDaPtTYt8rHYUJOqUUe2v8YiKe2ZfQqVJD8uMF56o99ygWQrIGv-DhfRdZ5jm9tlXak5TrdnN2xk7BWd6R6T33dNaUHB0HI6GOYimypzq7vGQ2U03F5_O8avNTO_IeainICXf4vetT_LUZ0FqrQdtWcqFbynDQEP9IcwA7Op6nX8jO5DhgkZgUMgwKu1cOR5Ovg4vZuLsQ";
      console.log(token)
      
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
  addInterceptor
};
