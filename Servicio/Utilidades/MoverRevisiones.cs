using System;
using System.Collections.Generic;
using Model;
using Data;
using System.IO;

namespace Servicios.Utilidades
{
    public class MoverRevisiones
    {
        public List<(int, string)> pastas;
        public RepositorioCarpetas repPasta;
        public MoverRevisiones()
        {
            pastas = new List<(int, string)>();
            repPasta = new RepositorioCarpetas();
        }
        public void TrasladarAntiguas(Oferta Oferta, bool moverOferta)
        {
            if (!(Oferta.Rev != 0 || !String.IsNullOrEmpty(Oferta.Rev.ToString())))
            {
                return;
            }

            for (int i = 0; i < 10; i++)
            {
                if (i == Convert.ToInt64(Oferta.Rev)) { continue; };

                (int, string)[] pastasATraer =  { (Oferta.IdBU, "comercial"), (Oferta.IdBU, "comercialOferta"), (Oferta.IdBU, "comercialPricing") };
                pastas.AddRange(pastasATraer);
                List<string> rutaPastas = repPasta.GetPathsAsync(pastas).Result;

                string rutaCarpeta = rutaPastas[0];
                string rutaOferta = rutaPastas[1];
                string ofertaWD = rutaOferta + "-R" + (i).ToString() + ".docx";
                string ofertaPDF = rutaOferta + "-R" + (i).ToString() + ".pdf";
                string rutaPricing = rutaPastas[2];
                string pricingXL = rutaPricing + "-R" + (i).ToString() + ".xlsm";
                string pricingPDF = rutaPricing + "-R" + (i).ToString() + ".pdf";

                if (moverOferta)
                {
                    if (File.Exists(ofertaWD))
                    {
                        if (Oferta.IdBU == (int)BUEnum.HCHL || Oferta.IdBU == (int)BUEnum.HPU)
                        {
                            File.Move(ofertaWD, $"{rutaCarpeta}\\PROPUESTA\\00 Revisiones Anteriores\\P_ {Oferta.NCRM}-R{i}.docx");
                        }
                        else if (Oferta.IdBU == (int)BUEnum.HSA)
                        {
                            File.Move(ofertaWD, $"{rutaCarpeta}\\PROPOSTA\\0_Revisões_Anteriores\\P_{Oferta.NCRM}-R{i}.docx");
                        }
                    }
                    if (File.Exists(ofertaPDF))
                    {
                        if (Oferta.IdBU == (int)BUEnum.HCHL || Oferta.IdBU == (int)BUEnum.HPU)
                        {
                            File.Move(ofertaPDF, $"{rutaCarpeta}\\PROPUESTA\\00 Revisiones Anteriores\\P_ {Oferta.NCRM}-R{i}.pdf");
                        }
                        else if (Oferta.IdBU == (int)BUEnum.HSA)
                        {
                            File.Move(ofertaPDF, $"{rutaCarpeta}\\PROPOSTA\\0_Revisões_Anteriores\\P_{Oferta.NCRM}-R{i}.pdf");
                        }
                    }

                    else
                    {
                        if (File.Exists(pricingXL))
                        {
                            if (Oferta.IdBU == (int)BUEnum.HCHL || Oferta.IdBU == (int)BUEnum.HPU)
                            {
                                File.Move(pricingXL, $"{rutaCarpeta}\\COSTO_&_PRICING\\00 Revisiones Anteriores\\R_{Oferta.NCRM}-R{i}.xlsm");
                            }
                            else if (Oferta.IdBU == (int)BUEnum.HSA)
                            {
                                File.Move(pricingXL, $"{rutaCarpeta}\\CUSTO_&_PRICING\\0_Revisões_Anteriores\\R_{Oferta.NCRM}-R{i}.xlsm");
                            }
                        }
                        if (File.Exists(pricingPDF))
                        {
                            if (Oferta.IdBU == (int)BUEnum.HCHL || Oferta.IdBU == (int)BUEnum.HPU)
                            {
                                File.Move(pricingPDF, $"{rutaCarpeta}\\COSTO_&_PRICING\\00 Revisiones Anteriores\\R_{Oferta.NCRM}-R{i}.pdf");
                            }
                            else if (Oferta.IdBU == (int)BUEnum.HSA)
                            {
                                File.Move(pricingPDF, $"{rutaCarpeta}\\CUSTO_&_PRICING\\0_Revisões_Anteriores\\R_{Oferta.NCRM}-R{i}.pdf");
                            }
                        }
                    }
                }
            }
        }        
    }
}
