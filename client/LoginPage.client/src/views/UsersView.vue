<template>
  <div>
    <table class="table table-striped table-sm table-light">
      <thead>
        <tr>
          <th>Username</th>
          <th>Email</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="user in users" :key="user.id">
          <td>{{ user.displayName }}</td>
          <td>{{ user.mail }}</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>
<script>
export default {
  data() {
    return {
      users: [],
    };
  },
  mounted() {
    this.$ajax
      .get("api/user/list")
      .then((response) => {
        if (response.data) {
          this.users = response.data;
        }
      })
      .catch((error) => {
        this.$router.push("/login");
      });
  },
};
</script>
<style>
</style>