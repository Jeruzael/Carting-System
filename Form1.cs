using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dumale_CartingProgram
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();  
            
        }

        Cart cart1 = new Cart();
        Shoes shohy = new Shoes("Shohy",1700);
        Shoes polymad = new Shoes("Polymad",2500);
        bool key;
        
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CartPanel(object sender, EventArgs e)
        {
            CartMainPanel.Location = new System.Drawing.Point(4,73);
        }

        private void shonyMore_Click(object sender, EventArgs e)
        {
            HomePanel.Location = new System.Drawing.Point(500, 87);
            shohyMainPanel.Location = new System.Drawing.Point(47, 140);
            shohyCallToActions.Location = new System.Drawing.Point(338, 354);
        }

        private void Home_button(object sender, EventArgs e)
        {
            HomePanel.Location = new System.Drawing.Point(7, 87);
            shohyMainPanel.Location = new System.Drawing.Point(-500, 140);
            shohyCallToActions.Location = new System.Drawing.Point(338, 500);
            PolymadPanel.Location = new System.Drawing.Point(-500, 82);
            CartMainPanel.Location = new System.Drawing.Point(500,73);
            addToCartProcess.Location = new System.Drawing.Point(500,82);
            brandName.Text = "";
            Price.Text = "";
            quantityInput.Text = "";
        }

        private void polyMadMore_Click(object sender, EventArgs e)
        {
            HomePanel.Location = new System.Drawing.Point(500, 87);
            PolymadPanel.Location = new System.Drawing.Point(3, 82);

        }

        private void polyBack_Paint(object sender, EventArgs e)
        {
            HomePanel.Location = new System.Drawing.Point(7, 87);
            PolymadPanel.Location = new System.Drawing.Point(-500, 82);
        }

        private void shohyBack_Paint(object sender, EventArgs e)
        {
            HomePanel.Location = new System.Drawing.Point(7, 87);
            shohyMainPanel.Location = new System.Drawing.Point(-500, 140);
            shohyCallToActions.Location = new System.Drawing.Point(338, 500);
        }

        private void shohyAddtoCart_Paint(object sender, EventArgs e)
        {
            brandName.Text = shohy.getBrandName();
            Price.Text = shohy.getPrice().ToString();
            addToCartProcess.Location = new System.Drawing.Point(9, 82);
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        int iter=0;
        private void AddToCartFinal_Click(object sender, EventArgs e)
        {
            int quantityHold = Convert.ToInt32(quantityInput.Text);
            int q = quantityHold;
            string bn = brandName.Text;
            int p = Convert.ToInt32(Price.Text);
            //MessageBox.Show("Iter: "+iter);
            cart1.setOrder(iter++, p, q);
            listBox1.Items.Add("Brandname: "+bn+",   Price: "+p+",     Quantity: "+q+",     Total: "+p*q);

            MessageBox.Show("Added to cart");
            addToCartProcess.Location = new System.Drawing.Point(500,82);
            quantityInput.Text = "";
        }

        private void polyAddToCart_Paint(object sender, EventArgs e)
        {
            brandName.Text = polymad.getBrandName();
            Price.Text = polymad.getPrice().ToString();
            addToCartProcess.Location = new System.Drawing.Point(9, 82);
        }

        private void CheckOut_Click(object sender, EventArgs e)
        {
            total.Text = cart1.getOverAll().ToString();
        }

        private void transacFinisher_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(total.Text);
            int b = Convert.ToInt32(cash.Text);
            int c = b - a;

            if (key == true)
            {
                MessageBox.Show("All items purchased! Your change is "+c);
            }
            else
            {
                MessageBox.Show("Oooops out of credits!");
            }
        }

        private void cash_TextChanged(object sender, EventArgs e)
        {            
            int a = Convert.ToInt32(total.Text);
            int b = Convert.ToInt32(cash.Text);
            if(a > b)
            {
                key = false;
            }
            else
            {
                key = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Intro.Location = new System.Drawing.Point(500,500);
        }
    }

    public class Shoes
    {
        int price { set; get; }
        string brandName { set; get; }

        public Shoes(string b, int p)
        {
            brandName = b;
            price = p;
        }

        public string getBrandName()
        {
            return brandName;
        }

        public int getPrice()
        {
            return price;
        }
    }

    public class Cart
    {
        int[] order = new int[100];
        
        public Cart()
        {

        }

        public void setOrder(int i,int price, int quantity)
        {
            order[i] = price * quantity;
        }

        public int getOverAll()
        {
            int OA = 0;
            for(int i=0;i<100;i++)
            {
                OA += order[i];
            }

            return OA;
        }
    }
}
