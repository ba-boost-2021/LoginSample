<template>
  <div>

    <Login v-if="$route.path === '/login'" />
    <Register v-else-if="$route.path === '/register'" />
    <App v-else />
  </div>
</template>
<script>
export default {
  name: "AppWrapper",
};
</script>
