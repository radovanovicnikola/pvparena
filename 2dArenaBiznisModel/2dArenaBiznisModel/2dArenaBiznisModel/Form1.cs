using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NHibernate;
using NHibernate.Linq;
using Arena.Entiteti;

namespace Arena
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


//
//
//
//
//
//
  /*      private void cmdKreiranjePoslanickeGrupe_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();


                PoslanickaGrupa pg = new PoslanickaGrupa();

                SluzbenaProstorijaID sp = new SluzbenaProstorijaID();


                sp.Sprat = 9;
                sp.BrojProstorije = 99;
                pg.ImeGrupe = "Prva";
                pg.posedujeProstorije.Add(s.Load<SluzbenaProstorija>(sp));
                pg.posedujeProstorije[0].jePosedujeGrupa = pg;


                s.Save(pg);


                s.Flush();
                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdKreiranjeSednice_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();


                Vandredna se = new Vandredna();


                se.BrZasedanja = 5;
               
                se.BrSaziva = 33;
                se.Pocetak = new DateTime(2017, 11, 05); 
                se.Zavrsetak = new DateTime(2017, 11, 06);
                se.jeSazvana.Add((from p in s.Query<Entiteti.NarodniPoslanik>() where (p.Licno_ime == "Luka" && p.Prezime == "Maksimovic") select p).First());
                se.jeSazvana[0].JeSazvao.Add(se);
           
                

                s.Save(se);
                s.Flush();
                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdKreiranjeRadnogTela_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();


                RadnoTelo rt = new Komisije();


                List<Entiteti.NarodniPoslanik> listaNP = (from np in s.Query<Entiteti.NarodniPoslanik>() where (np.idNP > 5 && np.idNP < 12) select np).ToList<Entiteti.NarodniPoslanik>();
                foreach (Entiteti.NarodniPoslanik np in listaNP)
                {
                    rt.Clanovi.Add(np);
                    np.JeClanRT = rt;
                }
                rt.jePredsednik = listaNP[0];
                listaNP[0].JePredsednikRT = rt;
                rt.jeZamenik = listaNP[1];
                listaNP[1].JeZamenikURT = rt;
                SluzbenaProstorija sp = new SluzbenaProstorija();
                sp.SPID.BrojProstorije = 77;
                sp.SPID.Sprat = 7;
                sp.jePosedujeTelo = rt;
                rt.prostorijaRT = sp;
                s.Save(rt);
                s.Flush();
                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdKreiranjePravnogAkta_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();


                PravniAkt pa = new Zakon();


                pa.BrBiraca = 5;
             
                IList<Entiteti.NarodniPoslanik> listNP= (from np in s.Query<Entiteti.NarodniPoslanik>() where(np.idNP>15 && np.idNP<130) select np).ToList<Entiteti.NarodniPoslanik>();
                foreach(Entiteti.NarodniPoslanik np in listNP)
                {
                    pa.jePredlozio.Add(np);
                    np.JePredlozio.Add(pa);
                }

                s.Save(pa);
                s.Flush(); 
                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        #endregion

        #region Brisanje

        private void cmdObrisiNarodnuSkupstinu_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                NarodnaSkupstina.Entiteti.NarodniPoslanik p = s.Load<NarodnaSkupstina.Entiteti.NarodniPoslanik>(61);
                s.Delete(p);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdObrisiSluzbenuProstoriju_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                SluzbenaProstorijaID sid = new SluzbenaProstorijaID();
                sid.Sprat = 9;
                sid.BrojProstorije = 99;
                SluzbenaProstorijaID sid2 = new SluzbenaProstorijaID();
                sid2.Sprat = 9;
                sid2.BrojProstorije = 98;


                SluzbenaProstorija sp = s.Load<SluzbenaProstorija>(sid);
                SluzbenaProstorija sp2 = s.Load<SluzbenaProstorija>(sid2);


                s.Delete(sp);
                s.Delete(sp2);
                
                s.Flush();
                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdObrisiPoslanickeGrupe_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                PoslanickaGrupa pg = s.Load<PoslanickaGrupa>("Prva");

                s.Delete(pg);

                s.Flush();
                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdObrisiNarodnogPoslanika_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                List<Entiteti.NarodniPoslanik> lp = (from np in s.Query<Entiteti.NarodniPoslanik>() where (np.jmbg == "5555555555501" || np.jmbg == "5555555555502") select np).ToList();


                s.Delete(lp[0]);
                s.Delete(lp[1]);

                s.Flush();
                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdObrisiSednice_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Vandredna se = (from sed in s.Query<Vandredna>() where (sed.BrSaziva == 33 && sed.BrZasedanja==5) select sed).First();
                s.Delete(se);

                s.Flush();
                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdObrisiRadnoTelo_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                SluzbenaProstorijaID sid = new SluzbenaProstorijaID();
                sid.BrojProstorije = 77;
                sid.Sprat = 7;
                RadnoTelo rt = (from rad in s.Query<RadnoTelo>() where(rad.prostorijaRT.SPID==sid) select rad).First();

                s.Delete(rt);

                s.Flush();
                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdObrisiPravniAkt_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                PravniAkt pa = (from pakt in s.Query<Zakon>() where (pakt.BrBiraca == 5) select pakt).First();


                s.Delete(pa);

                s.Flush();
                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        #endregion

        #region Azuriranje

        private void cmdAzurirajPravniAkt_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                PravniAkt pa = (from pakt in s.Query<Zakon>() where (pakt.BrBiraca == 5) select pakt).First();

                Entiteti.NarodniPoslanik np = s.Get<Entiteti.NarodniPoslanik>(3);
                pa.jePredlozio.Add(np);
                np.JePredlozio.Add(pa);
             
                //poziva se Update i objekat se povezuje sa novom sesijom
                s.Update(pa);

                s.Flush();
                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdAzurirajRadnoTelo_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                SluzbenaProstorijaID sid = new SluzbenaProstorijaID();
                sid.BrojProstorije = 77;
                sid.Sprat = 7;

                RadnoTelo rt = (from rad in s.Query<RadnoTelo>() where (rad.prostorijaRT.SPID == sid) select rad).First();

                Entiteti.NarodniPoslanik tmp = rt.jeZamenik;
                rt.jeZamenik = rt.jePredsednik;
                rt.jePredsednik = null;
                rt.jeZamenik.JeZamenikURT = rt;

                rt.jePredsednik = tmp;
                tmp.JeZamenikURT = null;
                tmp.JePredsednikRT = rt;



                //poziva se Update i objekat se povezuje sa novom sesijom
                s.Update(rt);

                s.Flush();
                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdAzurirajSednice_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Vandredna se = s.Load<Vandredna>(502);

                se.jeSazvana.Add((from np in s.Query<Entiteti.NarodniPoslanik>() where (np.idNP > 150) select np).First());
                         
                            
                
                //poziva se Update i objekat se povezuje sa novom sesijom
                s.Update(se);

                s.Flush();
                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdAzurirajPoslanickeGrupe_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                PoslanickaGrupa pg = s.Load<PoslanickaGrupa>("Prva");

                List<Entiteti.NarodniPoslanik> listNP=(from np in s.Query<Entiteti.NarodniPoslanik>() where (np.jmbg=="5555555555501" || np.jmbg== "5555555555502") select np).ToList();
                pg.predsednik = listNP[0];
                pg.predsednik.JePredsednikGrupi = pg;
                pg.clan.Add(listNP[1]);
                pg.zamenik = listNP[1];
                pg.zamenik.JeZamenikUGrupi = pg;
                pg.clan.Add(listNP[1]);



                //poziva se Update i objekat se povezuje sa novom sesijom
                s.Update(pg);

                s.Flush();
                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdAzurirajSluzbenuProstoriju_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                SluzbenaProstorijaID idp = new SluzbenaProstorijaID();
                idp.BrojProstorije = 98;
                idp.Sprat = 9;
                SluzbenaProstorija sp = s.Load<SluzbenaProstorija>(idp);

                sp.jePosedujeGrupa = s.Load<PoslanickaGrupa>("Prva");
                sp.jePosedujeGrupa.posedujeProstorije.Add(sp);

                

                
                //poziva se Update i objekat se povezuje sa novom sesijom
                s.Update(sp.jePosedujeGrupa);

                s.Flush();
            
                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdAzurirajNarodnogPoslanika_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                List<Entiteti.NarodniPoslanik> lp = (from np in s.Query<Entiteti.NarodniPoslanik>() where (np.jmbg == "5555555555501" || np.jmbg == "5555555555502") select np).ToList();



                s.Close();
                lp[0].Mesto_stanovanja = "Kraljevo";
                lp[1].Mesto_stanovanja = "Valjevo";
                ISession s1 = DataLayer.GetSession();
                //poziva se Update i objekat se povezuje sa novom sesijom
                s1.Update(lp[0]);
                s1.Update(lp[1]);
                s1.Flush();
                s1.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }




        #endregion

        private void button7_Click(object sender, EventArgs e)
        {
            ISession s = DataLayer.GetSession();

            IList<object[]> lista = s.QueryOver<Entiteti.NarodniPoslanik>().Select(x=>x.Licno_ime,x=>x.Prezime).List<object[]>();
               
            string CQ="";
            foreach (object[] ime_prez in lista)
            {
                CQ += (string)ime_prez[0] + " " + (string) ime_prez[1]+"\n";
            }
            MessageBox.Show("QueryOver:\n"+CQ);
            s.Close();

   
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ISession s = DataLayer.GetSession();
            IEnumerable<Entiteti.NarodniPoslanik> np = from n in s.Query<Entiteti.NarodniPoslanik>() where (n.PripadaGrupi.ImeGrupe == "SPN" && n.Licno_ime == "Luka") select n;
          
            Entiteti.NarodniPoslanik tmp = np.First<Entiteti.NarodniPoslanik>();
            string text = "";
            text+= "Narodni poslanik: " +tmp.Licno_ime + " " + tmp.Ime_jednog_roditelja + " " + tmp.Prezime+"\n";
            text += "Brojevi telefona:\n";
            foreach (MobilniTelefon m in tmp.Mobilni_telefon)
            {
                text += "Mobilni: " + m.MID.Mobilni+"\n";
            }
            foreach (FiskniTelefon f in tmp.Fiksni_telefon)
            {
                text += "Fiksni: " + f.FID.Fiksni + "\n";
            }
            MessageBox.Show(text);

            s.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Entiteti.PoslanickaGrupa pg=s.Get<PoslanickaGrupa>("SPN");                
                string stmp = "";
                stmp += "Poslanicla grupa " + pg.ImeGrupe + " poseduje prostorijue:\n ";

                foreach (Entiteti.SluzbenaProstorija sp in pg.posedujeProstorije)
                {
                    stmp += "sprat: " + sp.SPID.Sprat + ", broj: " + sp.SPID.BrojProstorije+"\n";
                }
                stmp += "Predsednik grupe je: " + pg.predsednik.Licno_ime + " " + pg.predsednik.Prezime + "\n";
                stmp += "Zamenik grupe je: " + pg.zamenik.Licno_ime + " " + pg.zamenik.Prezime + "\n";
                MessageBox.Show(stmp);
                s.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Sednica so = s.QueryOver<Sednica>().List().First();
                
                
                string text = "";
                text += "Id sednice: " + so.IDSednice + "\n";
                text += "Zasedanje: " + so.BrZasedanja + "Saziv: " + so.BrSaziva;
                MessageBox.Show(text);
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                IQuery q = s.CreateQuery("from RadnoTelo where idRT= 252; ");

                object rcvObj = q.UniqueResult();

                string rtstr = "";
                if (rcvObj.GetType() == typeof(StalniOdbori))
                    rtstr += "stalni odbor";
                else if (rcvObj.GetType() == typeof(PrivremeniOdbori))
                    rtstr += "privremeni odbor";
                else if (rcvObj.GetType() == typeof(Komisije))
                    rtstr += "komisije";
                else if (rcvObj.GetType() == typeof(AnketniOdbori))
                    rtstr += "anketni odbor";
                RadnoTelo rt = (RadnoTelo)rcvObj;
                string text = "Clanovi radnog tela "+rtstr+" su:\n";
                foreach (Entiteti.NarodniPoslanik np in rt.Clanovi)
                {
                    text += np.Licno_ime + " " + np.Prezime + "\n";
                }
                s.Close();
                text += "Predsednik: " + rt.jePredsednik.Licno_ime + " " + rt.jePredsednik.Prezime + "\n";
                text += "Zamenik: " + rt.jeZamenik.Licno_ime + " " + rt.jeZamenik.Prezime + "\n";
                MessageBox.Show(text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                object rcvObj = (from akt in s.Query<PravniAkt>() where (akt.IDAkta == 1001) select akt).First();
               
                string text = "Pravni akt: ";
                if (rcvObj.GetType() == typeof(Zakon))
                    text += "zakon:\n";
                else if (rcvObj.GetType() == typeof(Tumacenja))
                    text += "tumacenja:\n";
                else if (rcvObj.GetType() == typeof(Preporuke))
                    text += "preporuke:\n";
                else if (rcvObj.GetType() == typeof(Deklaracije))
                    text += "deklaracije:\n";
                else if (rcvObj.GetType() == typeof(Odluke))
                    text += "odluke:\n";

                PravniAkt pa = (PravniAkt)rcvObj;
                
                   
                
                text += "Predlozili su ga narodni poslanici:\n ";
                foreach (Entiteti.NarodniPoslanik np in pa.jePredlozio)
                {
                    text += np.Licno_ime + " " + np.Prezime + "\n";
                }
                s.Close();
                text += "Pravni akt je izglasalo: " + pa.BrBiraca + " biraca\n";
                MessageBox.Show(text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                RadniDan rd = new RadniDan();
                rd.RID = new RadniDanID();
                rd.RID.BrPoslanika = 4;
                rd.RID.Vreme = 5;
                rd.RID.RDSednica = s.Get<Sednica>(24);
                s.Save(rd);
                s.Flush();

                Sednica sed = s.Get<Sednica>(24);
                s.Close();
            }
            catch(Exception ec)
            {
                int v;
                v = 2;
            }
        }
*/
        private void cmdKreirajKorisnika_click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();


                Entiteti.User u = new Entiteti.User();

                u.UserName = "aca";
                u.Password = "aca223";
                u.RegistarDate = DateTime.Now;
                

                
                s.Save(u);

                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdKreirajIgru_Click(object sender, EventArgs e)
        {
            try {

                ISession s = DataLayer.GetSession();

                Game g = new Game();
                User u = s.Load<User>("aca");
                g.User = u;
                u.Played.Add(g);

                g.DatePlayed = DateTime.Now;
                g.Deths = 2;
                g.Kills = 3;
                Map m = new Map();
                m.MapName = "Suma";
                m.MaxPlayer = 12;
                m.PlayedIn.Add(g);
                g.Map = m;
                g.HType = s.Load<HeroType>(1);

                s.Save(m);
                s.Save(g);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }

        }

        private void cmdObrisiKorisnika_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Arena.Entiteti.User u = s.Load<Arena.Entiteti.User>("aca");
                s.Delete(u);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }

        }

        private void cmdKreirajHeroja_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Hero h = new Hero();
                h.ArmorUp = 10;
                h.AttackUp = 15;
                h.SpeedUp = 20;

                HeroType ht = new HeroType();
                ht.Attack = 50;
                ht.Armor = 60;
                ht.Speed = 65;
                h.HType = ht;


                User u = s.Load<User>("aca");



                h.User = u;
                u.Have.Add(h);
                s.Save(ht);
                s.Save(h);

                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void KreirajTipHeroja_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                HeroType ht = new HeroType();
                ht.Attack = 60;
                ht.Armor = 40;
                ht.Speed = 50;

                s.Save(ht);


                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdKreirajMapu_Click(object sender, EventArgs e)
        {
            try
            {

                ISession s = DataLayer.GetSession();

                Map m = new Map();
                m.MapName = "Planina";
                m.MaxPlayer = 12;
                

                s.Save(m);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }

        }

        private void cmdObrisiIgru_Click(object sender, EventArgs e)
        {
            try
            {

                ISession s = DataLayer.GetSession();

                Game g = s.Load<Game>(1);

                s.Delete(g);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdObrisiHeroja_Click(object sender, EventArgs e)
        {
            try
            {

                ISession s = DataLayer.GetSession();

                List<Hero> lh = (from h in s.Query<Entiteti.Hero>() where (h.ArmorUp == 10 || h.AttackUp == 15 || h.SpeedUp == 20) select h).ToList();

                foreach( Hero h in lh)
                    s.Delete(h);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdObrisiTipHeroja_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                List<HeroType> lh = (from hp in s.Query<Entiteti.HeroType>() where (hp.Armor == 60 || hp.Attack == 50 || hp.Speed == 65) select hp).ToList();

                foreach (HeroType h in lh)
                    s.Delete(h);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdObrisiMapu_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                List<Map> map = (from m in s.Query<Map>() where (m.MapName == "Planina" || m.MapName == "Suma") select m).ToList();

                foreach (Map m in map)
                    s.Delete(m);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }

        }

        private void cmdPrikaziMapu_Click(object sender, EventArgs e)
        {
                try
                {
                    ISession s = DataLayer.GetSession();

                    List<Map> mapes= (from m in s.Query<Map>() select m).ToList();
                    string str = "";
                    foreach (Map m in mapes)
                        str += "Ime mape: " + m.MapName + " Maksimalno igraca: " + m.MaxPlayer +"\n";
                    MessageBox.Show(str);
                    s.Flush();
                    s.Close();
                }
                catch (Exception ec)
                {
                    MessageBox.Show(ec.Message);
                }
            }

        private void cmdAzurirajKorisnika_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                User user = s.Get<User>("aca");

                user.Password = "123Aca";

                s.SaveOrUpdate(user);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdAzurirajIgru_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                User user = s.Get<User>("aca");


                Game game = (from g in s.Query<Game>() where (g.User == user) select g).First();

                game.ErnedExp = 150;
                s.SaveOrUpdate(game);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdAzurirajHeroja_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                User user = s.Get<User>("aca");


                Hero hero= (from h in s.Query<Hero>() where (h.User == user) select h).First();

                hero.ArmorUp = 15;
                s.SaveOrUpdate(hero);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdAzurirajTip_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                HeroType lh = (from hp in s.Query<Entiteti.HeroType>() where (hp.Armor == 60 || hp.Attack == 50 || hp.Speed == 65) select hp).ToList().First();
                lh.Name = "Hunter";
                             
                
                s.SaveOrUpdate(lh);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdAzurirajMapu_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Map map = (from m in s.Query<Map>() where (m.MapName == "Planina") select m).First();

                map.MaxPlayer = 20;
                s.SaveOrUpdate(map);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
            

        }

        private void cmdPregledajKorisnika_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                List<User> users = (from u in s.Query<User>()  select u).ToList();

                string str = "Korisnici:\n";
                foreach (User u in users)
                    str += u.UserName + "\t" + u.Experiance+"\n";
                s.Close();
                MessageBox.Show(str);
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdPrikazijIgru_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();


                List<Game> games = (from g in s.Query<Game>() select g).ToList();

                string str= "   Datum igranja   ||  Igrac   ||    Ubistva   ||  Smrti   ||  Exp\n";
                foreach (Game g in games)
                    str += g.DatePlayed + " || " + g.User.UserName + " ||       " + g.Kills + "     ||      " + g.Deths + "     ||      " + g.ErnedExp+"\n";
                s.Close();
                MessageBox.Show(str);
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }


        }

        private void cmdPrikaziHeroja_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                List<Hero> heroes = (from h in s.Query<Hero>() select h).ToList();
                string str = "Heroji:\n";
                foreach (Hero h in heroes)
                    str += "Id: " + h.Id + "    username igraca kome pripada: " + h.User.UserName + "\n";
                MessageBox.Show(str);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdPrikaziTipHeroja_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                List<HeroType> types = (from t in s.Query<HeroType>() select t).ToList();
                string str="";
                foreach (HeroType t in types)
                    str += "Ime tipa: " + t.Name + " Snaga: " + t.Armor + " Napad: " + t.Attack + " Brzina: " + t.Speed + "\n";
                MessageBox.Show(str);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }
    }
}

