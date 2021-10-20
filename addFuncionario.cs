using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Temakeria
{
    public partial class addfuncionario : Form
    {
        public addfuncionario()
        {
            InitializeComponent();
            txt_nome.Enabled = true;
            txt_telefone.Enabled = true;
            txt_cpf.Enabled = true;
            txt_email.Enabled = true;
            txt_endereco.Enabled = true;
            txt_numero.Enabled = true;
            txt_bairro.Enabled = true;
            txt_rg.Enabled = true;
            txt_celular.Enabled = true;
            txt_pesquisa.Enabled = true;

        }

        SqlConnection sqlCon = null;
        private string strCon = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=testes;Data Source=IB-EL-00180\\SQLEXPRESS";
        private string strSql = string.Empty;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            strSql = "insert into temakeria (nome, telefone, celular, email, endereco, numero, bairro, rg, cpf) values (@nome, @telefone, @celular, @email, @endereco, @numero, @bairro, @rg, @cpf)";

            sqlCon = new SqlConnection(strCon);
            SqlCommand comando = new SqlCommand(strSql, sqlCon);

            comando.Parameters.Add("@nome", SqlDbType.VarChar).Value = txt_nome.Text;
            comando.Parameters.Add("@telefone", SqlDbType.VarChar).Value = txt_telefone.Text;
            comando.Parameters.Add("@celular", SqlDbType.VarChar).Value = txt_celular.Text;
            comando.Parameters.Add("@email", SqlDbType.VarChar).Value = txt_email.Text;
            comando.Parameters.Add("@endereco", SqlDbType.VarChar).Value = txt_endereco.Text;
            comando.Parameters.Add("@numero", SqlDbType.VarChar).Value = txt_numero.Text;
            comando.Parameters.Add("@bairro", SqlDbType.VarChar).Value = txt_bairro.Text;
            comando.Parameters.Add("@rg", SqlDbType.VarChar).Value = txt_rg.Text;
            comando.Parameters.Add("@cpf", SqlDbType.VarChar).Value = txt_cpf.Text;

            try
            {
                sqlCon.Open();
                comando.ExecuteNonQuery();

                MessageBox.Show("Cadastro efetuado com sucesso");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                sqlCon.Close();
            }

            txt_pesquisa.Enabled = true;

            txt_nome.Clear();
            txt_telefone.Clear();
            txt_email.Clear();
            txt_endereco.Clear();
            txt_numero.Clear();
            txt_bairro.Clear();
            txt_rg.Clear();
            txt_cpf.Clear();
            txt_celular.Clear();

        }

        private void btn_adicionar_Click(object sender, EventArgs e)
        {
            InitializeComponent();

            txt_pesquisa.Enabled = false;
            txt_nome.Enabled = true;
            txt_telefone.Enabled = true;
            txt_cpf.Enabled = true;
            txt_email.Enabled = true;
            txt_endereco.Enabled = true;
            txt_numero.Enabled = true;
            txt_bairro.Enabled = true;
            txt_rg.Enabled = true;
            txt_celular.Enabled = true;
            
        }

        private void txt_celular_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            strSql = "select*from temakeria where nome=@pesquisa";
            
            sqlCon = new SqlConnection(strCon);
            SqlCommand comando = new SqlCommand(strSql, sqlCon);

            comando.Parameters.Add("@pesquisa", SqlDbType.VarChar).Value = txt_pesquisa.Text;

            try
            {
                if(txt_pesquisa.Text == string.Empty)
                {
                    MessageBox.Show("Você não digitou um nome");
                }
                sqlCon.Open();
                SqlDataReader dr = comando.ExecuteReader();

                if(dr.HasRows == false)
                {
                    throw new Exception("Este nome não está cadastrado");
                }
                dr.Read();

                txt_nome.Text = Convert.ToString(dr["nome"]);
                txt_cpf.Text = Convert.ToString(dr["cpf"]);
                txt_rg.Text = Convert.ToString(dr["rg"]);
                txt_endereco.Text = Convert.ToString(dr["endereco"]);
                txt_bairro.Text = Convert.ToString(dr["bairro"]);
                txt_telefone.Text = Convert.ToString(dr["telefone"]);
                txt_celular.Text = Convert.ToString(dr["celular"]);
                txt_numero.Text = Convert.ToString(dr["numero"]);
                txt_email.Text = Convert.ToString(dr["email"]);
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }
            txt_pesquisa.Clear();

        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            strSql = "update temakeria set nome=@nome, telefone=@telefone, celular=@celular, email=@email, endereco=@endereco, numero=@numero, bairro=@bairro, rg=@rg, cpf=@cpf";

            sqlCon = new SqlConnection(strCon);
            SqlCommand comando = new SqlCommand(strSql, sqlCon);

            comando.Parameters.Add("@nome", SqlDbType.VarChar).Value = txt_nome.Text;
            comando.Parameters.Add("@telefone", SqlDbType.VarChar).Value = txt_telefone.Text;
            comando.Parameters.Add("@celular", SqlDbType.VarChar).Value = txt_celular.Text;
            comando.Parameters.Add("@email", SqlDbType.VarChar).Value = txt_email.Text;
            comando.Parameters.Add("@endereco", SqlDbType.VarChar).Value = txt_endereco.Text;
            comando.Parameters.Add("@numero", SqlDbType.VarChar).Value = txt_numero.Text;
            comando.Parameters.Add("@bairro", SqlDbType.VarChar).Value = txt_bairro.Text;
            comando.Parameters.Add("@rg", SqlDbType.VarChar).Value = txt_rg.Text;
            comando.Parameters.Add("@cpf", SqlDbType.VarChar).Value = txt_cpf.Text;

            try
            {
                sqlCon.Open();
                comando.ExecuteNonQuery();

                MessageBox.Show("Cadastro alterado com sucesso");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }

            txt_nome.Clear();
            txt_telefone.Clear();
            txt_email.Clear();
            txt_endereco.Clear();
            txt_numero.Clear();
            txt_bairro.Clear();
            txt_rg.Clear();
            txt_cpf.Clear();
            txt_celular.Clear();
        }

        private void btn_apagar_Click(object sender, EventArgs e)
        {
            strSql = "delete from temakeria where nome=@nome";

            sqlCon = new SqlConnection(strCon);
            SqlCommand comando = new SqlCommand(strSql, sqlCon);

            comando.Parameters.Add("@nome", SqlDbType.VarChar).Value = txt_nome.Text;
            

            try
            {
                sqlCon.Open();
                comando.ExecuteNonQuery();

                MessageBox.Show("Cadastro removido com sucesso");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }

            txt_nome.Clear();
            
        }
    }
}
