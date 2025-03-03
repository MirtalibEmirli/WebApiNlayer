﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Common.Security;

public static class PasswordHasher
{

    public static string  ComputeStringToSha256Hash(string plainText)
    {
        using SHA256 sHA256Hash = SHA256.Create(); 
        byte[] bytes = sHA256Hash.ComputeHash(Encoding.UTF8.GetBytes(plainText));   
        StringBuilder sb = new ();
        for (int i = 0; i < bytes.Length; i++)
        {
            sb.Append(bytes[i].ToString("x2"));
        } 
        
        return sb.ToString();   
    }
}