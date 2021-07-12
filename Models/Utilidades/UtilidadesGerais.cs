using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilidades {
  internal class UtilidadesGerais {
    public string EncodePassword(string str) {
      // Define um array de bytes
      byte[] salt = new byte[128 / 8];
      // Define um array de bytes que receberá a codificação da função KeyDerivation.Pdkdf2
      byte[] codify = KeyDerivation.Pbkdf2(str, salt, KeyDerivationPrf.HMACSHA1, 10000, 256 / 8);
      //Define uma string para receber a conversão do array de byts codificado
      string hash = Convert.ToBase64String(codify);
      //Retorna o hash
      return hash;
    }

    public static string Capitalize(string str) {
      return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
    }

    public static string SlicingStringDate(string str) {
      if(!str.Equals("")) {
        try {
          string[] breakdate = str.Split("-");
          string yyyy = breakdate[0];
          string MM = breakdate[1];
          string dd = breakdate[2];
          str = String.Concat(yyyy, "/", MM, "/", dd);
        } catch(Exception) {
          str = "";
        }
      }
      return str;
    }

    // will generate a random value with 9 digits and concatenate with the current year converting to string
    public static string GenerateWorkOrder() {
      Random random = new Random();
      string workorder = random.Next(100000000, 999999999).ToString();
      return String.Concat(DateTime.Now.Year, workorder);
    }



  }
}
