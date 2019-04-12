<template>
  <v-container
    fill-height
    fluid
    grid-list-xl
  >
    <v-layout
      justify-center
      wrap
    >
      <v-flex
        md12
      >
        <material-card
          color="#531B21"
          title="Assigned applicants"
        >
        <v-flex md12>
            <v-text-field
              v-model="search"
              append-icon="mdi-magnify"
              label="Search"
              single-line
              hide-details
            ></v-text-field>
        </v-flex>
          <v-data-table
            :headers="headers"
            :items="items"
            :pagination.sync="pagSettings"
            :search="search"
          >
            <template
              slot="headerCell"
              slot-scope="{ header }"
            >
              <span
                class="subheading font-weight-light text-success text--darken-3"
                v-text="header.text"
              />
            </template>
            <template
              slot="items"
              slot-scope="{ item }"
            >
              <td>{{ item.name }}</td>
              <td>{{ item.country }}</td>
              <td>{{ new Date(item.appliedDate * 1000) | moment("MM/D/YY") }}</td>
              <td>{{ new Date(item.interviewDate * 1000) | moment("dd MM/D/YY") }}</td>
              <td align="center"><v-icon
        color="primary"
        size="22">mdi-arrow-down-bold-circle</v-icon><v-icon
        color="blue"
        size="22">mdi-arrow-up-bold-circle</v-icon></td>
              <td>{{ item.attempts }}</td>
            </template>
          </v-data-table>
        </material-card>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script>
export default {
  data: () => ({
    pagSettings:[
      {
         descending: false,
          page: 2,
          rowsPerPage: 1,
          sortBy: status,
      },
    ],
    search: '',
    headers: [
      {
        sortable: true,
        text: 'Name',
        value: 'name'
      },
      {
        sortable: true,
        text: 'Country',
        value: 'country'
      },
      {
        sortable: true,
        text: 'Applied',
        value: 'appliedDate',
      },
       {
        sortable: false,
        text: 'Interview Date',
        value: 'interviewDate'
      },
       {
        sortable: false,
        text: 'Interview Notes',
        align: 'center',
        value: 'interviewNotes',
      },
       {
        sortable: true,
        text: 'Attempts',
        value: 'attempts'
      },
    ],
    items: [
      {
        name: 'Dakota Rice',
        country: 'Niger',
        appliedDate: '1555016764',
        interviewDate: '1555016764',
        interviewNotes: 'down',
        attempts: 1
      },
      {
        name: 'Dakota Rice',
        country: 'Niger',
        appliedDate: '1555016764',
        interviewDate: '1555016764',
        interviewNotes: 'down',
        attempts: 2
      }, 
      {
        name: 'Sage Rodriguez',
        country: 'Netherlands',
        appliedDate: '1555017095',
        interviewDate: '1555016764',
        interviewNotes: 'down',
        attempts: 3
      }, 
      {
        name: 'Philip Chanley',
        country: 'Korea, South',
        appliedDate: '1555016764',
        interviewDate: '1555016764',
        interviewNotes: 'down',
        attempts: 1
      }, 
      {
        name: 'Doris Greene',
        country: 'Malawi',
        appliedDate: '1555016764',
        interviewDate: '1555016764',
        interviewNotes: 'down',
        attempts: 2
      }, 
      {
        name: 'Mason Porter',
        country: 'Chile',
        appliedDate: '1555016764',
        interviewDate: '1555016764',
        interviewNotes: 'down',
        attempts: 1
      }
    ],
    methods: {
      convertTimestamp : function(){

      }
    }
  })
}
</script>