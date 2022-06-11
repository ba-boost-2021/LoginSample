import axios from "axios";
import session from "./session.js";
export default {
  install: (app) => {
    const instance = axios.create({
      baseURL: "https://localhost:4000",
    });
    function setUpHeaders() {
      let config = {
        headers: {
        }
      }
      let token = session.checkAndGetToken(instance);
      if (token) {
        config.headers["Authorization"] = "Bearer " + token;
      }
      return config;
    }
    let ajax = {
      get: function (url) {
        return instance.get(url, setUpHeaders());
      },
      post: function (url, data) {
        return instance.post(url, data, setUpHeaders());
      },
    };
    app.config.globalProperties.$ajax = ajax;
  },
};
