import { createApp } from "vue";
import App from "./App.vue";
import AppWrapper from "./AppWrapper.vue";
import Login from "./views/LoginView.vue";
import Register from "./views/RegisterView.vue";
import router from "./router";
import ajax from "./helpers/ajax.js";

const app = createApp(AppWrapper);
app.component("App", App);
app.component("Login", Login);
app.component("Register", Register);
app.use(router);
app.use(ajax);
app.mount("#app");
