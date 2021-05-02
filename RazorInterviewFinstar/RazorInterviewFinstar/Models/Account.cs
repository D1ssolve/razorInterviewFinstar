using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorInterviewFinstar.Models
{
    public class Account
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public Data data { get; set; }
        public string description { get; set; }
        public string requestId { get; set; }
        public int status { get; set; }

        public class Document
        {
            public string amazonS3_url { get; set; }
            public string id { get; set; }
            public string name { get; set; }
        }

        public class Schedule
        {
            public int is_completed { get; set; }
            public double monthly_pay { get; set; }
            public string pay_date { get; set; }
            public int period_number { get; set; }
        }

        public class Loan
        {
            public string application_id { get; set; }
            public string bank_account_holder { get; set; }
            public string bank_account_number { get; set; }
            public string bank_id { get; set; }
            public string bank_location { get; set; }
            public string bank_name { get; set; }
            public string branch_name { get; set; }
            public string closed_on { get; set; }
            public string contract_number { get; set; }
            public string created_date { get; set; }
            public string currency { get; set; }
            public List<Document> documents { get; set; }
            public string fx_loan_amount { get; set; }
            public string fx_loan_term { get; set; }
            public string fx_payment_amount { get; set; }
            public string fx_prolongation_amount { get; set; }
            public string fx_total_amount { get; set; }
            public string has_extention { get; set; }
            public string issue_date { get; set; }
            public string loan_disbursment_type { get; set; }
            public string payment_date { get; set; }
            public string prolongation_date { get; set; }
            public string restructured { get; set; }
            public List<Schedule> schedule { get; set; }
            public string source { get; set; }
            public string status { get; set; }
            public string type { get; set; }
            public string web_application_id { get; set; }
            public string write_off_date { get; set; }
            public int write_off_sum { get; set; }
            public string write_off_type { get; set; }
        }

        public class Product
        {
            public int document_required { get; set; }
            public double max_available_loan_amount { get; set; }
            public int product_code { get; set; }
        }

        public class Data
        {
            public string contact_id { get; set; }
            public string first_name { get; set; }
            public string hash_campaign { get; set; }
            public string hash_password { get; set; }
            public string last_name { get; set; }
            public List<Loan> loans { get; set; }
            public int max_available_loan_amount { get; set; }
            public string middle_name { get; set; }
            public string mobile { get; set; }
            public string personal_id { get; set; }
            public int product_code { get; set; }
            public List<Product> products { get; set; }
            public object scoring_through_zoral { get; set; }
        }
    }
}
