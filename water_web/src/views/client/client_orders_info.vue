<template>
  <div>
    <loader v-if="loading"/>
    
    <div class="m-5 ">
      
      <div class="d-flex justify-content-center">
              <h5>{{$t('last_order')}}</h5>
            </div>
            <div class="table">
              <table class="w-100 tabled">
                <thead class="header_table">
                  <tr>
                    <th>№</th>
                    <th>{{$t('fio')}}</th>
                    <th class="text-center">{{$t('water_count')}}</th>
                    <th>{{$t('address')}}</th>
                    <th>{{$t('created_date_time')}}</th>
                    <th>{{$t('accepted_date')}}</th>
                    <th>{{$t('car_order')}}</th>
                    <!-- <th width="60">{{$t('Action')}}</th> -->
                  </tr>
                </thead>
                <tbody class="body_table">
                  <tr v-for="(item, index) in client_last_order" :key="index">
                    <td>{{index+1}}</td>
                    <td class="font-weight-bold" style="font-size: 12px;">{{item.client_name_str}}</td>
                    <td class="text-center text-primary font-weight-bold" style="font-size: 12px;">{{item.water_count}} / {{item.reserverd_numeric_id_1}}</td>
                    <td>{{item.address.address}}</td>
                    <td>{{item.created_date_time.substr(0,10)}} ( {{item.created_date_time_str.substr(0,5)}} )</td>
                    <td>{{item.accepted_status}}</td>
                     <td>{{item.deleivered_user_auth_id}}</td>
                    <!-- <td class="m-0 p-0">
                      <mdb-btn class="mr-1 ml-0 mt-0 mt-1 btn-acp"  style="font-size: 8px; width:80px; padding: 5px;"  @click="showOrder(item)" 
                        size="sm">{{$t('accept')}}
                      </mdb-btn>
                    </td> -->
                  </tr>
                </tbody>
              </table>
            </div>
    </div>
    
  </div>
</template>
  
<script>

// import {  mdbRow, mdbCol } from "mdbvue"
// import md5 from 'js-md5'
// import { mdbInput, mdbRow, mdbCol, mdbIcon, mdbBtn,  } from "mdbvue"

// import {mapActions,mapGetters} from 'vuex'



export default {
  
  
  data(){
    return{
      client_last_order: [],
      id: 0,
      hostname: this.$store.state.server_ip,
    }
  },
  props :
    {
      
      client_id : {
        type : Number,
        default : 0
      }
      
    },
  components: {
   
  },
   
    
    async created()
    {
      
    },
    async mounted(){
      
    },
    // computed: mapGetters([]),

  methods:{
    async updateMounted(client_id){
      if(client_id > 0){
        this.id = client_id
        await this.fetchClientLastOrder();
      }
    },
       async fetchClientLastOrder(){
          
            // this.loadingSimple = true;
            const response = await fetch(this.$store.state.hostname + "/WaterOrders/getPaginationOrderByClientId?page=0&size=1000&client_id=" + this.id);
            const data = await response.json();
            console.log('client_orders_info')
            console.log(data)
              // let old_date_temp = new Date(data[0].order_date);
              // this.last_order_date =  old_date_temp.toDateString();
              this.client_last_order = data.items_list;  
            
          
        },
    },
}
</script>
