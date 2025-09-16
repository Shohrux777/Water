<template>
  <div class="map_order m-0">
    <backRouter />
    <div style="position:fixed; top:0px; left:0; right:0; background: white; z-index:1111111; cursor:pointer;" 
      class="bg-white p-1 px-4 rounded" >
      <!-- <div @click="$router.push('/new_order_list')">
          <mdb-icon icon="list-alt" />
      </div> -->
      <div class="row">
        <div class="col-3 px-1">
          <mdb-input class="m-0 p-0 " size="sm" v-model="b_date" type="date"></mdb-input>
        </div>
        <div class="col-3 px-1">
          <mdb-input class="m-0 p-0 " size="sm" v-model="e_date" type="date"></mdb-input>
        </div>
        <div class="col-6 d-flex">
          <mdb-btn class="mr-1 ml-0 mt-0  py-1 px-3 mt-1"  style="font-size: 9px; height:28px; width:80px" color="info"  @click="acceptBtn()" 
            size="sm">{{$t('apply')}}
          </mdb-btn>
          <div class="d-flex align-items-center">
            <h5 class="m-0 p-0 pb-1 ml-3 br_bm" style="font-size:16px;">{{$t('order')}} : {{all_water_count}}</h5>
            <h5 v-show="user_name != ''" class="m-0 p-0 pb-1 ml-3 br_bm" style="font-size:16px;">{{user_name}} : {{postavchik_water_count}}</h5>
          </div>
        </div>
      </div>  
    </div>

    <div class="bg-white p-1 px-2 rounded " :class="{'carPage': show_car, 'carPageClose': !show_car}"  >
      <div class="row px-2">
        <div class="col-12 py-1">
          <erpSelect
            size="sm"
            :options="allUser.rows" 
            @select="selectOption"
            :selected="user_name"
            :label="$t('province')"
          />
          <small v-if="$v.user_name.$dirty && user_id == null" class="invalid-text mt-0 ml-2" >
            {{$t('select_item')}}
          </small>
        </div>
      </div>
      <div class="order_list_postavchik  mt-3">
        <draggable v-model="postavchik_list" ghost-class="ghost" group="people" @start="drag=true" @end="drag=false">
          <transition-group type="transition" name="flip-list">
            <div class="itemPostavchik bg_fon py-1 px-1 br_bm" v-for="(item,index) in postavchik_list" :key="item.id">
              <div class="d-flex w-100">
                <div style="width:50px;">
                  <p class="m-0 p-0" style="font-size: 16px;">{{index+1}}.</p>
                </div>
                <div style="width:100%;">
                  <p class="m-0 p-0" style="font-size: 15px;" >{{item.client_name_str}}</p>
                </div>
                <div style="width:100px;">
                  <p class="m-0 p-0 ml-2 ">{{item.water_count}}</p>
                </div>
                <div style="width:40px;">
                  <i class="fas fa-angle-double-left delIcon mask waves-effect rounded m-0 pl-2" style="font-size: 12.5px;"  v-on:click="deleteRow(item)" ></i>
                </div>
              </div>
            </div>
          </transition-group>
        </draggable>
      </div>
      <!-- <div class="order_list_postavchik mt-3">
        <div class="itemPostavchik bg_fon py-1 px-1 br_bm" v-for="(item,index) in postavchik_list" :key="index">
          <div class="d-flex w-100">
            <div style="width:50px;">
              <p class="m-0 p-0" style="font-size: 16px;">{{index+1}}.</p>
            </div>
            <div style="width:100%;">
              <p class="m-0 p-0" style="font-size: 15px;" >{{item.client_name_str}}</p>
            </div>
            <div style="width:100px;">
              <p class="m-0 p-0 ml-2 ">{{item.water_count}}</p>
            </div>
            <div style="width:40px;">
              <i class="fas fa-angle-double-left delIcon mask waves-effect rounded m-0 pl-2" style="font-size: 12.5px;"  v-on:click="deleteRow(item)" ></i>
            </div>
          </div>
        </div>
      </div> -->
    </div>
    <div class="d-flex justify-content-center align-items-center  shadow" :class="{'InfoIcoFixedOpen': show_car, 'InfoIcoFixed': !show_car}"  @click="show_car = !show_car">
      <mdb-icon icon="angle-double-left" fas class="text-white ml-1" style="font-size: 22px;" />
    </div>

    <div id="map">
      <loaderTable class="mt-5" v-if="loading"/>
      <yandex-map v-if="map_show"
        :coords="[41.311516, 69.283250]"
        zoom="13"
        style="width: 100%; height: 100vh;"
      >
          <!-- :balloon="{header: 'Z-'+mark.address.id, body: mark.address.address, footer: mark.client_name_str + '. ' + ' Телефон: ' + mark.phone_number_list_arr }" -->
      <div v-for="(mark,i) in order_list" :key="i" >
          <!-- @balloonopen="bindListener"
          @balloonclose="unbindListener" -->
        <ymap-marker  
          :markerId="mark.id"
          marker-type="placemark"
          :coords="[mark.address.latidu, mark.address.longitu]"
          :hint-content="mark.client.fio"
          :icon="{
            imageSize: [43, 55],
            imageOffset: [-22, -55],
            content: mark.client.fio,
            color: mark.color_value,
            contentOffset: [-22, -55],
          }"
          :cluster-name="mark.id"
          @click="sendFunc(mark)"
      >
        <!-- <my-component slot="balloon" :mark="mark"></my-component> -->
      </ymap-marker>
      </div>
    <ymap-marker
      markerId="3"
      marker-type="circle"
      :coords="[41.234687, 69.263790]"
      circle-radius="16"
      hint-content="Hint content 1"
      :marker-fill="{color: '#000000', opacity: 0.4}"
      :marker-stroke="{color: '#ff0000', width: 5}"
      :balloon="{header: 'EXTREME WATER', body: 'MCHJ', footer: '997772247'}"
    ></ymap-marker>
      </yandex-map>
    </div>
    <massage_box :hide="modal_status" :detail_info="modal_info"
      :m_text="$t('Failed_to_add')" @to_hide_modal="modal_status= false"/>
    <Toast ref="message"  style="z-index:2222222;"></Toast>
  </div>
