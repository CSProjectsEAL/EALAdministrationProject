/**
 * Define all of your application routes here
 * for more information on routes, see the
 * official documentation https://router.vuejs.org/en/
 */
export default [
  {
    path: '/home',
    // Relative to /src/views
    name: 'Home',
    view: 'Home'
  },
  {
    path: '/settings',
    name: 'Settings',
    view: 'Settings'
  },
  {
    path: '/applicants',
    name: 'Applicants',
    view: 'Applicants'
  },
  {
    path: '/calendar',
    name: 'Calendar',
    view: 'Calendar'
  },
  {
    path: '/availability',
    name: 'Availability',
    view: 'Availability'
  },
  {
    path: '/notifications',
    name: 'Notifications',
    view: 'Notifications'
  }
]
