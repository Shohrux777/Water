<template>
  <div class="all_info_order d-flex">
    <div class="pos_order_list">
        <div class="border-bottom navbar_sticky">
           <div class="d-flex justify-content-between">
              <router-link to="#">
                <h5 class="m-0 ml-3 d-flex" style="padding: 14px 0px">
                    {{$t('statistic')}}</h5>
              </router-link>
              <div class="summa d-flex align-items-center">
                  <div class="mr-5 text-center">
                    <p style="font-size:12.5px;" class="p-0 m-0 text-success">{{$t('summ')}}</p>
                    <p style="font-size:12px;" class="p-0 m-0 text-success font-weight-bold">{{all_money.toString().replace(/(\d)(?=(\d{3})+(\.(\d){0,2})*$)/g, '$1 ')}}</p>
                  </div>
                  <div class="mr-5 text-center">
                    <p style="font-size:12.5px;" class="p-0 m-0 text-primary">{{$t('client')}}</p>
                    <p style="font-size:12px;" class="p-0 m-0 text-primary font-weight-bold">{{real_clients.toString().replace(/(\d)(?=(\d{3})+(\.(\d){0,2})*$)/g, '$1 ')}}</p>
                  </div>
                  <!-- <div class="mr-5 text-center">
                    <p style="font-size:14px;" class="p-0 m-0">{{$t('skidka')}}</p>
                    <p style="font-size:14px;" class="p-0 m-0">{{all_summ.online.toString().replace(/(\d)(?=(\d{3})+(\.(\d){0,2})*$)/g, '$1 ')}}</p>
                  </div>
                  <div class="mr-5 text-center">
                    <p style="font-size:14px;" class="p-0 m-0">{{$t('rasxod')}}</p>
                    <p style="font-size:14px;" class="p-0 m-0">{{all_summ.rasxod.toString().replace(/(\d)(?=(\d{3})+(\.(\d){0,2})*$)/g, '$1 ')}}</p>
                  </div> -->
                  <!-- <div class="mr-5 text-center">
                    <p style="font-size:12.5px;" class="p-0 m-0 text-indigo">{{$t('summ')}}</p>
                    <p style="font-size:12px;" class="p-0 m-0 text-indigo font-weight-bold">{{all_summ.summ.toString().replace(/(\d)(?=(\d{3})+(\.(\d){0,2})*$)/g, '$1 ')}}</p>
                  </div> -->
              </div>
           </div>
      </div>
      <div class="header_menu px-3 mt-3">
        <div class="row">
          <div class="col-4 mt-1">
            <div class="d-flex">
              <erpSelect
                size="sm"
                :options="allDepartment.rows"
                @select="selectOption"
                :selected="district_name"
                :label="$t('province')"
              />
              <small v-if="$v.district_name.$dirty && district_id == null" class="invalid-text ml-2" style="margin-top: 35px;">
                {{$t('select_item')}}
              </small>
            </div>
          </div>
          <div class="col-4 mt-1">
            <div class="d-flex">
              <input-search  @select="selectClient"  
                url="/WaterClients/getPaginationByName?page=0&size=100&fio="
                ref="search_client" :option="allClient.rows" icon="user" style="height:32px;">
                </input-search>
                <small class="p-0" style="margin-left:5px; font-size: 12px; top:-17px; color: gray; position:absolute;"  >
                {{$t('search_client')}}
                </small>
            </div>
          </div>
          <!-- <div class="col-2 px-1">
            <mdb-input class="m-0 p-0 " size="sm" v-model="b_date" type="date"></mdb-input>
          </div>
          <div class="col-2 px-1">
            <mdb-input class="m-0 p-0 " size="sm" v-model="e_date" type="date"></mdb-input>
          </div> -->
          <div class="col-2 d-flex">
            <mdb-btn class="mr-1 ml-0 mt-0  py-1 px-3 mt-1"  style="font-size: 9px; height:28px; width:80px" color="info"  @click="acceptBtn()" 
              size="sm">{{$t('apply')}}
            </mdb-btn>

            <mdb-btn class="mr-1 ml-0 mt-0  py-1 px-3 mt-1"  style="font-size: 9px; height:28px; width:100px" color="primary"  @click="update()" 
              size="sm">{{$t('update')}}
            </mdb-btn>
          </div>
        </div>
      </div>
      <div class="table w-100">
        <loader-table v-if="loading"/>
        <table v-else class="w-100 tabled">
          <thead class="header_table">
            <tr class="header py-3 stiky_position" >
              <th  width="40" class="text-left">№</th>
              <th  width="120">{{$t('client_name')}}
                <span style="position:relative;">
                  <span @click="sortedArrayAsc2('fio')"><mdb-icon icon="angle-up"  class="px-1 up_down_icon"  style="position:absolute; top:-2px; cursor:pointer;"/></span>
                  <span @click="sortedArray2('fio')"><mdb-icon icon="angle-down"  class="px-1 up_down_icon" style="position:absolute; bottom:-4px; cursor:pointer;"/></span>
                </span>
              </th>
              <th  width="150">{{$t('district')}}
                <span style="position:relative;">
                  <span @click="sortedArrayAsc('tuman_name')"><mdb-icon icon="angle-up"  class="px-1 up_down_icon"  style="position:absolute; top:-2px; cursor:pointer;"/></span>
                  <span @click="sortedArray('tuman_name')"><mdb-icon icon="angle-down"  class="px-1 up_down_icon" style="position:absolute; bottom:-4px; cursor:pointer;"/></span>
                </span>
              </th>
                <th  width="150">{{$t('first_order')}}
                <span style="position:relative;">
                  <span @click="sortedArrayAsc('first_order_date')"><mdb-icon icon="angle-up"  class="px-1 up_down_icon"  style="position:absolute; top:-2px; cursor:pointer;"/></span>
                  <span @click="sortedArray('first_order_date')"><mdb-icon icon="angle-down"  class="px-1 up_down_icon" style="position:absolute; bottom:-4px; cursor:pointer;"/></span>
                </span>
              </th>
                <th  width="150">{{$t('order_count')}}
                <span style="position:relative;">
                  <span @click="sortedArrayAsc('zakazlar_soni')"><mdb-icon icon="angle-up"  class="px-1 up_down_icon"  style="position:absolute; top:-2px; cursor:pointer;"/></span>
                  <span @click="sortedArray('zakazlar_soni')"><mdb-icon icon="angle-down"  class="px-1 up_down_icon" style="position:absolute; bottom:-4px; cursor:pointer;"/></span>
                </span>
              </th>
              <th >{{$t('address')}}
                
              </th>
              <th  width="125">{{$t('ostatka')}}
                <span style="position:relative;">
                  <span @click="sortedArrayAsc('bakalashka_soni1')"><mdb-icon icon="angle-up"  class="px-1 up_down_icon"  style="position:absolute; top:-2px; cursor:pointer;"/></span>
                  <span @click="sortedArray('bakalashka_soni1')"><mdb-icon icon="angle-down"  class="px-1 up_down_icon" style="position:absolute; bottom:-4px; cursor:pointer;"/></span>
                </span>
              </th>
              <th  width="125">{{$t('getten')}}
                <span style="position:relative;">
                  <span @click="sortedArrayAsc('olgan_suv_soni')"><mdb-icon icon="angle-up"  class="px-1 up_down_icon"  style="position:absolute; top:-2px; cursor:pointer;"/></span>
                  <span @click="sortedArray('olgan_suv_soni')"><mdb-icon icon="angle-down"  class="px-1 up_down_icon" style="position:absolute; bottom:-4px; cursor:pointer;"/></span>
                </span>
              </th>
              <th width="120">{{$t('date')}}
                <span style="position:relative;">
                  <span @click="sortedArrayAsc3('last_order_date')"><mdb-icon icon="angle-up"  class="px-1 up_down_icon"  style="position:absolute; top:-2px; cursor:pointer;"/></span>
                  <span @click="sortedArray3('last_order_date')"><mdb-icon icon="angle-down"  class="px-1 up_down_icon" style="position:absolute; bottom:-4px; cursor:pointer;"/></span>
                </span>
              </th>
            </tr>
          </thead>
          <tbody class="body_table">
            <tr v-for="(row, rowIndex) in order_list" :key="rowIndex" class="hoverTr">
              <td> <span >{{rowIndex+1}}</span> </td>
              <td> <span >{{row.fio}}</span> </td>
              <td> <span >{{row.tuman_name}}</span> </td>
              <td> <span >{{row.first_order_date}}</span> </td>
              <td> <span >{{row.zakazlar_soni}}</span> </td>
              <td> <span >{{row.address}}</span> </td>
              <td> <span >{{row.bakalashka_soni1}}</span> </td>
              <td> <span >{{row.olgan_suv_soni}}</span>  </td>
              <td> <span >{{row.last_order_date}}</span> </td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
    <Toast ref="message"></Toast>
  </div>