</template>


<script>
import draggable from 'vuedraggable'
import { required } from 'vuelidate/lib/validators'
import {mdbIcon, mdbBtn, mdbInput} from 'mdbvue'
import { loadYmap } from 'vue-yandex-maps';
import { yandexMap, ymapMarker } from 'vue-yandex-maps'
import { mapActions, mapGetters } from 'vuex';
import myComponent from './ballon.vue'
import erpSelect from "../../components/erpSelectFio.vue";

export default {
  components:{
    mdbIcon, mdbBtn, mdbInput,
    yandexMap, ymapMarker,myComponent,
    erpSelect, draggable
  },
data() {
  return {
    show_car: false,
    modal_info: '',
    modal_status: false,
    loading: false,
    map_show: false,

    b_date: '',
    e_date: '',
    today_date: '',
    all_water_count: 0,
    postavchik_water_count: 0,

    order_list: [],
    postavchik_list: [],
    selectMark_id: null,

    user_name: '',
    user_id: null,
    auth_id: null,
  }
},
validations: {
  user_name: {required},
},
computed: {
  ...mapGetters(['allOrder_list', 'allUser']),
},
async mounted() {
  this.loading = true;
  const settings = { lang: 'en_US' };
    await loadYmap(settings);
    console.log(ymaps);
  await this.fetchUser();
  console.log(this.allOrder_list);
  this.loading = false;
  this.map_show = true;

  let date = new Date();
  this.today_date = date.toISOString().slice(0,10);
  this.b_date = this.today_date;
  this.e_date = this.today_date;
  let d_time = {
    b_date: this.b_date  + 'T00:00:01.504Z',
    e_date: this.e_date + 'T23:59:01.504Z',
  }
  await this.fetchDateOrderList(d_time);
},
methods: {
  ...mapActions(['fetchOrder_list', 'fetchUser']),
    bindListener() {
      document.getElementById('btnclose').addEventListener('click', this.closeOrder);
      document.getElementById('btn').addEventListener('click', this.handleropen);
    },
    unbindListener() {
      document.getElementById('btn').removeEventListener('click', this.handlerclose);
    },
    handleropen() {
      // this.$router.replace('https://t.me/extreme_water_bot')
      // this.$router.push('https://t.me/extreme_water_bot')
      window.history.pushState('https://t.me/extreme_water_bot')
    },
    handlerclose() {
      console.log('Ishladi close')
    },
    closeOrder(){
      // this.$router.push('/close_order/' + this.selectMark_id)
    },


  async sendFunc(mark){
    console.log('addeeddd')
    console.log(mark)
    this.selectMark_id = mark.id;
    await this.fetchAddMarkToPostavchik(mark.id)
  },
  async fetchAddMarkToPostavchik(id){
    try{
      this.loading = true;
      console.log(id)
      const res = await fetch(this.$store.state.hostname + '/WaterOrders/addOrderToUsersWithAuthid?id='+ id +'&user_auth_id=' + this.auth_id);
      const data = await res.json();
      this.loading = false;
      console.log(data)
      if(res.status == 200 || res.status == 201){
        this.$refs.message.success('Added_successfully')
        await this.acceptBtn();
        await this.fetchPostavchikList(this.auth_id);
      }
      else if(res.status == 400){
        this.$refs.message.error('postavchik_no_selected')
      }
      else{
        this.$refs.message.error('network_ne_connect')
      }
    }
    catch{
      this.$refs.message.error('network_ne_connect')
      this.loading = false;
    }
  },
  async deleteRow(item){
    try{
      this.loading = true;
      const res = await fetch(this.$store.state.hostname + '/WaterOrders/addDeOrderToUsersWithAuthidRemoveCar?id='+ item.id);
      const data = await res.json();
      this.loading = false;
      if(res.status == 200 || res.status == 201){
        // this.$refs.message.success('Added_successfully')
        await this.acceptBtn();
        await this.fetchPostavchikList(this.auth_id);
      }
      else if(res.status == 400){
        this.$refs.message.error('postavchik_no_selected')
      }
      else{
        this.$refs.message.error('network_ne_connect')
      }
    }
    catch{
      this.$refs.message.error('network_ne_connect')
      this.loading = false;
    }
    // console.log('qaytarish zakazni postavchikdan')
  },


  async acceptBtn(){
    let d_time = {
      b_date: this.b_date  + 'T00:00:01.504Z',
      e_date: this.e_date + 'T23:59:01.504Z',
    }
    await this.fetchDateOrderList(d_time);
  },


  async selectOption(option){
    console.log(option)
    this.user_name = option.fio;
    this.user_id = option.id;
    this.auth_id = option.auth.id;
    await this.fetchPostavchikList(this.auth_id);
  },
  
  async fetchPostavchikList(auth_id){
    let d_time = {
      b_date: this.b_date  + 'T00:00:01.504Z',
      e_date: this.e_date + 'T23:59:01.504Z',
    }
    try{
      this.loading = true;
      this.postavchik_list= [];
      console.log('dasdasd')
      const res = await fetch(this.$store.state.hostname + '/WaterOrders/getPaginationBeatweanDateWithoutTimeOpenOrdersListByAuthId?page=0&size=1000&begin_date='+ d_time.b_date+'&end_date=' + d_time.e_date + '&user_auth_id=' + auth_id);
      const data = await res.json();
      this.loading = false;
      console.log(data)
      if(res.status == 200 || res.status == 201){
        console.log('das')
        console.log(data.items_list)
        this.postavchik_list = data.items_list;
        this.postavchik_water_count = 0;
        for(let i=0; i<data.items_list.length; i++){
          this.postavchik_water_count += data.items_list[i].water_count;
        }
        console.log(this.postavchik_water_count)
      }
      else{
        this.$refs.message.error('network_ne_connect')
      }
      this.loading = false;
    }
    catch{
      this.$refs.message.error('network_ne_connect')
      this.loading = false;
    }
  },

  async fetchDateOrderList(date){
    try{
      this.loading = true;
      this.order_list= [];
      console.log(date)
      const res = await fetch(this.$store.state.hostname + '/WaterOrders/getPaginationBeatweanDateWithoutTimeOpenOrdersListByNotAddedAnyUser?page=0&size=10&begin_date='+ date.b_date+'&end_date=' + date.e_date);
      const data = await res.json();
      this.loading = false;
      console.log(data)
      if(res.status == 200 || res.status == 201){
        console.log('das')
        console.log(data.items_list)
        this.order_list = data.items_list;
        this.all_water_count = 0;
        for(let i=0; i<data.items_list.length; i++){
          this.all_water_count += data.items_list[i].water_count;
        }
        console.log(this.all_water_count)
      }
      else{
        this.$refs.message.error('network_ne_connect')
      }
      this.loading = false;
    }
    catch{
      this.$refs.message.error('network_ne_connect')
      this.loading = false;
    }
    },
},
}
</script>

