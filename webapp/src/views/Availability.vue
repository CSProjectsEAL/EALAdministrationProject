<template>
 <v-container fluid fill-height grid-list-md text-xs-center>
  <v-layout column wrap>
    <v-calendar />
  </v-layout>
  <v-layout columnn wrap>

     <v-container grid-list-md text-xs-center>
        <v-layout row wrap>
          <v-flex v-for="i in " :key="`6${i}`" xs6>
            <v-btn color="success">10</v-btn>
          </v-flex>
        </v-layout>
      </v-container>
  </v-layout>
</v-container>
</template>

<script>
export default {
  data () {
    return {

    }
  },
  methods: {
  }
}
</script>