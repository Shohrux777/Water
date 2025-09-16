<template>
  <div>
    <LoaderTable v-if="loading"/>
    <div v-else class="pay_page">
      <div class="text-center mt-2 mb-3">
        <!-- <h6 class="m-0 mb-1 font-weight-bold">Z - {{order.address.id}}</h6> -->
        <h5 class="m-0 mb-2 text-success border-bottom" >{{summString}} сум</h5>
      </div>
      <div class="mx-3 mb-1">
        <div style="position:relative;">
          <input type="text" v-model="cashInString"  v-on:keyup.13 = "payed" @keyup="funcCash($event.target.value)"  
          ref="cashIn"  v-on:click.capture="cashNol"
          class="form-control  border mt-2 text-right pr-2" style="border:none; outline:none;font-weight:bold; height:30px;" >
          <small style="position:absolute; top:-16px; left:3px; font-size:11.5px; font-weight:bold; " class="testing">
            {{$t('cash')}}
          </small>
        </div> 
        <div style="position:relative;" class="mt-3">
          <input type="text" v-model="cardInString"  v-on:keyup.13 = "payed" @keyup="funcCard($event.target.value)"
          ref="cashIn" v-on:click.capture="cardNol" 
          class="form-control  border mt-2 text-right pr-2" style="border:none; outline:none;font-weight:bold; height:30px;" >
          <small style="position:absolute; top:-16px; left:3px; font-size:11.5px; font-weight:bold; " class="testing">
            {{$t('card')}}
          </small> 
        </div> 
        <div style="position:relative;" class="mt-3">
          <input type="text" v-model="get_bootle" @keyup="funcBootle($event.target.value)"
          ref="cashIn" v-on:click.capture="funcBootle" @blur="funcGetNol"
          class="form-control  border mt-2 text-right pr-2" style="border:none; outline:none;font-weight:bold; height:30px;" >
          <small style="position:absolute; top:-16px; left:3px; font-size:11.5px; font-weight:bold; " class="testing">
            {{$t('getten_bootle')}}
          </small>
        </div> 



        <div class="d-flex justify-content-between mt-2" style="font-size:13.5px;">
          <span v-if="parseFloat(defaultSum.toFixed(2)) > summa" class="text-success"> Больше денег </span>
          <span v-if="parseFloat(defaultSum.toFixed(2)) > summa" class="text-success">{{(parseFloat(defaultSum.toFixed(2))-summa).toFixed(2)}}</span>
        </div>
        <div class="d-flex justify-content-between mt-2" style="font-size:13.5px;">
          <span v-if="parseFloat(defaultSum.toFixed(2)) < summa" class="text-danger"> Не хватить </span>
          <span v-if="parseFloat(defaultSum.toFixed(2)) < summa" class="text-danger">{{(parseFloat(defaultSum.toFixed(2))-summa).toFixed(2)}}</span>
        </div>
      </div>
      <div class="d-flex justify-content-end mx-3 mt-0">
        <mdb-btn color="success" @click="payed" style="font-size: 9px"
            p="r4 l4 t2 b2">
          {{$t('pay')}}</mdb-btn>
      </div>

    
    </div>
      <massage_box :hide="modal_status" :detail_info="modal_info"
        :m_text="$t('Failed_to_add')" @to_hide_modal="modal_status= false"/>

      <Toast ref="message"></Toast>
  </div>
  
</template>

<script>
import {mdbBtn, } from "mdbvue"
import LoaderTable from "../../components/loaderTable.vue";