<style lang="scss" scoped>
.carPage{
  position:fixed;
  top:0px; 
  bottom:0; 
  right:0; 
  background: white; 
  width:350px; 
  z-index:1111111; 
  cursor:pointer;
  transition: 0.5s;

}
.carPageClose{
   position:fixed;
  top:0px; 
  bottom:0; 
  right:-360px; 
  background: white; 
  width:350px; 
  z-index:1111111; 
  cursor:pointer;
  transition: 0.5s;

}
.InfoIcoFixed{
  transition: 0.5s;
  position:fixed;
  z-index: 11111;
  right:0; 
  top:145px; 
  width: 45px; 
  height:45px; 
  cursor:pointer;
  background-image: radial-gradient( circle farthest-corner at 12.3% 19.3%,  rgba(85,88,218,1) 0%, rgba(95,209,249,1) 100.2% );
  border-top-left-radius:5px; 
  border-bottom-left-radius:5px;
}
.InfoIcoFixedOpen{
  transition: 0.5s;
  position:fixed;
  z-index: 11111;
  right:350px; 
  top:145px; 
  width: 45px; 
  height:45px; 
  cursor:pointer;
   background-image: radial-gradient( circle farthest-corner at 12.3% 19.3%,  rgba(85,88,218,1) 0%, rgba(95,209,249,1) 100.2% );
  border-top-left-radius:5px; 
  border-bottom-left-radius:5px;
}
.bg_fon{
  margin-bottom: 2px;
   background-image: radial-gradient( circle farthest-corner at 1.3% 2.8%,  rgba(239,249,249,1) 0%, rgb(238, 245, 255) 100.2% );
   &:hover{
    background-image: radial-gradient( circle farthest-corner at 1.3% 2.8%,  rgba(239,249,249,1) 0%, rgba(182,199,226,1) 100.2% );
   }
}
.br_bm{
  border-bottom: 1px solid rgb(10, 64, 200);
}
.delIcon{color: rgb(251, 70, 70);
  font-size: 13px;
}
</style>