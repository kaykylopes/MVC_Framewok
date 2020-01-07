using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class AlunoBLL
    {
        public IEnumerable<Aluno> getAlunos()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["conSqlServer"].ConnectionString;
            List<Aluno> alunos = new List<Aluno>();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                    {
                    SqlCommand cmd = new SqlCommand("GetAluno", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Aluno aluno = new Aluno();
                        aluno.Id = Convert.ToInt32(rdr["Id"]);
                        aluno.Nome = rdr["Nome"].ToString();
                        aluno.Email = rdr["Email"].ToString();
                        aluno.Idade = Convert.ToInt32(rdr["Idade"]);
                        aluno.DataInscricao = Convert.ToDateTime(rdr["DataInscricao"]);
                        aluno.Sexo = rdr["Sexo"].ToString();
                        alunos.Add(aluno);
                    }
                }
                return alunos;
            }
            catch 
            {
                throw;
            }
        }


        public void IncluirAluno (Aluno aluno)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["conSqlServer"].ConnectionString;
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString)) 
                {
                    SqlCommand cmd = new SqlCommand("IncluirAluno", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter paraNome = new SqlParameter();
                    paraNome.ParameterName = "@Nome";
                    paraNome.Value = aluno.Nome;
                    cmd.Parameters.Add(paraNome);

                    SqlParameter paraEmail = new SqlParameter();
                    paraEmail.ParameterName = "@Email";
                    paraEmail.Value = aluno.Email;
                    cmd.Parameters.Add(paraEmail);

                    SqlParameter paraIdade= new SqlParameter();
                    paraIdade.ParameterName = "@Idade";
                    paraIdade.Value = aluno.Idade;
                    cmd.Parameters.Add(paraIdade);

                    SqlParameter paraDataInscricao = new SqlParameter();
                    paraDataInscricao.ParameterName = "@DataInscricao";
                    paraDataInscricao.Value = aluno.DataInscricao;
                    cmd.Parameters.Add(paraDataInscricao);

                    SqlParameter paraSexo = new SqlParameter();
                    paraSexo.ParameterName = "@Sexo";
                    paraSexo.Value = aluno.Sexo;
                    cmd.Parameters.Add(paraSexo);


                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void AtualizarAluno(Aluno aluno)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["conSqlServer"].ConnectionString;
            using (SqlConnection con = new  SqlConnection(connectionString))
                try
                {
                    SqlCommand cmd = new SqlCommand("AtualizarAluno", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter paraId = new SqlParameter();
                    paraId.ParameterName = "@Id";
                    paraId.Value = aluno.Id;
                    cmd.Parameters.Add(paraId);


                    SqlParameter paraNome = new SqlParameter();
                    paraNome.ParameterName = "@Nome";
                    paraNome.Value = aluno.Nome;
                    cmd.Parameters.Add(paraNome);

                    SqlParameter paraEmail = new SqlParameter();
                    paraEmail.ParameterName = "@Email";
                    paraEmail.Value = aluno.Email;
                    cmd.Parameters.Add(paraEmail);

                    SqlParameter paraIdade = new SqlParameter();
                    paraIdade.ParameterName = "@Idade";
                    paraIdade.Value = aluno.Idade;
                    cmd.Parameters.Add(paraIdade);

                    SqlParameter paraDataInscricao = new SqlParameter();
                    paraDataInscricao.ParameterName = "@DataInscricao";
                    paraDataInscricao.Value = aluno.DataInscricao;
                    cmd.Parameters.Add(paraDataInscricao);

                    SqlParameter paraSexo = new SqlParameter();
                    paraSexo.ParameterName = "@Sexo";
                    paraSexo.Value = aluno.Sexo;
                    cmd.Parameters.Add(paraSexo);


                    con.Open();

                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {

                    throw;
                }
        }
    }
}
