<template>
  <div class="mt-5 row justify-content-center">
    <div class="col-5">
      <div v-if="isFailed" class="alert alert-warning">
        Giriş işlemi Başarısız
      </div>
      <div v-if="isSuccess" class="alert alert-success">
        Giriş işlemi Başarılı
      </div>
      <div class="tab-content">
        <div class="tab-pane fade show active">
          <div class="form-outline mb-4">
            <label class="form-label" for="loginName">Email</label>
            <input
              type="email"
              id="loginName"
              class="form-control"
              v-model="mail"
            />
          </div>
          <div class="form-outline mb-4">
            <label class="form-label" for="loginPassword">Password</label>
            <input
              type="password"
              id="loginPassword"
              class="form-control"
              v-model="password"
            />
          </div>
          <button class="btn btn-primary btn-block mb-4 w-100" @click="login">
            Login
          </button>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import session from "../helpers/session.js";
export default {
  name: "Login",
  data() {
    return {
      isFailed: false,
      isSuccess: false,
      password: null,
      mail: null,
    };
  },
  methods: {
    login() {
      this.isFailed = false;
      this.isSuccess = false;
      let data = {
        Mail: this.mail,
        Password: this.password,
      };
      this.$ajax
        .post("api/user/login", data)
        .then((response) => {
          if (response.data) {
            this.isSuccess = true;
            session.setSession(response.data);
            this.$router.push("/users");
          }
        })
        .catch((error) => {
          this.isFailed = true;
        });
    },
  },
};
</script>
<style scoped>
</style>