</template>

<script>
import {mdbBtn, mdbInput, mdbIcon} from 'mdbvue'
import loaderTable from '../../components/loaderTable.vue';
import erpSelect from "../../components/erpSelect.vue";
import { required } from 'vuelidate/lib/validators';
import inputSearch from '../../components/inputSearch.vue'
import { mapActions, mapGetters } from 'vuex';


export default {
  components: { loaderTable, mdbBtn, mdbInput, mdbIcon, erpSelect, inputSearch },
  data() {
    return {
      id: 0,
      loading:false,
      pay_show: false,

      order_list:  [],
      order_id: null,
      b_date: '',
      e_date: '',
      today_date: '',
      all_water_count: 0,

      search: '',
      pos_money_report_list: [],

      district_name: '',
      district_id: 0,

      all_money : 0,
      real_clients :0,

      client_id: 0,
      client_name: ''
    }
  },
  validations: {
    district_name: {required},
  },
  computed: {
    ...mapGetters([ 'allUser', 'get_postavchik_order_list', 'postavchik_all_qty','allDepartment', 'allClient']),
  },
  async mounted() {
    await this.fetchDepartment();
    await this.fetchClient();
    await this.acceptBtn();
    await this.get_money();
  },
  methods: {
  ...mapActions(['fetchUser', 'fetchPostavchikOrder', 'fetchDepartment', 'fetchClient']),
    async selectOption(option){
      console.log(option)
      this.district_name = option.name;
      this.district_id = option.id;
      // await this.fetchPostavchikList(this.auth_id);
    },
    async selectClient(option){
      console.log(option)
      this.client_name = option.fio;
      this.client_id = option.id;
        await this.acceptBtn();
        //this.$refs.message.focus();
         
    },
    async update(){
      this.district_name ='';
      this.district_id = 0;
      this.client_id = 0;
      this.client_name = ''
        await this.acceptBtn();
    },
    async get_money()
    {
      try{
        this.loading = true;
        const res = await fetch(this.$store.state.hostname + '/WaterClients/getInfoAboutMoney');
        const data = await res.json();
        this.loading = false;
        if(res.status == 200 || res.status == 201){
          console.log('data.full_money')
          console.log(data)
           this.all_money = data[0].full_money;
           this.real_clients = data[0].real_client;
        }
        else{
          this.$refs.message.error('network_ne_connect')
        }
      }
      catch{
        this.$refs.message.error('network_ne_connect')
      }
    },
    async acceptBtn(){
        try{
        this.loading = true;
        const res = await fetch(this.$store.state.hostname + '/WaterClients/getPaginationStatistikReportQuery2?page=0&size=10000&tuman_id='+ this.district_id + '&client_id=' + this.client_id);
        const data = await res.json();
        this.loading = false;
        if(res.status == 200 || res.status == 201){
          console.log('data.items_list')
          console.log(data)
            this.order_list = data.items_list;
        }
        else{
          this.$refs.message.error('network_ne_connect')
        }
      }
      catch{
        this.$refs.message.error('network_ne_connect')
      }

    },

   sortedArrayAsc2(key){
        function compare(a, b) { 
          if ( parseInt(a[key].substring(1), 10) < parseInt(b[key].substring(1), 10))
            return -1;
          else
            return 1;
         
        }
        this.order_list.sort(compare);
    },
    sortedArray2(key){
        function compare(a, b) {
          if ( parseInt(a[key].substring(1), 10) > parseInt(b[key].substring(1), 10))
            return -1;
          else
            return 1;
         
        }

        this.order_list.sort(compare);
    },
     sortedArrayAsc3(key){
        function compare(a, b) { 
           if (a[key] != null && b[key] != null )
            return new Date(b[key].split('_')[0]) - new Date(a[key].split('_')[0]);
          else
            return 1;
         
        }
        this.order_list.sort(compare);
    },
    sortedArray3(key){
        function compare(a, b) {
          // var fields_a = a[key].split('_')[0];
          if (a[key] != null && b[key] != null )
            return new Date(a[key].split('_')[0]) - new Date(b[key].split('_')[0]);
          else
            return 1;
         
        }

        this.order_list.sort(compare);
    },
     // ===> sort table <===
    sortedArrayAsc(key){
        function compare(a, b) {
          if (a[key] < b[key])
            return -1;
          if (a[key] > b[key])
            return 1;
          return 0;
        }
        this.order_list.sort(compare);
    },
    sortedArray(key){
        function compare(a, b) {
          if (a[key] > b[key])
            return -1;
          if (a[key] < b[key])
            return 1;
          return 0;
        }

        this.order_list.sort(compare);
    }
    // ===> sort table <===

  },
}
</script>

