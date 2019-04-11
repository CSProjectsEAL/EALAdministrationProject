<template>
  <v-navigation-drawer
    id="app-drawer"
    v-model="inputValue"
    app
    dark
    floating
    persistent
    mobile-break-point="991"
    width="260"
  >
      <v-layout
        class="fill-height"
        tag="v-list"
        column
      >
        <v-list-tile avatar>
          <v-list-tile-avatar
            color="grey"
          >
            <v-img
              :src="profile_pic"
              height="54"
              contain
            />
          </v-list-tile-avatar>
          <v-list-tile-title class="title">
            Henrik
          </v-list-tile-title>
        </v-list-tile>
        <v-divider/>
        <v-list-tile
          v-if="responsive"
        >
          <v-text-field
            class="purple-input search-input"
            label="Search..."
            color="purple"
          />
        </v-list-tile>
        <v-list-tile
          v-for="(link, i) in links"
          :key="i"
          :to="link.to"
          :active-class="color"
          avatar
          class="v-list-item"
        >
          <v-list-tile-action>
            <v-icon>{{ link.icon }}</v-icon>
          </v-list-tile-action>
          <v-list-tile-title
            v-text="link.text"
          />
        </v-list-tile>
        </v-list-tile>
      </v-layout>
   
  </v-navigation-drawer>
</template>
<script>
// Utilities
import {
  mapMutations,
  mapState
} from 'vuex'

export default {
  data: () => ({
    logo: './img/logo-horisontal.png',
    links: [
      {
        to: '/Home',
        icon: 'mdi-home',
        text: 'Home'
      },
      {
        to: '/applicants',
        icon: 'mdi-account-group',
        text: 'Applicants'
      },
      {
        to: '/notifications',
        icon: 'mdi-bell',
        text: 'Notifications'
      },
      {
        to: '/calendar',
        icon: 'mdi-calendar',
        text: 'Calendar'
      },
      {
        to: '/availability',
        icon: 'mdi-update',
        text: 'Availability'
      },
      {
        to: '/settings',
        icon: 'mdi-settings',
        text: 'Settings'
      },
    ],
    responsive: false
  }),
  computed: {
    ...mapState('app', ['image', 'color']),
    inputValue: {
      get () {
        return this.$store.state.app.drawer
      },
      set (val) {
        this.setDrawer(val)
      }
    },
    items () {
      return this.$t('Layout.View.items')
    }
  },
  mounted () {
    this.onResponsiveInverted()
    window.addEventListener('resize', this.onResponsiveInverted)
  },
  beforeDestroy () {
    window.removeEventListener('resize', this.onResponsiveInverted)
  },
  methods: {
    ...mapMutations('app', ['setDrawer', 'toggleDrawer']),
    onResponsiveInverted () {
      if (window.innerWidth < 991) {
        this.responsive = true
      } else {
        this.responsive = false
      }
    }
  }
}
</script>

<style lang="scss">
  #app-drawer {
    background: linear-gradient(180deg, #ff1633, #ffe87a);
    .v-list__tile {
      border-radius: 7px;

      &--buy {
        margin-top: auto;
        margin-bottom: 17px;
      }
    }

    .search-input {
      margin-bottom: 30px !important;
      padding-left: 15px;
      padding-right: 15px;
    }
  }
</style>
