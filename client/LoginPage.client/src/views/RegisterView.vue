<template>
  <div class="mt-5 row justify-content-center">
    <div class="col-5">
      <div v-if="isFailed" class="alert alert-warning">Kayıt işlemi Başarısız</div>
      <div v-if="isSuccess" class="alert alert-success">Kayıt işlemi Başarılı</div>
      <div class="tab-content">
        <div class="tab-pane fade show active" v-if="step == 1">
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
          <div class="form-outline mb-4">
            <label class="form-label" for="loginPassword">Password Again</label>
            <input
              type="password"
              id="loginPassword"
              class="form-control"
              v-model="passwordAgain"
            />
            <span
              v-if="passwordAlert == true"
              class="text-muted"
              style="color: red !important; font-size: smaller"
              >parola eşleşmedi</span
            >
          </div>
          <div class="form-outline mb-4">
            <label class="form-label" for="phone">Phone</label>
            <input
              type="text"
              id="phone"
              class="form-control"
              v-model="phone"
            />
          </div>
          <div class="form-outline mb-4">
            <label class="form-label" for="phone">DisplayName</label>
            <input
              type="text"
              id="displayName"
              class="form-control"
              v-model="displayName"
            />
          </div>
          <button
            class="btn btn-primary btn-block mb-4 w-100"
            @click="register"
          >
            Register
          </button>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
export default {
  name: "Register",
  data() {
    return {
      mail: null,
      password: null,
      passwordAgain: null,
      passwordMatched: false,
      passwordAlert: false,
      isSuccess: false,
      isFailed: false,
      step: 1,
      phone: null,
      displayName: null,
    };
  },
  methods: {
    register() {
      this.passwordAlert = false;
      this.isSuccess = false;
      this.isFailed = false;
      if (!this.passwordMatched) {
        this.passwordAlert = true;
        return;
      }
      let data = {
        Mail: this.mail,
        Password: this.password,
        DisplayName: this.displayName,
        Phone: this.phone,
      };
      this.$ajax
        .post("api/user/add", data)
        .then((response) => {
          if (response) {
            this.isSuccess = true;
          }
        })
        .catch((response) => {
          if (response) {
            this.isFailed = true;
          }
        });
    },
  },
  watch: {
    passwordAgain: function (newValue) {
      this.passwordMatched = newValue == this.password;
    },
  },
};
</script>
<style></style>
