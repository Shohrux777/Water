<template>
  <div class="close_order">
    <div class=" d-flex justify-content-center ">
      <h6 class="font-weight-bold p-0 m-0 mb-0">{{mark.client.fio}} \ {{mark.address.id}}</h6>
    </div>
    <div class=" d-flex justify-content-center border-bottom">
      <p style="font-size: 12px;" class="m-0 " :class="'text-'+mark.color_value">{{mark.order_date.slice(0,10)}}</p>
    </div>
    <div class="d-flex justify-content-between align-items-center dashed mb-1">
      <p style="font-size: 13px;" class="font-weight-bold m-0 mb-0 ml-2 mr-3">{{$t('fio')}}:</p>
      <p style="font-size: 13px;" class="m-0 text-right mr-2">{{mark.client_name_str}}</p>
    </div>
    <div class="d-flex justify-content-between align-items-center mb-1 dashed">
      <p style="font-size: 13px;" class="font-weight-bold m-0 ml-2 mb-0 mr-3">{{$t('address')}}:</p>
      <p style="font-size: 13px; " class="m-0 text-right mr-2">{{mark.address.address}}</p>
    </div>
    <div class="d-flex justify-content-between align-items-center  mb-1 dashed">
      <p style="font-size: 13px;" class="font-weight-bold m-0 mb-0 ml-2 mr-3">{{$t('phoneNumber')}}:</p>
      <p class="m-0 text-right mr-2">{{mark.phone_number_list_arr}}</p>
    </div>
    <div class="d-flex justify-content-between align-items-center mb-1 dashed">
      <p style="font-size: 13px;" class="font-weight-bold text-secondary ml-2 m-0 mb-0 mr-3">{{$t('ostatka_bootle')}}:</p>
      <p style="font-size: 13px;" class="m-0 text-right mr-2 font-weight-bold text-secondary">{{ostatik_bootle}} та</p>
    </div>
    <div class="d-flex justify-content-between align-items-center mb-1 dashed">
      <p style="font-size: 13px;" class="font-weight-bold text-success ml-2 m-0 mb-0 mr-3">{{$t('summ')}}:</p>
      <p style="font-size: 13px;" class="m-0 text-right mr-2 font-weight-bold text-success">{{summInString}} сум</p>
    </div>


    <div class=" d-flex justify-content-center mt-2">
      <h6 class="font-weight-bold p-0 m-0 mb-0">{{$t('order')}}</h6>
    </div>
    <div class="tableProduct mt-1">
      <table class="myTableproductList">
        <thead>
          <tr class="header py-3" style="background: #b0dcff;">
            <!-- <th  width="40" class="text-left">№</th> -->
            <th>{{$t('product')}}</th>
            <th class="text-center">{{$t('qty')}}</th>
            <th class="text-right" width="100">{{$t('summ')}}</th>
            <th class="text-right" width="70">{{$t('Action')}}</th>

            <!-- <th >{{$t('lessons_cout')}}</th> -->
          </tr>
        </thead>
        <tbody>
          <tr v-for="(row,rowIndex) in mark.items" :key="rowIndex">
            <!-- <td> <span >{{rowIndex+1}}</span> </td> -->
            <td> <span >{{row.product.name}}</span> </td>
            <td class="text-center"> <span >{{row.qty}}</span> </td>
            <td class="text-right"> <span >{{row.product.info}}</span> </td>
            <td class="text-right"><i class="fas fa-edit editIcon mask waves-effect  m-0 pr-2" v-on:click="editRow" :data-row="rowIndex"></i></td>
            <!-- <td> <span >{{row.lessons_cout}}</span> </td> -->
          </tr>
        </tbody>
      </table>
    </div>
    <div class="button mt-3">
       <div class="text-right">
        <!-- <mdb-btn color="primary"  id="btn" style="font-size: 9px"
          p="r4 l4 t2 b2">
        {{$t('telegram')}}</mdb-btn> -->
        <mdb-btn color="success" @click="closeOrder" style="font-size: 9px"
          p="r4 l4 t2 b2">
        {{$t('close_order')}}</mdb-btn>
      </div>
    </div>
    <modal-train  :show="pay_show" headerbackColor="white"  titlecolor="black" :title="$t('pay')" 
        @close="pay_show = false" width="95%">
          <template v-slot:body>
            <payOrder ref="payed"  @close="closePay" :order="mark" 
            :summ="order_summa" :summString="summInString"
            :product_id="main_product_id" :bootle_qty="main_product_qty"></payOrder>
          </template>
      </modal-train>
      <massage_box :hide="modal_status" :detail_info="modal_info"
        :m_text="$t('Failed_to_add')" @to_hide_modal="modal_status= false"/>

      <Toast ref="message"></Toast>
  </div>