export default {
  components:{
    mdbBtn,
    LoaderTable
},
  data() {
    return {
      modal_info: '',
      modal_status: false,
      loading: false,

      cashInString: '0',
      cashIn: 0,
      cardInString: '0',
      cardIn: 0,

      summa: 0,
      discount: 0,
      discountSum: 0,
      defaultSum: 0,

      get_bootle: 0,
    }
  },
  props: {
    order:
    {
      type: Object,
      default(){
        return {}
      }
    },
    product_id : {
      type : Number,
      default : 0
    },
    bootle_qty : {
      type : Number,
      default : 0
    },
    summ: [String, Number],
    summString: String
  },
  methods: {
    getSumma(summ, summString){
      this.cashIn = summ;
      this.summa = summ;
      this.defaultSum = summ;
      this.cashInString = summString;
    },
    funcCash(n){
      this.discount = parseFloat(this.cashIn) + parseFloat(this.cardIn);
      this.discountSum = parseFloat(this.summa) - parseFloat(this.discount);
      this.discountSum = parseFloat(this.discountSum.toFixed(2))

      if(this.discountSum == 0){
      console.log('this.discountSum')
        this.cashIn = 0;
        this.cashInString = ''; 
        n = n[n.length-1];
      }

      console.log(n)
      var tols = ''
      for(let i=0; i<n.length; i++){
        if(n[i] != ' '){
          tols += n[i];
        }
       }

       this.cashInString = tols.replace(/(\d)(?=(\d{3})+(\.(\d){0,2})*$)/g, '$1 ');
       var temp = ''
       for(let i=0; i<this.cashInString.length; i++){
        if(this.cashInString[i] != ' '){
          temp += this.cashInString[i];
        }
       }
      this.cashIn = parseFloat(temp);
      this.defaultSum = parseFloat(this.cashIn) + parseFloat(this.cardIn);
    },
    funcCard(n){
      this.discount = parseFloat(this.cashIn) + parseFloat(this.cardIn);
      this.discountSum = parseFloat(this.summa) - parseFloat(this.discount);
      this.discountSum = parseFloat(this.discountSum.toFixed(2))

      if(this.discountSum == 0){
        console.log('this.discountSum')
        this.cardIn = 0;
        this.cardInString = ''; 
        n = n[n.length-1];
      }
      console.log(n)
      var tols = ''
      for(let i=0; i<n.length; i++){
        if(n[i] != ' '){
          tols += n[i];
        }
       }
       this.cardInString = tols.replace(/(\d)(?=(\d{3})+(\.(\d){0,2})*$)/g, '$1 ');
       var temp = ''
       for(let i=0; i<this.cardInString.length; i++){
        if(this.cardInString[i] != ' '){
          temp += this.cardInString[i];
        }
       }
      this.cardIn = parseFloat(temp);
      this.defaultSum = parseFloat(this.cashIn) + parseFloat(this.cardIn);
    },
    funcBootle(){
      if(this.get_bootle == 0){
        this.get_bootle = null;
      }
    },
    funcGetNol(){
      if(this.get_bootle == null){
        this.get_bootle = 0;
      }
    },
    cashNol(){
      this.discount = parseFloat(this.cashIn) + parseFloat(this.cardIn);
      this.discountSum = parseFloat(this.summa) - parseFloat(this.discount);

      if(this.cashIn == this.summa || this.cardIn == this.summa ){
        this.cashIn = this.summa;
        this.cashInString = this.cashIn.toString().replace(/(\d)(?=(\d{3})+(\.(\d){0,2})*$)/g, '$1 ');
        this.cardIn = 0;
        this.cardInString = '0';
        console.log('this.cashIn')
        console.log(this.cashIn)
      }
      else if(this.discountSum > 0){
        this.cashIn = parseFloat(this.discountSum.toFixed(2));
        console.log(this.cashIn)
        this.cashInString = this.cashIn.toString().replace(/(\d)(?=(\d{3})+(\.(\d){0,2})*$)/g, '$1 ');
      }

      this.defaultSum = this.cashIn + this.cardIn;
    },
    cardNol(){
      this.discount = parseFloat(this.cashIn) + parseFloat(this.cardIn);
      this.discountSum = parseFloat(this.summa) - parseFloat(this.discount);

      if(this.cashIn == this.summa || this.cardIn == this.summa ){
        this.cashIn = 0;
        this.cashInString = '0';
        this.cardIn = this.summa;
        this.cardInString = this.cardIn.toString().replace(/(\d)(?=(\d{3})+(\.(\d){0,2})*$)/g, '$1 ');
        console.log('this.cardIn')
        console.log(this.cardIn)
      }
       else if(this.discountSum > 0){
        this.cardIn = parseFloat(this.discountSum.toFixed(2));
        console.log(this.cardIn)
        this.cardInString = this.cardIn.toString().replace(/(\d)(?=(\d{3})+(\.(\d){0,2})*$)/g, '$1 ');
      }
      this.defaultSum = this.cashIn + this.cardIn;
    },
    async fetchBootle(){
      try{
        this.loading = true;
        const response = await fetch(this.$store.state.hostname + "/WaterOrders/addBotlfInfoToClientForAccept?olingan_bakalshka_soni=" + ((-1) * parseInt(this.get_bootle)) + '&berilgan_bakalshka_soni=' + this.bootle_qty + '&product_id=' + this.product_id + '&client_id=' + this.order.client.id + '&address_id=' + this.order.address.id);
        this.loading = false;
        if(response.status == 201 || response.status == 200)
        {
          const data = await response.json();
          console.log(data)
          this.$refs.message.success('Added_successfully')
          return true;
        }
        else{
          const data = await response.text();
          this.modal_info = data;
          this.modal_status = true;
          return false;
        }
      }
      catch{
        this.loading = false;
        this.modal_info = this.$i18n.t('network_ne_connect'); 
        this.modal_status = true;
        return false;
      }
    },
    async fetchCheck(){
      const requestOptions = {
        method : "POST",
        headers: { "Content-Type" : "application/json" },
        body: JSON.stringify({
          "cash" : this.cashIn,
          "card" : this.cardIn,
          "summ" : this.summa,
          "user_name": 'Z-' + this.order.address.id,
          "discount_pesantage": this.order.address.id,
          "waterAuthid": localStorage.AuthId,
          "id" : 0,
        })
      };
      try{
        this.loading = true;
        const response = await fetch(this.$store.state.hostname + "/WaterChecks", requestOptions);
      
        this.loading = false;
        if(response.status == 201 || response.status == 200)
        {
          this.$refs.message.success('Added_successfully')
          return true;
        }
        else{
          this.modal_info = this.$i18n.t('network_ne_connect');
          this.modal_status = true;
          return false;
        }
      }
      catch{
        this.loading = false;
        this.modal_info = this.$i18n.t('network_ne_connect'); 
        this.modal_status = true;
        return false;
      }
    },  

    async payed(){
      // await this.fetchBootle();
      // await this.fetchCheck();
      if(await this.fetchBootle() && await this.fetchCheck()){
        this.$emit('close')
      }
      // console.log('hiy enter')
    }
  },
}
</script>

<style>

</style>