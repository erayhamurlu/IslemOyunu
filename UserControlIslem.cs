using System;
using System.Windows.Forms;

namespace _1kelime1islemtemiz01
{
    public partial class UserControlIslem : UserControl
    {
        public UserControlIslem()
        {
            InitializeComponent();
        }

        static int[] rndmSayilar = new int[7]; // Random sayıları tutacak dizi
        static int uchaneli = 0;               // Uc haneli hedef sayıyı tutacak değişken
        static int enyakin = 0;                // En yakin sonucu tutacak değişken
        static Random random = new Random();   // Random nesnemiz

        //
        // Random Sayilari uretecek buton
        //
        private void buttonSayiUret_Click(object sender, EventArgs e)
        {
            rndmSayiUret();  // Random sayi ureten fonksiyon      
        }
        //
        // Hesapla Butonu random sayilari hesaplar
        // 
        private void hesapla_rndm_Click(object sender, EventArgs e)
        {  
            hesapla(label2); // Random sayileri hesaplayacak fonksiyon Hangi labela yazdiracak bilgisinide gönderiyoruz 
        }
        //
        // Kullanıcın girdiği sayilari hesaplayacak fonksiyon
        //
        private void hesapla_user_Click(object sender, EventArgs e)
        {
            // Textboxa kullanıcının girdiği sayıları alıyoruz 
            rndmSayilar[0] = Convert.ToInt32(textBox1.Text);
            rndmSayilar[1] = Convert.ToInt32(textBox2.Text);
            rndmSayilar[2] = Convert.ToInt32(textBox3.Text);
            rndmSayilar[3] = Convert.ToInt32(textBox4.Text);
            rndmSayilar[4] = Convert.ToInt32(textBox5.Text);
            rndmSayilar[5] = Convert.ToInt32(textBox6.Text);
            rndmSayilar[6] = Convert.ToInt32(textBox7.Text);
            uchaneli = rndmSayilar[6];
            hesapla(label7); // Kullanıcının girdigi sayilari hesaplayacak fonksiyon Hangi labela yazdiracak bilgisinide gönderiyoruz
        }
        //
        // Sayfa ilk yüklendiğinde çalışacak metot
        //
        private void UserControlIslem_Load(object sender, EventArgs e)
        {
            hesapla_user.Enabled = false; // Kullanıcı tarafından girilecek sayıları hesaplayan butonun durumu
            labelBilgi.Text = "Bilgi: ilk 5 kutuya 1-9 arasında rakam giriniz.\n"
                              + "6.kutuya iki basamaklı 10'un katı olan sayı giriniz\n"
                              + "Son kutuya 100-999 arasında bir sayı giriniz\n"
                              + "(Tüm sayilar pozitif olmalıdır.)";//Bilgilendirme Metni
        }
        //
        // Son textboxi kontrol edecek fonksiyon
        //
        private void textBox7_TextChanged(object sender, EventArgs e)
        {
                if (textBox7 != null) // Buton boş değilse hesapla butonunu enable edecek
                {
                    hesapla_user.Enabled = true;
                }
        }
        //
        // Random sayi uretecek fonksiyon
        //
        private void rndmSayiUret()
        {
            for (int i = 0; i < 6; i++)
            {
                rndmSayilar[i] = random.Next(1, 10); // Ilk 5 sayıya random rakam ataması
            }
            rndmSayilar[5] *= 10; // 6. sayıyı 10 katı haline gelmesi
            rndmSayilar[6] = random.Next(100, 1000); // uchaneli sayi ataması
            uchaneli = rndmSayilar[6];
            // Random sayıların yazdırılması
            label1.Text = rndmSayilar[0] + " " + rndmSayilar[1] + " " + rndmSayilar[2] + " " + rndmSayilar[3] + " "
                + rndmSayilar[4] + " " + rndmSayilar[5] + " " + rndmSayilar[6];
        }
        //
        // Hesaplama İşlemlerinden Sorumlu Buton
        //
        private void hesapla(Label label)
        {
            int sinir = 0; // Program sonsuz döngüye girmesin diye sınır
            while (true)
            {
                sinir++;

                int rkmdegistir = random.Next(6); // Her denemede rakamların yerlerini değiştirir
                int temp = rndmSayilar[rkmdegistir];
                rndmSayilar[rkmdegistir] = rndmSayilar[0];
                rndmSayilar[0] = temp;

                int ilksayi = rndmSayilar[0];

                string cozum = rndmSayilar[0].ToString(); // Cozumun labela yazdırılması

                int kullanilacaksayiadedi = random.Next(3, 6); // Random kullanılacak sayı adedini belirler

                for (int i = 1; i < kullanilacaksayiadedi; i++)
                {
                    int islem = random.Next(4); // Random işlem seçimi
                    switch (islem)
                    {
                        case 0:
                            ilksayi += rndmSayilar[i];
                            cozum = "(" + cozum + " + " + rndmSayilar[i].ToString() + ")";
                            break;
                        case 1:
                            ilksayi -= rndmSayilar[i];
                            cozum = "(" + cozum + " - " + rndmSayilar[i].ToString() + ")";
                            break;
                        case 2:
                            ilksayi *= rndmSayilar[i];
                            cozum = "(" + cozum + " * " + rndmSayilar[i].ToString() + ")";
                            break;
                        case 3:
                            if (ilksayi % rndmSayilar[i] != 0) continue;
                            ilksayi /= rndmSayilar[i];
                            cozum = "(" + cozum + " / " + rndmSayilar[i].ToString() + ")";
                            break;
                    }
                }
                cozum += " = " + ilksayi.ToString();

                if (Math.Abs(uchaneli - ilksayi) < Math.Abs(uchaneli - enyakin)) // En yakın sonuç kontrolu
                {
                    enyakin = ilksayi;
                    label.Text = cozum;
                }

                if (ilksayi == uchaneli || ilksayi - 9 == uchaneli || ilksayi + 9 == uchaneli) // Sonuc kontrolu
                {
                    break;
                }

                if (sinir > 150000) break; // Program sonsuz döngüye girmesin diye sınır kontrolu
                else continue;
            }
        }
        //
        // TextBoxlara tıklandığında numaraların kaybolması için yazdığım bölüm(placeholder)
        //
        private void EnterTextBox1(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                textBox1.Text = ""; // TextBox1 için
            }
        }
        private void EnterTextBox2(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                textBox2.Text = ""; // TextBox2 için
            }
        }
        private void EnterTextBox3(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                textBox3.Text = ""; // TextBox3 için
            }
        }
        private void EnterTextBox4(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
            {
                textBox4.Text = ""; // TextBox4 için
            }
        }
        private void EnterTextBox5(object sender, EventArgs e)
        {
            if (textBox5.Text != "")
            {
                textBox5.Text = ""; // TextBox5 için
            }
        }
        private void EnterTextBox6(object sender, EventArgs e)
        {
            if (textBox6.Text != "")
            {
                textBox6.Text = ""; // TextBox6 için
            }
        }
        private void EnterTextBox7(object sender, EventArgs e)
        {
            if (textBox7.Text != "")
            {
                textBox7.Text = ""; // TextBox7 için
            }
        }
    }
}