<style lang="scss">

@import url(https://fonts.googleapis.com/css?family=Open+Sans:400,700);

$blue:rgb(79, 173, 210);
$green:rgb(102, 229, 174);
$yellow:rgba(231,196,104,0.7);
$orange:rgba(235,118,85,1);
$dark-bg:rgba(0,0,0,0.9);
$light-bg:rgba(255,255,255,0.1);
$text:rgba(255,255,255,0.9);
body {
  background:$light-bg;
  font-family: 'Open Sans', sans-serif;
}
.pos_order_list{
  width:100%;
  border-right: 1px solid $dark-bg;
}
.header_table{
  background: $green;
  th{
    padding:6px 7px;
    font-weight: 600;
    font-size: 11.5px;
    @media only screen and (max-width:767px) and (min-width:480px) {
      font-size:11px;
    }
  }
}
.body_table{
  td{
    padding:6px 7px;
    font-size: 12px;
     @media only screen and (max-width:767px) and (min-width:480px) {
      font-size:11.5px;
    }
  }
  tr:nth-child(even){background-color: #ebf5fc;}
}
.table{
  border-bottom-left-radius: 50% !important;
  border-bottom-right-radius: 50% !important;
  padding: 10px 0px;
  @media only screen and (max-width:767px) and (min-width:480px) {
    font-size:12px;
    padding: 10px 5px;
  }
  @media only screen and (max-width:470px) {
    font-size:12px;
    padding: 5px 0;
  }
}
.tabled{
  border-collapse: separate;
  border-spacing: 0;
  tr:first-child td:first-child { border-top-left-radius: 10px; }
  tr:first-child td:last-child { border-top-right-radius: 10px; }

//   td {
//   border: solid 1px #000;
//   border-style: none solid solid none;
//   padding: 10px;
// }
}
.btn-acp{
  background-image: radial-gradient( circle 835px at 12.1% 24%,  rgba(93,133,178,1) 25.7%, rgba(50,73,101,1) 100.2% );
}
.hoverTr:hover{
  background-image: radial-gradient( circle farthest-corner at 1.3% 2.8%,   rgb(211, 224, 245) 100.2%, rgba(239,249,249,1) 100% );
}
.all_qty_border{
  background-image: radial-gradient( circle farthest-corner at 1.3% 2.8%,   rgb(211, 224, 245) 100.2%, rgba(239,249,249,1) 100% );
}
.up_down_icon:hover{
  background: #acbbff;
}
.stiky_position{
  position: -webkit-sticky; /* Safari */
  position: sticky;
  top: 52px;
  background: #3f6a8b;
  color:white;
}

</style>