<template>
  <div class="mt-5 row justify-content-center">
    <div class="col-4">
      <ul class="nav nav-pills nav-justified mb-3" id="ex1" role="tablist"></ul>

      <div class="tab-content">
        <div class="tab-pane fade show active" v-if="step == 1">
          <div class="form-outline mb-4">
            <label class="form-label" for="loginName">Email</label>
            <input
              type="email"
              id="loginName"
              class="form-control"
              v-model="mail"
              style="width: fit-content"
            />
          </div>

          <div class="form-outline mb-4">
            <label class="form-label" for="loginPassword">Password</label>
            <input
              type="password"
              id="loginPassword"
              class="form-control"
              v-model="password"
              style="width: fit-content"
            />
          </div>
          <div class="form-outline mb-4">
            <label class="form-label" for="phone">Phone</label>
            <input
              type="text"
              id="phone"
              class="form-control"
              v-model="phone"
              style="width: fit-content"
            />
          </div>
          <div class="form-outline mb-4">
            <label class="form-label" for="phone">DisplayName</label>
            <input
              type="text"
              id="displayName"
              class="form-control"
              v-model="displayName"
              style="width: fit-content"
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
      step: 1,
      phone: null,
      displayName: null,
    };
  },
  methods: {
    register() {
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
            console.log("Başarılı");
          }
        })
        .catch((response) => {
          if (response) {
            console.log("Başarısız!");
          }
        });
    },
  },
};
</script>
<style></style>
