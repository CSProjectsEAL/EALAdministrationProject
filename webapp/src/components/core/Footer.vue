<template>
  <v-footer
    id="core-footer"
    absolute
    height="82"
  >
    <div class="footer-items">
      <span
        v-for="link in links"
        :key="link.name"
      >
        <a
          :href="link.Link"
          class="tertiary--text footer-links">{{ link.name }}</a>
      </span>
    </div>
    <v-spacer/>
    <span class="font-weight-light copyright">
      &copy;
      {{ (new Date()).getFullYear() }}
      <a
        href="https://github.com/CSProjectsEAL/EALAdministrationsProject"
        target="_blank">made by students at UCL.</a>
      <v-icon
        color="tertiary"
        size="17">mdi-book</v-icon>
    </span>
  </v-footer>
</template>

<script>
export default {
  data: () => ({
    links: [
      { name: 'Home', Link: '/home' },
      { name: 'Documentation', Link: 'https://github.com/CSProjectsEAL/EALAdministrationsProject' }
    ]
  })
}
</script>

<style>
#core-footer {
  z-index: 0;
}
</style>
