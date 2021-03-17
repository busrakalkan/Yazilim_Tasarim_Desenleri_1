using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        #region decoratorDeseni
        public interface ClasTipi
        {
            decimal ucret();
            string aciklama();
        }

        public class Kumpir : ClasTipi
        {
            public decimal ucret()
            {
                return 5.00m;
            }
            public string aciklama()
            {
                return "Kumpir";
            }

        }
        public class Waffle : ClasTipi
        {
            public decimal ucret()
            {
                return 6.00m;
            }
            public string aciklama()
            {
                return "Waffle";
            }

        }
        public class Mantar : ClasTipi
        {
            ClasTipi _kumpir;

            public Mantar(ClasTipi kumpir)
            {
                _kumpir = kumpir;

            }

            public decimal ucret()

            {
                return 2.00m + _kumpir.ucret();

            }

            public string aciklama()

            {
                return "Mantarlı " + _kumpir.aciklama();

            }

        }
        public class Misir : ClasTipi

        {
            ClasTipi _kumpir;

            public Misir(ClasTipi kumpir)

            {
                _kumpir = kumpir;

            }

            public decimal ucret()

            {
                return 2.00m + _kumpir.ucret();

            }

            public string aciklama()

            {
                return "Mısırlı " + _kumpir.aciklama();

            }

        }
        public class Çilek : ClasTipi
        {
            ClasTipi _waffle;

            public Çilek(ClasTipi waffle)
            {
                _waffle = waffle;
            }
            public decimal ucret()
            {
                return 2.00m + _waffle.ucret();
            }
            public string aciklama()
            {
                return "Çilekli " + _waffle.aciklama();
            }
        }
        public class Muz : ClasTipi
        {
            ClasTipi _waffle;

            public Muz(ClasTipi waffle)
            {
                _waffle = waffle;
            }
            public decimal ucret()
            {
                return 2.00m + _waffle.ucret();
            }
            public string aciklama()
            {
                return "Muzlu " + _waffle.aciklama();
            }
        }
        #endregion

        
        #region strategyDeseni

        interface  IStrategy
        {
            void Uret();

        }

        class Kumpir1 : IStrategy
        {
            public void Uret()
            {
                MessageBox.Show("Kumpir siparişi kaydedildi.");

            }
        }
        class Waffle1 : IStrategy
        {
            public void Uret()
            {
                MessageBox.Show("Waffle siparişi kaydedildi.");
            }
        }
        class Uretici
        {
            private IStrategy _uret;
            public Uretici(IStrategy _uret)
            {
                this._uret = _uret;
            }

            public void Uret()
            {
                this._uret.Uret();
            }
        }
        #endregion

 
        #region abstractFactoryDeseni

        //Product A
        abstract class Kumpir2
        {
            public abstract void KumpirTipi();

            public abstract string State { get; }
        }

        //Product B
        abstract class Waffle2
        {
            public abstract bool WaffleTipi();
            public abstract string State { get; }

        }

        //Concrete Product A1
        class YalovaKumpiri : Kumpir2
        {
            public override string State => "Open";

            public override void KumpirTipi()
            {
                MessageBox.Show("Yalova Şubesi Seçildi.");

                // return açk;
            }

        }

        //Concrete Product A2
        class YalovaWaffleı : Waffle2
        {
            public override string State => "Open";
            public override bool WaffleTipi()
            {
                MessageBox.Show("Şubede bulunmayan malzemeler listeden çıkarıldı.");
                return true;
            }
        }


        //Concrete Product B1
        class IstanbulKumpiri : Kumpir2
        {
            public override string State => "Open";
            public override void KumpirTipi()
            {
                MessageBox.Show("İstanbul Şubesi Seçildi.");
                // return açk ;
            }

        }

        //Concrete Product B2
        class IstanbulWaffleı : Waffle2
        {
            public override string State => "Open";
            public override bool WaffleTipi()
            {
                MessageBox.Show("İstanbul Şubesi Seçildi.");
                return true;
            }
        }

        //Abstract Factory
        abstract class DatabaseFactory
        {
            public abstract Kumpir2 CreateKumpir();
            public abstract Waffle2 CreateWaffle();
        }
        //Concreate Factory A
        class YalovaSubesı : DatabaseFactory
        {
            public override Kumpir2 CreateKumpir() => new YalovaKumpiri();
            public override Waffle2 CreateWaffle() => new YalovaWaffleı();
        }

        //Concreate Factory
        class IstanbulŞubesi : DatabaseFactory
        {
            public override Kumpir2 CreateKumpir() => new IstanbulKumpiri();
            public override Waffle2 CreateWaffle() => new IstanbulWaffleı();
        }

        //Creater
        class Creater
        {
            DatabaseFactory _databaseFactory;
            Kumpir2 _kumpir;
            Waffle2 _waffle;
            public Creater(DatabaseFactory databaseFactory)
            {
                _databaseFactory = databaseFactory;
                _kumpir = _databaseFactory.CreateKumpir();
                _waffle = _databaseFactory.CreateWaffle();

                Start();
            }

            void Start()
            {
                if (_kumpir.State == "Open")
                {
                    _kumpir.KumpirTipi();

                    _waffle.WaffleTipi();
                }
            }


        }
        #endregion

        
        #region singeltonDeseni
        class Singleton
        {
            private Singleton() { }

            private static Singleton marka;

            public static Singleton NesneVer()
            {
                if (marka == null)
                {
                    marka = new Singleton();
                }
                return marka;
            }
        }
        #endregion
    

        #region observerDeseni
        abstract public class Observer
        {
            public abstract void Update();
        }



        public class KuryeObserver : Observer
        {
            public override void Update()
            {
                MessageBox.Show("Siparişiniz Kuryeye Verildi.");
            }
        }


        public class Kurye
        {
            bool sipariş;
            public bool SiparişVeridiMi
            {
                get { return sipariş; }
                set
                {
                    if (value == true)
                    {
                        Notify();

                        sipariş = value;
                    }
                    else
                    {


                        sipariş = value;
                    }
                }
            }


            //Subject nesnesi kendisine abone olan gözlemcileri bu koleksiyonda tutacaktır.
            List<Observer> Gozlemciler;
            public Kurye()
            {
                this.Gozlemciler = new List<Observer>();
            }
            //Gözlemci ekle
            public void AboneEkle(Observer observer)
            {
                Gozlemciler.Add(observer);
            }
            //Gözlemci çıkar
            public void AboneCikar(Observer observer)
            {
                Gozlemciler.Remove(observer);
            }
            //Herhangi bir güncelleme olursa ilgili gözlemcilere haber verecek metodumuzdur.
            public void Notify()
            {
                Gozlemciler.ForEach(g =>
                {
                    g.Update();
                });
            }
        } 
        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Singleton marka1 = Singleton.NesneVer();
            Singleton marka2 = Singleton.NesneVer();
            if (marka1 == marka2)
            {
                textBox3.Text = ("EMRA");
                textBox4.Text = (" Kumpir & Waffle");
            }
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "d/M/yyyy";
        }


        private void button1_Click(object sender, EventArgs e)
        {


            if (checkBox1.Checked == true && checkBox2.Checked == true)
            {
                Mantar mantar = new Mantar(new Misir(new Kumpir()));
                label1.Text = mantar.aciklama();
                decimal ücret;
                ücret = mantar.ucret();
                label2.Text = ücret.ToString();
            }
            else
            {
                if (checkBox1.Checked == true)
                {
                    Misir mısır = new Misir(new Kumpir());
                    label1.Text = mısır.aciklama();
                    decimal ücret;
                    ücret = mısır.ucret();
                    label2.Text = ücret.ToString();

                }
                if (checkBox2.Checked == true)
                {
                    Mantar mantar = new Mantar(new Kumpir());
                    label1.Text = mantar.aciklama();
                    decimal ücret;
                    ücret = mantar.ucret();
                    label2.Text = ücret.ToString();
                }
            }
            if(checkBox1.Checked == false && checkBox2.Checked == false)
            {
                decimal ücret;
                ücret = 0.00m;
                label2.Text = ücret.ToString();
                
            }



            if (checkBox3.Checked == true && checkBox4.Checked == true)
            {
                Muz çm = new Muz(new Çilek(new Waffle()));
                label3.Text = çm.aciklama();
                decimal ücret;
                ücret = çm.ucret();
                label4.Text = ücret.ToString();
            }
            else
                {

                if (checkBox4.Checked == true)
                {
                    Muz muzlu = new Muz(new Waffle());
                    label3.Text = muzlu.aciklama();
                    decimal ücret;
                    ücret = muzlu.ucret();
                    label4.Text = ücret.ToString();
                }
                if (checkBox3.Checked == true)
                {
                    Çilek çilekli = new Çilek(new Waffle());
                    label3.Text = çilekli.aciklama();
                    decimal ücret;
                    ücret = çilekli.ucret();
                    label4.Text = ücret.ToString();

                }
            }
            if (checkBox3.Checked == false && checkBox4.Checked == false)
            {
                decimal ücret;
                ücret = 0.00m;
                label4.Text = ücret.ToString();

            }
            decimal b,a,c;
            b = Convert.ToDecimal(label2.Text.ToString());
            a = Convert.ToDecimal(label4.Text.ToString());
            c = a + b;
            label6.Text = c.ToString();
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Uretici sipariş;
            if(checkBox1.Checked==true || checkBox2.Checked == true)
            {
                sipariş = new Uretici(new Kumpir1());
                sipariş.Uret();
               
                
            }
            if (checkBox3.Checked == true || checkBox4.Checked == true)
            {
                sipariş = new Uretici(new Waffle1());
                sipariş.Uret();
            }

        }

        private void label5_Click(object sender, EventArgs e)
        {
            /*Creater create = new Creater(new YalovaSubesı());
            label5.Text = create.ToString();*/
            //label5.Text = comboBox1.SelectedIndex.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int b;
            b = Convert.ToInt32(comboBox1.SelectedIndex.ToString());

            if (b==0)
            {
                Creater create = new Creater(new YalovaSubesı());
                checkBox1.Visible = false;
                checkBox3.Visible = false;
                
            }
            if (b == 1)
            {
                Creater create = new Creater(new IstanbulŞubesi());
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("İŞLEMİNİZ BAŞARI İLE GERÇEKLEŞTİRİLDİ");
            Kurye k = new Kurye();
            k.AboneEkle(new KuryeObserver());
            k.SiparişVeridiMi = true;
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    } 
}
