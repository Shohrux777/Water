using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot
{
    public class DatabaseManager
    {
        public String GetDbKey()
        {
            string bot_key = String.Empty;
            try
            {
                bot_key = ConfigurationManager.AppSettings["db_connection"];
            }
            catch (Exception e)
            {
                bot_key = String.Empty;
            }
            return bot_key;
        }


        public List<WaterClient> getClientListInfoIds(String fio) {
            fio = fio.Replace("'","  ");
            List<WaterClient> clients = new List<WaterClient>();
            try {
                var cs = GetDbKey();
                using var con = new NpgsqlConnection(cs);
                con.Open();
                string sql =    "  SELECT     "+
                                "  wc.fio as fio,      " +
                                "  wc.note as note,     " +
                                "  wc.note4 as image_url,     " +
                                "  wc.reserverd_number_id_1 as qiyin_status,     " +
                                "  wca.address as address,      " +
                                "  wt.name as tuman,      " +
                                "  wca.latidu as latit,      " +
                                "  wca.longitu as longit,      " +
                                "  (SELECT array_to_string(array_agg(wcpn.phone_number), ' ')    " +
                                "  FROM water_client_phone_number wcpn WHERE  wcpn.\"WaterClientid\" = wc.id) as phone_number,    " +
                                "  (SELECT array_to_string(array_agg(wcbi.bottle_count_real), ' ')    " +
                                "  FROM water_client_bottle_info wcbi    " +
                                "  WHERE wcbi.\"WaterClientAddressid\" = wca.id) as bakalashka    " +
                                "  FROM water_client wc    " +
                                "  LEFT JOIN water_client_address wca ON wca.\"WaterClientid\" = wc.id    " +
                                "  LEFT JOIN water_tuman wt ON wt.id = wca.\"WaterTumanid\"    " +
                                "  WHERE LOWER(wc.fio) = LOWER('" + fio.Trim() + "'); ";

               

                using (NpgsqlCommand command = new NpgsqlCommand(sql, con))
                {
                    

                    NpgsqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        String fio_client = reader[0].ToString();
                        String note = reader[1].ToString();
                        String image_url = reader[2].ToString();
                        long qiyin_status = long.Parse(reader[3].ToString());
                        String adress = reader[4].ToString();
                        String tuman = reader[5].ToString();
                        double lat = Double.Parse(reader[6].ToString());
                        double lan = Double.Parse(reader[7].ToString());
                        String phone_list = reader[8].ToString();
                        String bakalashka = reader[9].ToString();

                        WaterClient client = new WaterClient();
                        client.fio = fio_client;
                        client.lati = lat;
                        client.longi = lan;
                        client.tuman = tuman;
                        client.address = adress;
                        client.image_url = image_url;
                        client.note = note;
                        client.qiyin_status = qiyin_status;
                        client.phone_number = phone_list;
                        client.bakalashka = bakalashka;
                        clients.Add(client);
                        
                    }
                }

                con.Close();
            }
            catch (NullReferenceException)
            {

                return clients;
            }

            return clients;

        }

        public WaterAddress getAddressFullInfo( long id) {
            try
            {
                var cs = GetDbKey();
                WaterAddress address = new WaterAddress();
                using var con = new NpgsqlConnection(cs);
                con.Open();
                string sql =    " SELECT  "+
                                " wc.fio, "+
                                " wt.name, "+
                                " wa.address, "+ 
                                " wa.latidu, " +
                                " wa.longitu "+
                                " FROM water_client_address wa "+
                                " LEFT JOIN water_client wc ON wc.id = wa.\"WaterClientid\"  "+
                                " LEFT JOIN water_tuman wt ON wt.id = wa.\"WaterTumanid\"  "+
                                " WHERE wa.id = "+id+" LIMIT 1 ";

                using (NpgsqlCommand command = new NpgsqlCommand(sql, con))
                {
                   
                    NpgsqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        String client_name = reader[0].ToString();
                        String tuman_name = reader[1].ToString();
                        String address_name = reader[2].ToString();
                        double lat = Double.Parse(reader[3].ToString());
                        double lan = Double.Parse(reader[4].ToString());
                        address.address = address_name;
                        address.client_name = client_name;
                        address.tuman_nomi = tuman_name;
                        address.lat = lat;
                        address.lan = lan;
                    }
                }

                con.Close();
                return address;
            }
            catch (NullReferenceException)
            {

                return new WaterAddress();
            }

        }
        public String getServiceTypeList() {

            try
            {
                var cs = GetDbKey();
                using var con = new NpgsqlConnection(cs);
                con.Open();
                var sql = "SELECT  \"hospitalServiceInfo\" FROM \"HospitalFullInfo\" LIMIT 1;";
                using var cmd = new NpgsqlCommand(sql, con);
                object resObj = cmd.ExecuteScalar();
                var version = "Service";
                if (resObj != null) {
                     version = resObj.ToString();
                }
                
                con.Close();
                return version;
            }
            catch (NullReferenceException) {

                return String.Empty;
            }

        }
        
        public String getInformation()
        {
            try {
                var cs = GetDbKey();
                using var con = new NpgsqlConnection(cs);
                con.Open();
                var sql = "SELECT  \"hospitalContacInfoStr\" FROM \"HospitalFullInfo\" LIMIT 1;";
                using var cmd = new NpgsqlCommand(sql, con);
                object resObj = cmd.ExecuteScalar();
                var version = "Information";
                if (resObj != null)
                {
                    version = resObj.ToString();
                }


                con.Close();
                return version;

            }
            catch (NullReferenceException) {

                return String.Empty;
            }
}
        public String registratsiyaContragent(String contactStr,long chatId)
        {
            try
            {
                var cs = GetDbKey();
                using var con = new NpgsqlConnection(cs);
                con.Open();
                var sql = "UPDATE contragents SET  \"chatBotId\"= "+ chatId + " WHERE \"PhoneNumber\"='"+ contactStr + "' RETURNING  \"Name\"";
                using var cmd = new NpgsqlCommand(sql, con);
                object resObj = cmd.ExecuteScalar();
                var version = "Not found ";
                if (resObj != null)
                {
                    version = resObj.ToString();
                }
                con.Close();
                return version;
            }
            catch (NullReferenceException)
            {

                return String.Empty;
            }

            
        }
    }
}
