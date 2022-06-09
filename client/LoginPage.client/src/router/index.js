import { createRouter, createWebHistory } from "vue-router";
import HomeView from "../views/HomeView.vue";
import session from "../helpers/session";
const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: "/",
      name: "home",
      component: HomeView,
    },
    {
      path: "/about",
      name: "about",
      component: () => import("../views/AboutView.vue"),
    },
    {
      path: "/register",
      name: "Register",
      component: () => import("../views/RegisterView.vue"),
    },
    {
      path: "/login",
      name: "Login",
      component: () => import("../views/LoginView.vue"),
    },
    {
      path: "/users",
      name: "Users",
      component: () => import("../views/UsersView.vue"),
    },
  ],
});

router.beforeEach((to, from, next) => {
  if (to.fullPath == "/login") {
    return next();
  }
  if (!session.isAuthenticated()) {
    router.push("/login");
  } else {
    return next();
  }
})

export default router;
