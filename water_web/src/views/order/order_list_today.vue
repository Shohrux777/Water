<template>
  <div class="order_table container">
    <div class="row">
      <div class="col-12">
        <div class="d-flex justify-content-start align-items-center">
          <input-icon style="width: 100%; height:30px;" v-model="search" :placeholder="$t('search_here')"></input-icon>
          <mdb-btn class="mr-1 ml-0  py-1 px-3"  style="font-size: 9px; height:28px; width:80px" color="info"  @click="searchClick()" 
            size="sm">{{$t('search')}}
          </mdb-btn>
          <div>
            <router-link to="/map_order">
              <img src="../../assets/map.jpg" width="35" height="32" alt="">
            </router-link>
          </div>
        </div>
      </div>
      <div class=" d-flex justify-content-center text-center w-100 mt-2">
        <h6 class="font-weight-bold p-0 m-0 mb-0">{{$t('order')}}</h6>
      </div>
      <div class="tableProduct mt-1">
        <table class="myTableOrderList ">
          <thead>
            <tr class="header py-3" style="background: #b0dcff;">
              <th  width="40" class="text-left">№</th>
              <th>{{$t('fio')}}</th>
              <th>{{$t('order')}}</th>
              <th >{{$t('qty')}}</th>
              <th  width="70">{{$t('Action')}}</th>

              <!-- <th >{{$t('lessons_cout')}}</th> -->
            </tr>
          </thead>
          <tbody>
            <tr v-for="(row,rowIndex) in allOrder_list" :key="rowIndex">
              <td> <span >{{rowIndex+1}}</span> </td>
              <td > <span >{{row.client.fio}}</span> </td>
              <td > <span >{{row.address.id}}</span> </td>
              <td class="pl-3"> <span >{{row.water_count}}</span> </td>
              <td class="text-right pr-3" @click="$router.push('/close_order/' + row.id)"><i class="fas fa-edit editIcon mask waves-effect  m-0 pr-2" :data-row="rowIndex"></i></td>
              <!-- <td> <span >{{row.lessons_cout}}</span> </td> -->
            </tr>
            <tr class="bg_footter">
              <td>{{allOrder_list.length+1}}</td>
              <td class="font-weight-bold">{{$t('all')}}</td>
              <td class="pl-3"></td>
              <td class="pl-3">{{all_qty}}</td>
              <td class="text-right pr-3"><i class="fas fa-check-circle m-0 pr-2" style="font-size: 14px; color:green;"></i></td>
            </tr>
          </tbody>
        </table>
      </div>
    
      
    </div>
  </div>
</template>

<script>
import {mdbBtn, mdbIcon, mdbInput} from 'mdbvue'
import { mapActions, mapGetters } from 'vuex';
export default {
components:{
    mdbBtn, 
    mdbIcon,mdbInput,
  },
  data() {
    return {
      search: '',
      all_qty: 0,
    }
  },
  async mounted() {
    await this.fetchOrder_list();
    for(let i=0; i<this.allOrder_list.length; i++){
      this.all_qty += parseFloat(this.allOrder_list[i].water_count)
    }
    console.log(this.allOrder_list)
  },
computed: mapGetters(['allOrder_list']),

  methods: {
    ...mapActions(['fetchOrder_list']),
    searchClick(){
      console.log('dsadas')
    }
  },
}
</script>

<style lang="scss">
.myTableOrderList {
  /* border-collapse: collapse; */
  table-layout:fixed;
  width: 100%;
  overflow: hidden;
  // border: 1px solid #ddd;
  font-size: 18px;
  max-height:80px; overflow-x:auto
}
.myTableOrderList th{
  font-weight: 600;
  font-size:11px;
}
.myTableOrderList td{
  font-size:11.5px;
  
}
.myTableOrderList td {
  text-align: left;
  padding: 9px 10px;
}
.myTableOrderList th{
  text-align: left;
  padding: 8px 10px;
}

.myTableOrderList tr {
  border-bottom: 1px dashed rgb(240, 240, 240);
  &:hover{
    background: #b0dcff;
  }
}

.myTableOrderList tr.header, .myTableOrderList tr:hover {
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