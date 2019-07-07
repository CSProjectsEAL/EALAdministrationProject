<template>
 <v-container fluid fill-height grid-list-md text-xs-center>
  <v-layout column wrap>
    <v-calendar />
  </v-layout>
  <v-layout columnn wrap>
            <v-container grid-list-lg>
              <v-layout
                justify-center
                row
                wrap>
                <v-flex
                  xs12
                  sm4>
                  <v-btn
                    block
                    color="success"
                    @click="snack('top', 'left')"
                  >
                    8-10
                  </v-btn>
                </v-flex>
                <v-flex
                  xs12
                  sm4>
                  <v-btn
                    block
                    color="success"
                    @click="snack('top')"
                  >
                    10-12
                  </v-btn>
                </v-flex>
              </v-layout>
              <v-layout
                justify-center
                row
                wrap>
                <v-flex
                  xs12
                  sm4>
                  <v-btn
                    block
                    color="success"
                    @click="snack('top', 'right')"
                  >
                    12-14
                  </v-btn>
                </v-flex>
                <v-flex
                  xs12
                  sm4>
                  <v-btn
                    block
                    color="success"
                    @click="snack('bottom', 'left')"
                  >
                    14-16
                  </v-btn>
                </v-flex>
              </v-layout>
              <v-layout
                justify-center
                row
                wrap>
                <v-flex
                  xs12
                  sm4>
                  <v-btn
                    block
                    color="success"
                    @click=""
                  >
                    16-18
                  </v-btn>
                </v-flex>
                <v-flex
                  xs12
                  sm4>
                  <v-btn
                    block
                    color="dColor"
                    v-bind:style="{ styleObject }"
                    @click="changeColor()"
                  > 
                    18-20
                  </v-btn>
                </v-flex>
              </v-layout>
            </v-container>
  </v-layout>
</v-container>
</template>
<script>
export default {
    data: () => ({
    dColor: 'success',
    methods: {
      changeColor : function(){
      }
    }
  })
}
</script>