</template>

<script>
import {mdbBtn, } from "mdbvue"
import payOrder from './pay.vue'
export default {
  components:{
    mdbBtn, payOrder
  },
  data() {
    return {
      modal_info: '',
      modal_status: false,
      loading: false,
      id: this.$route.params.id,

      order_summa: 0,
      pay_show: false,
      summInString: '',
      main_product_id: null,
      main_product_qty: 0,

      mark: {
        address:{
          id: 0,
          address: '01'
        },
        client: {
          fio:'',
        },
        order_date: '12-05-2022',
        phone_number_list_arr: '997772247'
      },
      ostatik_bootle: 0,
      main_client_id: null,
      water_address_id: null,
    }
  },
  async created()
  {
    if(this.id > 0)
    {
      const res = await fetch(this.$store.state.hostname + '/WaterOrders/getOrderFullInfoByid?order_id=' + this.id);
      const data = await res.json();
      console.log('this is by id')
      console.log(data)
      this.mark = data;
      this.main_client_id = data.waterClientid;
      this.water_address_id = data.waterClientAddressid;
      this.main_product_qty = 0;
      for(let i=0; i<data.items.length; i++){
        this.order_summa += parseFloat(data.items[i].qty* parseFloat(data.items[i].product.info));
        if(data.items[i].product.main_product == true){
          this.main_product_id = data.items[i].product.id;
          this.main_product_qty = data.items[i].qty
        }
      }
      this.summInString = new Intl.NumberFormat().format(this.order_summa)
      await this.fetchOstatka();
      
    }

  },
  methods: {
    editRow(){},
    async closeOrder(){
      this.pay_show = true;
      this.$refs.payed.getSumma(this.order_summa, this.summInString);
    },
    async fetchOstatka(){
      try{
        this.loadingSimple = true;
        const response = await fetch(this.$store.state.hostname + "/WaterClientBottleInfoes/getPaginationClientIdAndAddressId?page=0&size=1&client_id=" + this.main_client_id + '&address_id=' + this.water_address_id);
        const data = await response.json();
        this.loadingSimple = false;
        // this.clientAdd_show = false;
        console.log(data)
        if(data.items_list.length>0){
          this.ostatik_bootle = data.items_list[0].bottle_count
        }
        else{
          this.ostatik_bootle = 0
        }
      }
      catch{
        this.ostatik_bootle = 0
      }
    },
    async closePay(){
      this.pay_show = false;
      try{
        const res = await fetch(this.$store.state.hostname + '/WaterOrders/closeAcceptOrder?id=' + this.id);
        const data = await res.json();
        console.log(data)
        if(res.status == 200 || res.status == 201){
          this.$refs.message.success('Added_successfully')
          this.$router.push('/map_order');
        }
        else{
          this.modal_info = this.$i18n.t('network_ne_connect');
          this.modal_status = true;
        }
      }
      catch{
        this.modal_info = this.$i18n.t('network_ne_connect');
        this.modal_status = true;
      }
    }
  },
}
</script>

<style lang="scss">
.dashed{
  border-bottom: 1px dashed rgb(67, 67, 67);
}
.myTableproductList {
  /* border-collapse: collapse; */
  table-layout:fixed;
  width: 100%;
  overflow: hidden;
  // border: 1px solid #ddd;
  font-size: 18px;
  max-height:80px; overflow-x:auto
}
.myTableproductList th{
  font-weight: 600;
  font-size:11px;
}
.myTableproductList td{
  font-size:11.5px;
  
}
.myTableproductList td {
  text-align: left;
  padding: 9px 10px;
}
.myTableproductList th{
  text-align: left;
  padding: 8px 10px;
}

.myTableproductList tr {
  border-bottom: 1px dashed rgb(240, 240, 240);
  &:hover{
    background: #b0dcff;
  }
}

.myTableproductList tr.header, .myTableproductList tr:hover {
  // background-color: #f1f1f1;
}
.delIcon{
  color: rgb(251, 70, 70);
  font-size: 13px;
}
.editIcon{
  color:#bea804;
  font-size: 12px;

}
.editIcon:hover{
color: #000;
}

</style>