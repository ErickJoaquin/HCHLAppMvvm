using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    class RepositorioXOtros
    {
        #region Eliminar? RepositorioOfertas

        ///// BBDD
        ///// Columnas
        //string[] tbosp = {
        //    "idbu", "ncrm", "rev", "estado", "idcliente", "idvendor", "idrep1", "idrep2", "curr", "costototal", "ventatotal", "gm", "entrega", "pago", "validez", "plazo", "idcontacto", "idkam", "idka",
        //    "idaplicador", "refcliente", "modelo", "nserie", "idproveedor", "producto", "mercado", "direccionentrega", "mup", "packaging", "packagingv", "descuento", "mn",  "radicional", "fin", "ing",
        //    "bfielcumplimiento", "badelanto", "bcalidadygarantia", "monedacons", "cambiocons", "fechacons", "idvendedor1", "idvendedor2", "idvendedor3", "detallesoferta", "fechaoc", "oc", "fechaentrega",
        //    "npv", "eur", "gbp", "clp", "brl", "sol", "transporte", "transportev", "aduana", "aduanav", "calculogm", "edicion"
        //};

        //string[] valores;


        //// <summary>
        ///// Querys para informacion de OfertasFull
        ///// </summary>
        ///// <returns>DataTable Clientes&Vendors</returns>
        //public static DataTable tablaFull(Oferta Oferta, int? RevBase)
        //{
        //    string textSQL = "Select " +
        //       //General Oferta
        //       "tbosp.id, ncrm, rev, tbosp.curr, refcliente, detallesoferta, tbosp.idbu, busor.id AS IdBU, tbosp.estado, tbosp.calculogm, tbosp.idioma, " +
        //       "busor.acron as AcronBU, busor.nombre AS BU, busor.pais as PaisBU, buprov.ciudad as CiudadBU, tbosp.edicion as FechaEdicion, " +
        //       //Clientes
        //       "tbosp.idcliente, tbosp.idvendor, tbosp.idrep1, tbosp.idrep2, tbosp.idcontacto, " +
        //       "oeu.planta AS clienteplanta, oeu.cliente AS cliente, oeu.pais AS clientepais, ovendor.cliente AS vendor, ovendor.pais AS vendorpais, ovendor.tipo AS vendortipo, " +
        //       "orep1.cliente AS rep1, orep1.pais AS rep1pais, orep1.comision AS rep1comision, orep2.cliente AS rep2, orep2.pais AS rep2pais, orep2.comision AS rep2comision, " +
        //       "mercado, segmentos.id AS idmercado, segmentos.market as mercado, segmentos.industry AS industria, segmentos.subindustry as subindutria, segmentos.reference as refmercado,  " +
        //       "contacto.nombre AS nombrecontacto, contacto.apellido as apellidocontacto, " +
        //       //Proveedor
        //       "tbosp.idproveedor, tbosp.descuento, idproveedor, buprov.acron as acronprov, buprov.nombre AS nombreprov, buprov.pais as paisprov, buprov.ciudad as ciudadprov, " +
        //       //Equipos
        //       "modelo, nserie, tbosp.producto, equiposcrm.idequipocrm AS idequipocrm, equiposcrm.tipoequipo AS tipoequipo, equiposcrm.producto AS productocrm, " +
        //       //Condiciones
        //       "tbosp.entrega, tbosp.pago, validez, tbosp.plazo, direccionentrega, infoentrega.descripcion AS tipoentrega, infopago.descripcion AS tipopago, infomoneda.descripcion AS moneda, " +
        //       "infopago.pago1, infopago.pago2, infopago.pago3, infopago.plazo1, infopago.plazo2, infopago.plazo3, infopago.hito1, infopago.hito2, infopago.hito3,  " +
        //       //Valores
        //       "costototal, ventatotal, tbosp.gm, tbosp.mup, tbosp.packaging, tbosp.packagingv, tbosp.mn, tbosp.radicional, tbosp.ing, tbosp.fin, " +
        //       "eur, gbp, clp, brl, sol, tbosp.bfielcumplimiento AS fielcumplimiento, tbosp.badelanto AS adelanto, tbosp.bcalidadygarantia AS garantia, " +
        //       "tbosp.transporte, tbosp.transportev, tbosp.aduana, tbosp.aduanav, " +
        //       //Usuarios
        //       "tbosp.idkam, tbosp.idka, tbosp.idvendedor1, tbosp.idaplicador, aplicadores.apellidos AS apellidoaplicador, aplicadores.nombre AS nombreaplicador, aplicadores.idusuario AS idaplicador, " +
        //       "kas.apellidos AS apellidoska, kas.nombre AS nombreka, kas.mail AS mailka, vendedores.apellidos AS apellidosvendedor, vendedores.nombre AS nombrevendedor, " +
        //       "kams.apellidos AS apellidoskam, kams.nombre AS nombrekam,  kams.mail AS mailkam, " +
        //       //Venta
        //       "fechaoc, fechaemisionoc, fechaentrega, oc, npv " +

        //       "From tbosp " +
        //       "LEFT JOIN tbeu AS oeu ON oeu.id = tbosp.idcliente " +
        //       "LEFT JOIN tbvendor AS ovendor ON ovendor.id = tbosp.idvendor " +
        //       "LEFT JOIN tbvendor AS orep1 ON orep1.id = tbosp.idrep1 " +
        //       "LEFT JOIN tbvendor AS orep2 ON orep2.id = tbosp.idrep2 " +
        //       "LEFT JOIN tbinformaciones AS infoentrega ON infoentrega.id = tbosp.entrega " +
        //       "LEFT JOIN tbpagos AS infopago ON infopago.id = tbosp.pago " +
        //       "LEFT JOIN tbinformaciones AS infomoneda ON infomoneda.id = tbosp.curr " +
        //       "LEFT JOIN tbequiposcrm AS equiposcrm ON equiposcrm.id = tbosp.producto " +
        //       "LEFT JOIN tbsegmentos AS segmentos ON segmentos.id = tbosp.mercado " +
        //       "LEFT JOIN tbusuarios AS aplicadores ON aplicadores.id = tbosp.idaplicador " +
        //       "LEFT JOIN tbusuarios AS kams ON kams.id = tbosp.idkam " +
        //       "LEFT JOIN tbusuarios AS kas ON kas.id = tbosp.idka " +
        //       "LEFT JOIN tbusuarios AS vendedores ON vendedores.id = tbosp.idvendedor1 " +
        //       "LEFT JOIN tbcctscliente AS contacto ON contacto.id = tbosp.idcontacto " +
        //       "LEFT JOIN tbbu AS buprov ON buprov.id = tbosp.idproveedor " +
        //       "LEFT JOIN tbbu AS busor ON busor.id = tbosp.idbu " +
        //       "WHERE 1 = 1 ";

        //    if (Oferta != null && RevBase != null) { textSQL += "AND ncrm = '" + Oferta.NCRM + "' AND rev = " + RevBase; }

        //    DataTable dtOfertas = RepositorioBase.EjecutarSQL(textSQL);

        //    return dtOfertas;
        //}

        ///// <summary>
        ///// Querys para informacion de Ofertas (menos info que el full, este es para la tabla de BBDD)
        ///// </summary>
        ///// <returns>DataTable Clientes&Vendors</returns>
        //public static DataTable tablaMini()
        //{
        //    string textSQL = "Select tbosp.id as Id, busor.acron as AcronBU, ncrm AS NCRM, rev as Rev, oeu.planta AS ClientePlanta, oeu.cliente AS Cliente, " +
        //       "validez as Validez, tbosp.plazo as Plazo, tbosp.estado as EstadoOferta, refcliente as RefCliente, detallesoferta as Detalles, direccionentrega as DirEntrega, ovendor.cliente AS Vendor, " +
        //       "infoentrega.descripcion AS TipEentrega, infopago.descripcion AS TipoPago, infomoneda.descripcion AS Moneda, costototal as CostoTotal, ventatotal as VentaTotal, " +
        //       "aplicadores.apellidos AS ApellidoAplicador, aplicadores.nombre AS NombreAplicador, kams.apellidos AS ApellidosKAM, kams.nombre AS NombreKAM, " +
        //       "kas.apellidos AS ApellidosKA, kas.nombre AS NombreKA, vendedores.apellidos AS ApellidosVendedor, vendedores.nombre AS NombreVendedor, " +
        //       "equiposcrm.tipoequipo AS TipoEquipo, infopago.pago1 as Pago1, infopago.pago2 as Pago2, infopago.pago3 as Pago3, infopago.plazo1 as Plazo1, infopago.plazo2 as Plazo2, " +
        //       "infopago.plazo3 as Plazo3, infopago.hito1 as Hito1, infopago.hito2 as Hito2, infopago.hito3 as Hito3, eur as EUR, gbp as GBP, clp as CLP, brl as BRL, sol as PEN, " +
        //       "tbosp.mn as MN, tbosp.radicional as RAdd, tbosp.bfielcumplimiento AS BFielCumplimiento, tbosp.badelanto AS BAdelanto, tbosp.bcalidadygarantia AS BGarantia " +
        //       "From tbosp " +
        //       "LEFT JOIN tbeu AS oeu ON oeu.id = tbosp.idcliente " +
        //       "LEFT JOIN tbvendor AS ovendor ON ovendor.id = tbosp.idvendor " +
        //       "LEFT JOIN tbvendor AS ovendor ON ovendor.id = tbosp.idrep1 " +
        //       "LEFT JOIN tbvendor AS ovendor ON ovendor.id = tbosp.idrep2 " +
        //       "LEFT JOIN tbinformaciones AS infoentrega ON infoentrega.id = tbosp.entrega " +
        //       "LEFT JOIN tbpagos AS infopago ON infopago.id = tbosp.pago " +
        //       "LEFT JOIN tbinformaciones AS infomoneda ON infomoneda.id = tbosp.curr " +
        //       "LEFT JOIN tbequiposcrm AS equiposcrm ON equiposcrm.id = tbosp.producto " +
        //       "LEFT JOIN tbsegmentos AS segmentos ON segmentos.id = tbosp.mercado " +
        //       "LEFT JOIN tbusuarios AS aplicadores ON aplicadores.id = tbosp.idaplicador " +
        //       "LEFT JOIN tbusuarios AS kams ON kams.id = tbosp.idkam " +
        //       "LEFT JOIN tbusuarios AS kas ON kas.id = tbosp.idka " +
        //       "LEFT JOIN tbusuarios AS vendedores ON vendedores.id = tbosp.idvendedor1 " +
        //       "LEFT JOIN tbcctscliente AS contacto ON contacto.id = tbosp.idcontacto " +
        //       "LEFT JOIN tbbu AS buprov ON buprov.id = tbosp.idproveedor " +
        //       "LEFT JOIN tbbu AS busor ON busor.id = tbosp.idbu ";
        //    //"WHERE tbosp.estado = 'Activa' "; /// +  "LEFT JOIN tboequipos AS oequipo ON oequipo.idofertasp = tbosp.id LEFT JOIN tbequipos AS equipos ON equipos.id = oequipo.idequipo LEFT JOIN tbequiposcrm AS equiposcrm ON equiposcrm.id = equipos.idcrm "

        //    DataTable dtOfertas = RepositorioBase.EjecutarSQL(textSQL);

        //    return dtOfertas;
        //}

        ///// <summary>
        ///// Transforma DataTable OfertasFull en ListaOfertas<Oferta>
        ///// </summary>
        ///// <returns>ListaOfertas<Oferta></returns>
        //public static List<Oferta> listaOfertas(Oferta Oferta, int? RevBase)
        //{
        //    DataTable dtOfertas = tablaFull(Oferta, RevBase);

        //    List<Oferta> ListaOfertas = new List<Oferta>();

        //    foreach (DataRow dr in dtOfertas.Rows)
        //    {
        //        Oferta oferta = new Oferta();

        //        // General
        //        oferta.Id = Convert.ToInt32(dr["id"].ToString());
        //        if (dr["IdBU"] != DBNull.Value) { oferta.BU = Convert.ToInt32(dr["IdBU"]); }
        //        oferta.AcronBU = dr["AcronBU"].ToString();
        //        oferta.NCRM = dr["ncrm"].ToString();
        //        oferta.Rev = Convert.ToInt32(dr["rev"]);
        //        if (dr["curr"] != DBNull.Value) { oferta.CurrId = Convert.ToInt32(dr["curr"]); }
        //        oferta.Curr = dr["moneda"].ToString();
        //        if (dr["idaplicador"] != DBNull.Value) { oferta.IdAplicador = Convert.ToInt32(dr["idaplicador"]); }
        //        oferta.NombreAplicador = dr["nombreaplicador"].ToString();
        //        oferta.ApellidoAplicador = dr["apellidoaplicador"].ToString();
        //        oferta.NombreCompletoAplicador = dr["nombreaplicador"].ToString() + " " + dr["apellidoaplicador"].ToString();
        //        if (dr["idkam"] != DBNull.Value) { oferta.IdKAM = Convert.ToInt32(dr["idkam"]); }
        //        oferta.KAM = dr["nombrekam"].ToString() + " " + dr["apellidoskam"].ToString();
        //        oferta.MailKAM = dr["mailkam"].ToString();
        //        if (dr["idka"] != DBNull.Value) { oferta.IdKA = Convert.ToInt32(dr["idka"]); }
        //        oferta.KA = dr["nombreka"].ToString() + " " + dr["apellidoska"].ToString();
        //        oferta.MailKA = dr["mailka"].ToString();
        //        oferta.Vendedor1 = dr["nombrevendedor"].ToString() + " " + dr["apellidosvendedor"].ToString();
        //        if (dr["idmercado"] != DBNull.Value) { oferta.SubIndustria = Convert.ToInt32(dr["idmercado"]); }
        //        if (dr["refmercado"] != DBNull.Value) { oferta.ClienteRefIndustria = dr["refmercado"].ToString(); }
        //        oferta.Estado = dr["estado"].ToString();
        //        oferta.Idioma = dr["idioma"].ToString();
        //        oferta.FechaEdicion = Convert.ToDateTime(dr["FechaEdicion"]);

        //        // Clientes
        //        if (dr["idcliente"] != DBNull.Value) { oferta.IdCliente = Convert.ToInt32(dr["idcliente"]); }
        //        else if (dr["idvendor"] != DBNull.Value) { oferta.IdVendor = Convert.ToInt32(dr["idvendor"]); }
        //        if (!String.IsNullOrEmpty(dr["clienteplanta"].ToString())) { oferta.Cliente = dr["cliente"].ToString() + " - " + dr["clienteplanta"].ToString(); }
        //        else if (!String.IsNullOrEmpty(dr["cliente"].ToString())) { oferta.Cliente = dr["cliente"].ToString(); } else { oferta.Cliente = dr["vendor"].ToString(); }
        //        oferta.ClientePais = dr["clientepais"].ToString();
        //        oferta.ClienteProceso = dr["refmercado"].ToString();
        //        if (dr["idvendor"] != DBNull.Value) { oferta.IdVendor = Convert.ToInt32(dr["idvendor"]); }
        //        oferta.Vendor = dr["vendor"].ToString();
        //        oferta.VendorPais = dr["vendorpais"].ToString();
        //        oferta.VendorTipo = dr["vendortipo"].ToString();
        //        if (dr["idcontacto"] != DBNull.Value) { oferta.IdContacto = Convert.ToInt32(dr["idcontacto"]); }
        //        oferta.Contacto = dr["nombrecontacto"].ToString() + " " + dr["apellidocontacto"].ToString();
        //        if (dr["idrep1"] != DBNull.Value) { oferta.IdRep1 = Convert.ToInt32(dr["idrep1"]); }
        //        oferta.Rep1 = dr["rep1"].ToString();
        //        oferta.Rep1Pais = dr["rep1pais"].ToString();
        //        if (dr["rep1comision"] != DBNull.Value) { oferta.Rep1Comision = Convert.ToDouble(dr["rep1comision"]); }
        //        if (dr["idrep2"] != DBNull.Value) { oferta.IdRep2 = Convert.ToInt32(dr["idrep2"]); }
        //        oferta.Rep2 = dr["rep2"].ToString();
        //        oferta.Rep2Pais = dr["rep2pais"].ToString();
        //        if (dr["rep1comision"] != DBNull.Value) { oferta.Rep1Comision = Convert.ToDouble(dr["rep1comision"]); }

        //        // Condiciones
        //        oferta.DireccionEntrega = dr["direccionentrega"].ToString();
        //        if (dr["entrega"] != DBNull.Value) { oferta.TipoEntregaId = Convert.ToInt32(dr["entrega"]); }
        //        oferta.TipoEntrega = dr["tipoentrega"].ToString();
        //        if (dr["pago"] != DBNull.Value) { oferta.TipoPagoId = Convert.ToInt32(dr["pago"]); }
        //        oferta.TipoPago = dr["tipopago"].ToString();
        //        oferta.Pago1 = dr["pago1"].ToString();
        //        oferta.Pago2 = dr["pago2"].ToString();
        //        oferta.PagoHito1 = dr["hito1"].ToString();
        //        oferta.PagoHito2 = dr["hito2"].ToString();
        //        oferta.PagoPlazo1 = dr["plazo1"].ToString();
        //        oferta.PagoPlazo2 = dr["plazo2"].ToString();
        //        oferta.CalculoGM = (dr["calculogm"].ToString() == "") ? "PGM" : dr["calculogm"].ToString();

        //        // Numeros
        //        if (dr["costototal"] != DBNull.Value) { oferta.CostoTotal = Convert.ToDouble(dr["costototal"]); }
        //        if (dr["ventatotal"] != DBNull.Value) { oferta.VentaTotal = Convert.ToDouble(dr["ventatotal"]); }
        //        if (dr["gm"] != DBNull.Value) { oferta.GM = Convert.ToDouble(dr["gm"]) / 100; }
        //        if (dr["mup"] != DBNull.Value) { oferta.Mup = Convert.ToDouble(dr["mup"]); } else { oferta.Mup = 1.5; }
        //        if (dr["descuento"] != DBNull.Value) { oferta.DescProv = Convert.ToDouble(dr["descuento"]); } else { oferta.DescProv = 0; }
        //        if (dr["packaging"] != DBNull.Value) { oferta.Packaging = Convert.ToDouble(dr["packaging"]); } else { oferta.Packaging = 0; }
        //        if (dr["packagingv"] != DBNull.Value) { oferta.PackagingV = Convert.ToDouble(dr["packagingv"]); } else { oferta.PackagingV = 0; }
        //        if (dr["transporte"] != DBNull.Value) { oferta.Transporte = Convert.ToDouble(dr["transporte"]); } else { oferta.Transporte = 0; }
        //        if (dr["transportev"] != DBNull.Value) { oferta.TransporteV = Convert.ToDouble(dr["transportev"]); } else { oferta.TransporteV = 0; }
        //        if (dr["aduana"] != DBNull.Value) { oferta.Aduana = Convert.ToDouble(dr["aduana"]); } else { oferta.Aduana = 0; }
        //        if (dr["aduanav"] != DBNull.Value) { oferta.AduanaV = Convert.ToDouble(dr["aduanav"]); } else { oferta.AduanaV = 0; }
        //        if (dr["mn"] != DBNull.Value) { oferta.MN = Convert.ToDouble(dr["mn"]); } else { oferta.MN = 3; }
        //        if (dr["radicional"] != DBNull.Value) { oferta.RAdd = Convert.ToDouble(dr["radicional"]); } else { oferta.RAdd = 2; }
        //        if (dr["fin"] != DBNull.Value) { oferta.Fin = Convert.ToDouble(dr["fin"]); } else { oferta.Fin = 1; }
        //        if (dr["ing"] != DBNull.Value) { oferta.Ing = Convert.ToDouble(dr["ing"]); } else { oferta.Ing = 1; }
        //        if (dr["adelanto"] != DBNull.Value) { oferta.BA = Convert.ToDouble(dr["adelanto"]); }
        //        if (dr["garantia"] != DBNull.Value) { oferta.BCG = Convert.ToDouble(dr["garantia"]); }
        //        if (dr["fielcumplimiento"] != DBNull.Value) { oferta.BFC = Convert.ToDouble(dr["fielcumplimiento"]); }

        //        // Detalles
        //        oferta.RefCliente = dr["refcliente"].ToString();
        //        oferta.Descripcion = dr["detallesoferta"].ToString();
        //        if (dr["eur"] != DBNull.Value) { oferta.EUR = Convert.ToDouble(dr["eur"]); }
        //        if (dr["gbp"] != DBNull.Value) { oferta.GBP = Convert.ToDouble(dr["gbp"]); }
        //        if (dr["clp"] != DBNull.Value) { oferta.CLP = Convert.ToDouble(dr["clp"]); }
        //        if (dr["sol"] != DBNull.Value) { oferta.PEN = Convert.ToDouble(dr["sol"]); }
        //        if (dr["brl"] != DBNull.Value) { oferta.BRL = Convert.ToDouble(dr["brl"]); }
        //        if (dr["plazo"] != DBNull.Value) { oferta.PlazoEntrega = Convert.ToInt32(dr["plazo"]); }
        //        if (dr["validez"] != DBNull.Value) { oferta.Validez = Convert.ToInt32(dr["validez"]); }

        //        // Equipo
        //        if (dr["idproveedor"] != DBNull.Value) { oferta.Proveedor = Convert.ToInt32(dr["idproveedor"]); }
        //        oferta.AcronProveedor = dr["acronprov"].ToString();
        //        oferta.NombreProveedor = dr["acronprov"].ToString() + " - " + dr["nombreprov"].ToString();
        //        oferta.CotizacionProveedor = ("-").ToString();/// dr["acron"].ToString();
        //        oferta.Modelo = dr["modelo"].ToString();
        //        oferta.NSerie = dr["nserie"].ToString();
        //        if (dr["producto"] != DBNull.Value) { oferta.ProductoId = Convert.ToInt32(dr["producto"]); }
        //        oferta.Producto = dr["productocrm"].ToString() + " (" + dr["idequipocrm"].ToString() + ")";
        //        oferta.TipoMaquina = dr["tipoequipo"].ToString();
        //        oferta.IDEquipoCRM = dr["idequipocrm"].ToString();

        //        // Venta                
        //        if (dr["fechaoc"] != DBNull.Value) { oferta.FechaOC = Convert.ToDateTime(dr["fechaoc"]); }
        //        if (dr["fechaemisionoc"] != DBNull.Value) { oferta.FechaEmisionOC = Convert.ToDateTime(dr["fechaemisionoc"]); }
        //        if (dr["fechaentrega"] != DBNull.Value) { oferta.FechaEntrega = Convert.ToDateTime(dr["fechaentrega"]); }
        //        oferta.OC = dr["oc"].ToString();
        //        oferta.NPV = dr["npv"].ToString();

        //        ListaOfertas.Add(oferta);
        //    }

        //    return ListaOfertas;
        //}

        ///// <summary>
        ///// Inserta nueva Oferta en BBDD
        ///// Copia los valores de las monedas de la ultima oferta (max(id)), o los deja igual a 1
        ///// </summary>
        ///// <param name="Oferta"></param>
        ///// <returns>Id de la oferta ingresa, 0 si error</returns>
        //public static int insertar(Oferta Oferta)
        //{
        //    NumberFormatInfo nfi = new NumberFormatInfo();
        //    nfi.NumberDecimalSeparator = ".";

        //    //Oferta = Ofertas.nueva(Oferta);

        //    Oferta ListaCambios = new Oferta();
        //    ListaCambios = ultimasMonedas(0);

        //    Oferta.EUR = (ListaCambios.EUR != 0) ? ListaCambios.EUR : 1;
        //    Oferta.PEN = (ListaCambios.EUR != 0) ? ListaCambios.PEN : 1;
        //    Oferta.PEN = (ListaCambios.EUR != 0) ? ListaCambios.PEN : 1;
        //    Oferta.CLP = (ListaCambios.EUR != 0) ? ListaCambios.CLP : 1;
        //    Oferta.BRL = (ListaCambios.EUR != 0) ? ListaCambios.BRL : 1;

        //    string textSQL1 = "INSERT INTO tbosp (ncrm, rev, mup, mn, radicional, ing, fin, bfielcumplimiento, badelanto, bcalidadygarantia, packaging, packagingv, aduana, aduanav," +
        //        "transporte, transportev, validez, eur, gbp, clp, brl, sol, idbu, estado, idioma, edicion) VALUES ('" + Oferta.NCRM + "', '" + Oferta.Rev + "', '" + Oferta.Mup + "', '" +
        //        Oferta.MN.ToString(nfi) + "', '" + Oferta.RAdd.ToString(nfi) + "', '" + Oferta.Ing.ToString(nfi) + "', '" + Oferta.Fin.ToString(nfi) + "', '" +
        //        Oferta.BFC.ToString(nfi) + "', '" + Oferta.BA.ToString(nfi) + "', '" + Oferta.BCG.ToString(nfi) + "', '" + Oferta.Packaging.ToString(nfi) + "', '" +
        //        Oferta.PackagingV.ToString(nfi) + "', '" + Oferta.Aduana.ToString(nfi) + "', '" + Oferta.AduanaV.ToString(nfi) + "', '" + Oferta.Transporte.ToString(nfi) + "', '" +
        //        Oferta.TransporteV.ToString(nfi) + "', '" + Oferta.Validez.ToString(nfi) + "', '" + Oferta.EUR.ToString(nfi) + "', '" + Oferta.GBP.ToString(nfi) + "', '" +
        //        Oferta.CLP.ToString(nfi) + "', '" + Oferta.BRL.ToString(nfi) + "', '" + Oferta.PEN.ToString(nfi) + "', '" + Oferta.BU + "', 'Edicion', '" + Oferta.Idioma + "', '" + DateTime.UtcNow.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss") + "'); " +
        //        "select last_insert_rowid();";

        //    long ido = RepositorioBase.EjecutarSQLScalar(textSQL1);

        //    return Convert.ToInt32(ido);
        //}

        ///// <summary>
        ///// Guarda infos generales
        ///// </summary>
        ///// <param name="Oferta"></param>
        ///// <returns>1 si guardo, 2 sino</returns>
        //public static int editar(Oferta Oferta)
        //{
        //    ///Cambia separador de decimal, para agregar a BBDD
        //    NumberFormatInfo nfi = new NumberFormatInfo();
        //    nfi.NumberDecimalSeparator = ".";

        //    string cliente = (Oferta.IdCliente == 0 || Oferta.TipoCliente != 1) ? "" : Oferta.IdCliente.ToString();
        //    string vendor = (Oferta.IdVendor == 0 || Oferta.TipoCliente != 2) ? "" : Oferta.IdVendor.ToString();
        //    string rep1 = (Oferta.IdRep1 == 0) ? "" : Oferta.IdRep1.ToString();
        //    string rep2 = (Oferta.IdRep2 == 0) ? "" : Oferta.IdRep2.ToString();
        //    string contacto = (Oferta.IdContacto == 0) ? "" : Oferta.IdContacto.ToString();
        //    string kam = (Oferta.IdKAM == 0) ? "" : Oferta.IdKAM.ToString();
        //    string ka = (Oferta.IdKA == 0) ? "" : Oferta.IdKA.ToString();
        //    string vendedor1 = (Oferta.IdVendedor1 == 0) ? "" : Oferta.IdVendedor1.ToString();
        //    string vendedor2 = (Oferta.IdVendedor2 == 0) ? "" : Oferta.IdVendedor2.ToString();
        //    string vendedor3 = (Oferta.IdVendedor3 == 0) ? "" : Oferta.IdVendedor3.ToString();
        //    string aplicador = (Oferta.IdAplicador == 0) ? "" : Oferta.IdAplicador.ToString();
        //    string currId = (Oferta.CurrId == 0) ? "0" : Oferta.CurrId.ToString();
        //    string tipoEntregaId = (Oferta.TipoEntregaId == 0) ? "" : Oferta.TipoEntregaId.ToString();
        //    string tipoPagoId = (Oferta.TipoPagoId == 0) ? "" : Oferta.TipoPagoId.ToString();
        //    string validez = (Oferta.Validez == 0) ? "0" : Oferta.Validez.ToString();
        //    string plazoEntrega = (Oferta.PlazoEntrega == 0) ? "" : Oferta.PlazoEntrega.ToString();
        //    string proveedor = (Oferta.Proveedor == 0) ? "" : Oferta.Proveedor.ToString();
        //    string refCliente = (Oferta.RefCliente == null) ? "" : Oferta.RefCliente.ToString();
        //    string modelo = (Oferta.Modelo == null) ? "" : Oferta.Modelo.ToString();
        //    string nSerie = (Oferta.NSerie == null) ? "" : Oferta.NSerie.ToString();
        //    string bu = (Oferta.BU == 0) ? "" : Oferta.BU.ToString();
        //    string productoId = (Oferta.ProductoId == 0) ? "" : Oferta.ProductoId.ToString();
        //    string subIndustria = (Oferta.SubIndustria == 0) ? "" : Oferta.SubIndustria.ToString();
        //    string direccionEntrega = (Oferta.DireccionEntrega == null) ? "" : Oferta.DireccionEntrega.ToString();
        //    string descripcion = (Oferta.Descripcion == null) ? "" : Oferta.Descripcion.ToString();
        //    string eur = (Oferta.EUR == 0) ? "1" : Math.Round(Oferta.EUR, 4).ToString(nfi);
        //    string gbp = (Oferta.GBP == 0) ? "1" : Math.Round(Oferta.GBP, 4).ToString(nfi);
        //    string clp = (Oferta.CLP == 0) ? "1" : Math.Round(Oferta.CLP, 4).ToString(nfi);
        //    string brl = (Oferta.BRL == 0) ? "1" : Math.Round(Oferta.BRL, 4).ToString(nfi);
        //    string pen = (Oferta.PEN == 0) ? "1" : Math.Round(Oferta.PEN, 4).ToString(nfi);
        //    string ctotal = (Oferta.CostoTotalCR == 0) ? "" : Math.Round(Oferta.CostoTotalCR, 2).ToString(nfi);
        //    string vliquida = (Oferta.VLiquida == 0) ? "" : Math.Round(Oferta.VLiquida, 2).ToString(nfi);
        //    string pm = (Oferta.GM == 0) ? "0" : Math.Round(Oferta.GM * 100, 4).ToString(nfi);
        //    string mup = (Oferta.Mup == 0) ? "0" : (Oferta.Mup).ToString(nfi);
        //    string mn = (Oferta.MN == 0) ? "0" : Math.Round(Oferta.MN, 4).ToString(nfi);
        //    string radd = (Oferta.RAdd == 0) ? "0" : Math.Round(Oferta.RAdd, 4).ToString(nfi);
        //    string fin = (Oferta.Fin == 0) ? "0" : Math.Round(Oferta.Fin, 4).ToString(nfi);
        //    string ing = (Oferta.Ing == 0) ? "0" : Math.Round(Oferta.Ing, 4).ToString(nfi);
        //    string packaging = (Oferta.Packaging == 0) ? "" : Math.Round(Oferta.Packaging, 4).ToString(nfi);
        //    string packagingv = (Oferta.PackagingV == 0) ? "" : Math.Round(Oferta.PackagingV, 4).ToString(nfi);
        //    string transporte = (Oferta.Transporte == 0) ? "" : Math.Round(Oferta.Transporte, 4).ToString(nfi);
        //    string transportev = (Oferta.TransporteV == 0) ? "" : Math.Round(Oferta.TransporteV, 4).ToString(nfi);
        //    string aduana = (Oferta.Aduana == 0) ? "" : Math.Round(Oferta.Aduana, 4).ToString(nfi);
        //    string aduanav = (Oferta.AduanaV == 0) ? "" : Math.Round(Oferta.AduanaV, 4).ToString(nfi);
        //    string desc = (Oferta.DescProv == 0) ? "" : Math.Round(Oferta.DescProv, 4).ToString(nfi);
        //    string calculo = (Oferta.CalculoGM == "" || Oferta.CalculoGM == null) ? "" : Oferta.CalculoGM;
        //    string bfc = (Oferta.BFC == 0) ? "0" : Math.Round(Oferta.BFC, 4).ToString(nfi);
        //    string ba = (Oferta.BA == 0) ? "0" : Math.Round(Oferta.BA, 4).ToString(nfi);
        //    string bcg = (Oferta.BCG == 0) ? "0" : Math.Round(Oferta.BCG, 4).ToString(nfi);
        //    string idioma = (Oferta.Idioma == null) ? "" : Oferta.Idioma.ToString();




        //    string textSQL = "UPDATE tbosp SET " +
        //        "idcliente = '" + cliente + "', " +
        //        "idvendor = '" + vendor + "', " +
        //        "idrep1 = '" + rep1 + "', " +
        //        "idrep2 = '" + rep2 + "', " +
        //        "curr = '" + currId + "', " +
        //        "entrega = '" + tipoEntregaId + "', " +
        //        "pago = '" + tipoPagoId + "', " +
        //        "validez = '" + validez + "', " +
        //        "plazo = '" + plazoEntrega + "', " +
        //        "idcontacto = '" + contacto + "', " +
        //        "idkam = '" + kam + "', " +
        //        "idka = '" + ka + "', " +
        //        "idaplicador = '" + aplicador + "', " +
        //        "idproveedor = '" + proveedor + "', " +
        //        "refcliente = '" + refCliente + "', " +
        //        "modelo = '" + modelo + "', " +
        //        "nserie = '" + nSerie + "', " +
        //        "idbu = '" + bu + "', " +
        //        "producto = '" + productoId + "', " +
        //        "mercado = '" + subIndustria + "', " +
        //        "direccionentrega = '" + direccionEntrega + "', " +
        //        "idvendedor1 = '" + vendedor1 + "', " +
        //        "idvendedor2 = '" + vendedor2 + "', " +
        //        "idvendedor3 = '" + vendedor3 + "', " +
        //        "detallesoferta = '" + descripcion + "', " +
        //        "eur = '" + eur + "', " +
        //        "gbp = '" + gbp + "', " +
        //        "clp = '" + clp + "', " +
        //        "brl = '" + brl + "', " +
        //        "sol = '" + pen + "', " +
        //        "costototal = '" + ctotal + "', " +
        //        "ventatotal = '" + vliquida + "', " +
        //        "gm = '" + pm + "', " +
        //        "mup = '" + mup + "', " +
        //        "descuento = '" + desc + "', " +
        //        "packaging = '" + packaging + "', " +
        //        "packagingv = '" + packagingv + "', " +
        //        "transporte = '" + transporte + "', " +
        //        "transportev = '" + transportev + "', " +
        //        "aduana = '" + aduana + "', " +
        //        "aduanav = '" + aduanav + "', " +
        //        "radicional = '" + radd + "', " +
        //        "mn = '" + mn + "', " +
        //        "fin = '" + fin + "', " +
        //        "ing = '" + ing + "', " +
        //        "bfielcumplimiento = '" + bfc + "', " +
        //        "badelanto = '" + ba + "', " +
        //        "bcalidadygarantia = '" + bcg + "', " +
        //        "calculogm = '" + calculo + "', " +
        //        "idioma = '" + idioma + "', " +
        //        "edicion = '" + DateTime.UtcNow.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss") + "' " +
        //        "WHERE id = '" + Oferta.Id + "';";

        //    int res = RepositorioBase.EjecutarSQLComando(textSQL.Replace("''", "NULL"));

        //    return res;
        //}

        ///// <summary>
        ///// Elimina oferta, revisiones, repuestos y equipos linkeados 
        ///// de la base de datos
        ///// </summary>
        ///// <param name="Oferta"></param>
        //public static void eliminar(Oferta Oferta)
        //{
        //    try
        //    {
        //        DataTable dtIds = revisarSiExiste(Oferta);

        //        if (dtIds.Rows.Count == 0)
        //        {
        //            MessageBox.Show("No se encontró la oferta en la base de datos. Comuniquese con el " +
        //                "administrador si continua con problemas.");
        //            return;
        //        }

        //        int count = dtIds.Rows.Count;
        //        int res = 0;
        //        int rep = 0;
        //        int req = 0;
        //        string revs = "(";

        //        foreach (DataRow dr in dtIds.Rows)
        //        {
        //            Oferta oferta = new Oferta();
        //            oferta.Id = Convert.ToInt32(dr["id"].ToString());
        //            oferta.Rev = Convert.ToInt32(dr["rev"].ToString());
        //            oferta.NCRM = dr["ncrm"].ToString();

        //            string textSQL = "DELETE FROM tbosp WHERE id = '" + oferta.Id + "'";
        //            res += RepositorioBase.EjecutarSQLComando(textSQL);

        //            string textSQLrep = "DELETE FROM tbrepuestos WHERE idosp = '" + oferta.Id + "'";
        //            rep += RepositorioBase.EjecutarSQLComando(textSQLrep);

        //            string textSQLequipo = "DELETE FROM tboequipos WHERE idofertasp = '" + oferta.Id + "'";
        //            req += RepositorioBase.EjecutarSQLComando(textSQLequipo);

        //            if (oferta.Id.ToString() != dtIds.Rows[count - 1]["id"].ToString()) { revs += oferta.Rev + ","; }
        //            else { revs += oferta.Rev + ")"; }
        //        }


        //        string mensaje = "Los siguientes datos fueron eliminados de la Base de datos: ";
        //        if (res > 1) { mensaje += "Revisiones " + revs; }
        //        if (rep > 1) { mensaje += ", repuestos "; }
        //        if (req > 1) { mensaje += ", equipos linkeados"; }
        //        mensaje += " de la oferta " + Oferta.NCRM;

        //        MessageBox.Show(mensaje);
        //    }
        //    catch (Exception e) { MessageBox.Show("No se pudo eliminar la oferta por problemas de conexión al servidor. Intentelo de nuevo más tarde. Error: " + e); }
        //}

        //public static void consolidarOferta(Oferta Oferta, string Tipo = "Full")
        //{
        //    if (Tipo == "Full")
        //    {
        //        int r = 0;
        //        string textSQLa = "SELECT ncrm, rev FROM tbosp WHERE ncrm = '" + Oferta.NCRM + "';";
        //        DataTable dtRev = new DataTable();
        //        dtRev = RepositorioBase.EjecutarSQL(textSQLa);
        //        if (dtRev.Rows.Count > 0)
        //        {
        //            for (int i = 0; i < dtRev.Rows.Count; i++)
        //            {
        //                int Revi = Convert.ToInt32(dtRev.Rows[i][1]);

        //                if (Revi != Oferta.Rev)
        //                {
        //                    string textSQLb = "UPDATE tbosp SET estado = 'RevVendida' WHERE ncrm = '" + Oferta.NCRM + "' AND rev = " + Revi;
        //                    r = RepositorioBase.EjecutarSQLComando(textSQLb);
        //                }
        //            }
        //        }

        //        string textSQL = "UPDATE tbosp SET estado = 'Consolidando', npv = '" + Oferta.NPV + "', " +
        //            "oc = '" + Oferta.OC + "', fechaoc = '" + Oferta.FechaOC.ToString("yyyy-MM-dd") + "', fechaentrega = '" + Oferta.FechaEntrega.ToString("yyyy-MM-dd") + "' " +
        //            "WHERE ncrm = '" + Oferta.NCRM + "' AND rev = '" + Oferta.Rev + "';";

        //        int res = RepositorioBase.EjecutarSQLComando(textSQL);
        //        if (res > 0 && r == 0) { MessageBox.Show("Informaciones de la oferta guardadas correctamente"); }
        //        else if (res > 0 && r != 0) { MessageBox.Show("Informaciones de la oferta y sus revisiones guardadas correctamente"); }
        //    }
        //    else if (Tipo == "Previa")
        //    {
        //        string textSQLs = "UPDATE tbosp SET ";
        //        if (Oferta.OC != null) { textSQLs += "oc = '" + Oferta.OC + "', "; }
        //        else { textSQLs += "oc = NULL, "; }
        //        if (Oferta.FechaOC != null) { textSQLs += "fechaoc = '" + Oferta.FechaOC.ToString("yyyy-MM-dd") + "', "; }
        //        else { textSQLs += "fechaoc = NULL, "; }
        //        if (Oferta.FechaEmisionOC != null) { textSQLs += "fechaemisionoc = '" + Oferta.FechaEmisionOC.ToString("yyyy-MM-dd") + "', "; }
        //        else { textSQLs += "fechaemisionoc = NULL, "; }
        //        if (Oferta.FechaEntrega != null) { textSQLs += "fechaentrega = '" + Oferta.FechaEntrega.ToString("yyyy-MM-dd") + "' "; }
        //        else { textSQLs += "fechaentrega = NULL "; }
        //        textSQLs += " WHERE id = '" + Oferta.Id + "';";

        //        int res = RepositorioBase.EjecutarSQLComando(textSQLs);

        //        if (res == 0)
        //        {
        //            MessageBox.Show("Algún error hubo al actualizar las informaciones en la Base de Datos, por favor inténtelo " +
        //              "de nuevo o comuniquese con el administrador");
        //        }
        //    }

        //}








        /////
        ///// REVISIONES
        ///// 

        ///// <summary>
        ///// Metodo para insert nueva Revision, llama a insertarNuevaRev, insertarEquiposLinkeados, insertarRepuestosRevBase, insertarServiciosRevBase
        ///// </summary>
        ///// <param name="Oferta"></param>
        ///// <param name="IdBase"></param>
        ///// <param name="NRev"></param>
        ///// <returns></returns>
        //public static Oferta nuevaRev(Oferta Oferta, long IdBase, int NRev)
        //{
        //    try
        //    {
        //        ///Insert nueva revision
        //        string textSQLa = "SELECT * FROM tbosp WHERE ncrm = '" + Oferta.NCRM + "' AND rev = '" + NRev + "';";
        //        DataTable dtSP = RepositorioBase.EjecutarSQL(textSQLa);

        //        if (dtSP.Rows.Count == 0)
        //        {
        //            int r = 0;
        //            r = insertarNuevaRev(Oferta);
        //            if (r == 0) { MessageBox.Show("Revisión registrada correctamente, al parecer no se logró cambiar el estado de la revisión anterior. Comuniquese con el administrador si hay algún problema"); }
        //            else if (r > 0) { MessageBox.Show("Revisión registrada correctamente"); Oferta.Id = r; Oferta.Estado = "Editando"; }
        //        }
        //        else if (dtSP.Rows.Count > 0)
        //        {
        //            MessageBox.Show("Revisión ya existe, comuniquese con el administrador si algo sale mal");
        //            Oferta.Id = Convert.ToInt32(dtSP.Rows[0][0]);
        //            Oferta.Rev = NRev;
        //        }
        //    }
        //    catch (Exception f) { MessageBox.Show("No se pudo insertar una nueva oferta por problemas de conexión al servidor. Intentelo de nuevo más tarde. Error: " + f); }


        //    try { RepositorioEquipo.linkear(Oferta, (int)IdBase); }
        //    catch (Exception f) { MessageBox.Show("No se pudo insertar una nueva oferta por problemas de conexión al servidor. Intentelo de nuevo más tarde. Error: " + f); }

        //    try { RepositorioRepuesto.insertarRepuestosRevBase(Oferta, (int)IdBase); }
        //    catch (Exception f) { MessageBox.Show("No se pudo insertar los repuestos por problemas de conexión al servidor. Intentelo de nuevo más tarde. Error: " + f); }

        //    try { RepositorioRepuesto.insertarServiciosRevBase(Oferta, (int)IdBase); }
        //    catch (Exception f) { MessageBox.Show("No se pudo insertar los repuestos por problemas de conexión al servidor. Intentelo de nuevo más tarde. Error: " + f); }

        //    return Oferta;
        //}

        ///// <summary>
        ///// Inserta una nueva revision de Oferta.NCRM en tbosp
        ///// </summary>
        //private static int insertarNuevaRev(Oferta Oferta)
        //{
        //    NumberFormatInfo nfi = new NumberFormatInfo();
        //    nfi.NumberDecimalSeparator = ".";

        //    string cliente = (Oferta.IdCliente == 0) ? "" : Oferta.IdCliente.ToString();
        //    string vendor = (Oferta.IdVendor == 0) ? "" : Oferta.IdVendor.ToString();
        //    string rep1 = (Oferta.IdRep1 == 0) ? "" : Oferta.IdRep1.ToString();
        //    string rep2 = (Oferta.IdRep2 == 0) ? "" : Oferta.IdRep2.ToString();
        //    string contacto = (Oferta.IdContacto == 0) ? "" : Oferta.IdContacto.ToString();
        //    string kam = (Oferta.IdKAM == 0) ? "" : Oferta.IdKAM.ToString();
        //    string ka = (Oferta.IdKA == 0) ? "" : Oferta.IdKA.ToString();
        //    string vendedor1 = (Oferta.IdVendedor1 == 0) ? "" : Oferta.IdVendedor1.ToString();
        //    string vendedor2 = (Oferta.IdVendedor2 == 0) ? "" : Oferta.IdVendedor2.ToString();
        //    string vendedor3 = (Oferta.IdVendedor3 == 0) ? "" : Oferta.IdVendedor3.ToString();
        //    string aplicador = (Oferta.IdAplicador == 0) ? "" : Oferta.IdAplicador.ToString();
        //    string currId = (Oferta.CurrId == 0) ? "0" : Oferta.CurrId.ToString();
        //    string tipoEntregaId = (Oferta.TipoEntregaId == 0) ? "" : Oferta.TipoEntregaId.ToString();
        //    string tipoPagoId = (Oferta.TipoPagoId == 0) ? "" : Oferta.TipoPagoId.ToString();
        //    string validez = (Oferta.Validez == 0) ? "0" : Oferta.Validez.ToString();
        //    string plazoEntrega = (Oferta.PlazoEntrega == 0) ? "" : Oferta.PlazoEntrega.ToString();
        //    string proveedor = (Oferta.Proveedor == 0) ? "" : Oferta.Proveedor.ToString();
        //    string refCliente = (Oferta.RefCliente == null) ? "" : Oferta.RefCliente.ToString();
        //    string modelo = (Oferta.Modelo == null) ? "" : Oferta.Modelo.ToString();
        //    string nSerie = (Oferta.NSerie == null) ? "" : Oferta.NSerie.ToString();
        //    string bu = (Oferta.BU == 0) ? "" : Oferta.BU.ToString();
        //    string productoId = (Oferta.ProductoId == 0) ? "" : Oferta.ProductoId.ToString();
        //    string subIndustria = (Oferta.SubIndustria == 0) ? "" : Oferta.SubIndustria.ToString();
        //    string direccionEntrega = (Oferta.DireccionEntrega == null) ? "" : Oferta.DireccionEntrega.ToString();
        //    string descripcion = (Oferta.Descripcion == null) ? "" : Oferta.Descripcion.ToString();
        //    string eur = (Oferta.EUR == 0) ? "1" : Math.Round(Oferta.EUR, 4).ToString(nfi);
        //    string gbp = (Oferta.GBP == 0) ? "1" : Math.Round(Oferta.GBP, 4).ToString(nfi);
        //    string clp = (Oferta.CLP == 0) ? "1" : Math.Round(Oferta.CLP, 4).ToString(nfi);
        //    string brl = (Oferta.BRL == 0) ? "1" : Math.Round(Oferta.BRL, 4).ToString(nfi);
        //    string pen = (Oferta.PEN == 0) ? "1" : Math.Round(Oferta.PEN, 4).ToString(nfi);
        //    string ctotal = (Oferta.CostoTotal == 0) ? "" : Math.Round(Oferta.CostoTotal, 2).ToString(nfi);
        //    string vliquida = (Oferta.VLiquida == 0) ? "" : Math.Round(Oferta.VLiquida, 2).ToString(nfi);
        //    string pm = (Oferta.GM == 0) ? "0" : Math.Round(Oferta.GM * 100, 4).ToString(nfi);
        //    string mup = (Oferta.Mup == 0) ? "0" : (Oferta.Mup).ToString(nfi);
        //    string mn = (Oferta.MN == 0) ? "0" : Math.Round(Oferta.MN, 4).ToString(nfi);
        //    string radd = (Oferta.RAdd == 0) ? "0" : Math.Round(Oferta.RAdd, 4).ToString(nfi);
        //    string fin = (Oferta.Fin == 0) ? "0" : Math.Round(Oferta.Fin, 4).ToString(nfi);
        //    string ing = (Oferta.Ing == 0) ? "0" : Math.Round(Oferta.Ing, 4).ToString(nfi);
        //    string packaging = (Oferta.Packaging == 0) ? "" : Math.Round(Oferta.Packaging, 4).ToString(nfi);
        //    string packagingv = (Oferta.PackagingV == 0) ? "" : Math.Round(Oferta.PackagingV, 4).ToString(nfi);
        //    string transporte = (Oferta.Transporte == 0) ? "" : Math.Round(Oferta.Transporte, 4).ToString(nfi);
        //    string transportev = (Oferta.TransporteV == 0) ? "" : Math.Round(Oferta.TransporteV, 4).ToString(nfi);
        //    string aduana = (Oferta.Aduana == 0) ? "" : Math.Round(Oferta.Aduana, 4).ToString(nfi);
        //    string aduanav = (Oferta.AduanaV == 0) ? "" : Math.Round(Oferta.AduanaV, 4).ToString(nfi);
        //    string desc = (Oferta.DescProv == 0) ? "" : Math.Round(Oferta.DescProv, 4).ToString(nfi);
        //    string calculo = (Oferta.CalculoGM == "" || Oferta.CalculoGM == null) ? "" : Oferta.CalculoGM;
        //    string bfc = (Oferta.BFC == 0) ? "0" : Math.Round(Oferta.BFC, 4).ToString(nfi);
        //    string ba = (Oferta.BA == 0) ? "0" : Math.Round(Oferta.BA, 4).ToString(nfi);
        //    string bcg = (Oferta.BCG == 0) ? "0" : Math.Round(Oferta.BCG, 4).ToString(nfi);
        //    string idioma = (Oferta.Idioma == null) ? "" : Oferta.Idioma.ToString();
        //    DateTime date = DateTime.UtcNow;

        //    int r = 0;
        //    string textSQL = "INSERT INTO tbosp (idbu, ncrm, rev, idcliente, idvendor, idrep1, idrep2, curr, costototal, ventatotal, gm, entrega, pago, validez, " +
        //        "plazo, idcontacto, idkam, idka, idaplicador, refcliente, modelo, nserie, idproveedor, producto, mercado, direccionentrega, mup, packaging, packagingv, " +
        //        "descuento, mn, radicional, ing, fin, eur, gbp, sol, clp, brl, transporte, transportev, aduana, aduanav, badelanto, " +
        //        "bfielcumplimiento, bcalidadygarantia, idvendedor1, idvendedor2, idvendedor3, detallesoferta, calculogm, idioma, edicion)  VALUES ('" +
        //        bu + "', '" + Oferta.NCRM + "', '" + Oferta.Rev + "', '" + cliente + "', '" + vendor + "', '" + rep1 + "', '" + rep2 + "', '" + currId + "', '" + ctotal + "', '" +
        //        vliquida + "', '" + pm + "', '" + tipoEntregaId + "', '" + tipoPagoId + "', '" + validez + "', '" + plazoEntrega + "', '" + contacto + "', '" + kam + "', '" +
        //        ka + "', '" + aplicador + "', '" + refCliente + "', '" + modelo + "', '" + nSerie + "', '" + proveedor + "', '" + productoId + "', '" + subIndustria + "', '" +
        //        direccionEntrega + "', '" + mup + "', '" + packaging + "', '" + packagingv + "', '" + desc + "', '" + mn + "', '" + radd + "', '" + ing + "', '" + fin + "', '" +
        //        eur + "', '" + gbp + "', '" + pen + "', '" + clp + "', '" + brl + "', '" + transporte + "', '" + transportev + "', '" + aduana + "', '" + aduanav + "', '" +
        //        ba + "', '" + bfc + "', '" + bcg + "', '" + vendedor1 + "', '" + vendedor2 + "', '" + vendedor3 + "', '" + descripcion + "', '" + calculo + "', '" + idioma + "', '" +
        //        date.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss") + "'); " +
        //        "select last_insert_rowid();";


        //    long ido = RepositorioBase.EjecutarSQLScalar(textSQL.Replace("''", "NULL"));

        //    if (ido > 0)
        //    {
        //        r = 0;
        //        ///Query para guardar informaciones generales de la oferta
        //        textSQL = "UPDATE tbosp SET estado = 'Revision' WHERE ncrm = '" + Oferta.NCRM + "'; UPDATE tbosp SET estado = 'Edicion' WHERE id = '" + ido + "';";
        //        int res = RepositorioBase.EjecutarSQLComando(textSQL);

        //        if (res > 0) { r = (int)ido; }

        //    }

        //    return r;
        //}








        ///// 
        ///// ESTADOS
        /////        

        //public static void ofertaEnviada(Oferta Oferta)
        //{
        //    cambiarEstado(Oferta, "Enviada", "rev");
        //}
        //public static void ofertaEdicion(Oferta Oferta)
        //{
        //    cambiarEstado(Oferta, "Edicion", "rev");
        //}
        //public static void ofertaCancelada(Oferta Oferta)
        //{
        //    cambiarEstado(Oferta, "Cancelada");
        //}
        //public static void ofertaPerdida(Oferta Oferta)
        //{
        //    cambiarEstado(Oferta, "Perdida");
        //}
        ///// <summary>
        ///// Cambia estado de la oferta 
        ///// </summary>
        ///// <param name="Oferta"></param>
        ///// <param name="estado"></param>
        ///// <summary>
        ///// Deja la revision seleccionada en estado `Actvia`,
        ///// y las demas revisiones como `Revision`
        ///// </summary>
        ///// <param name="Venta"></param>
        //public static void devolverOferta(Oferta Venta)
        //{
        //    try
        //    {
        //        cambiarEstado(Venta, "Revision");
        //        cambiarEstado(Venta, "Activa", "rev");
        //        string textSQL = "UPDATE tbosp SET oc = NULL, fechaoc = NULL, fechaentrega = NULL, npv = NULL WHERE ncrm = '" + Venta.NCRM + "' AND rev = '" + Venta.Rev + "' ";

        //        int res = RepositorioBase.EjecutarSQLComando(textSQL);
        //    }
        //    catch (Exception e) { MessageBox.Show("No se pudo enviar a ventas por problemas de conexión al servidor. Intentelo de nuevo más tarde. Error: " + e); }
        //}
        ///// <summary>
        ///// Cambia el estado de la oferta y las revisiones en tbosp
        ///// Agrega la venta en tbvsp
        ///// </summary>
        ///// <param name="Venta"></param>
        //public static void enviarVentas(Oferta Venta)
        //{
        //    try
        //    {
        //        cambiarEstado(Venta, "Vendida", "rev");
        //        string textSQL = "UPDATE tbrepuestos SET idvsp = '" + Venta.NPV + "' WHERE idosp = '" + Venta.Id + "';";

        //        int res = RepositorioBase.EjecutarSQLComando(textSQL);


        //        /// Insertar en tabla tvsp
        //        textSQL = "INSERT INTO tbvsp (pv, idbu, crm, rev, idcliente, idvendor, idrep1, idrep2, entrega, pago, curr, venta, idproveedor, fechaoc, " +
        //            "fechaentrega, comentarios, idmercado, idaplicador) VALUES ('" + Venta.NPV + "', '" + Venta.BU + "', '" + Venta.NCRM + "', '" + Venta.Rev + "', '" + Venta.IdCliente +
        //            "', '" + Venta.IdVendor + "', '" + Venta.IdRep1 + "', '" + Venta.IdRep2 + "', '" + Venta.TipoEntregaId + "', '" + Venta.TipoPagoId + "', '" + Venta.CurrId + "', '" +
        //            Venta.VentaTotal.ToString().Replace(",", ".") + "', '" + Venta.Proveedor + "', '" + Venta.FechaOC.ToString("yyyy-MM-dd") + "', '" + Venta.FechaEntrega.ToString("yyyy-MM-dd") +
        //            "', '" + Venta.Descripcion + "', '" + Venta.SubIndustria + "', '" + Venta.IdAplicador + "')";

        //        res += RepositorioBase.EjecutarSQLComando(textSQL);

        //        res += RepositorioEquipo.insertarEquipos(Venta);


        //        if (res == 1) { MessageBox.Show("Estado de la oferta y repuestos actualizados"); }
        //        if (res == 2) { MessageBox.Show("Estado de la oferta y repuestos actualizados, y venta ingresada en tabla tbvsp"); }
        //        if (res > 2) { MessageBox.Show("Estado de la oferta, equipos y repuestos actualizados, y venta ingresada en tabla tbvsp"); }
        //    }
        //    catch (Exception e) { MessageBox.Show("No se pudo enviar a ventas por problemas de conexión al servidor. Intentelo de nuevo más tarde. Error: " + e); }
        //}

        //private static void cambiarEstado(Oferta Oferta, string estado, string que = "todas")
        //{
        //    try
        //    {
        //        string textSQL = "UPDATE tbosp SET estado = '" + estado + "', edicion = '" + DateTime.UtcNow.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss") + "' WHERE ncrm = '" + Oferta.NCRM + "' ";
        //        if (que == "rev") { textSQL += " AND rev = '" + Oferta.Rev + "' "; }
        //        textSQL += "; ";

        //        int res = RepositorioBase.EjecutarSQLComando(textSQL);

        //        if (res > 0) { MessageBox.Show("Estado de la oferta actualizado"); }
        //    }
        //    catch (Exception e) { MessageBox.Show("No se pudo enviar a ventas por problemas de conexión al servidor. Intentelo de nuevo más tarde. Error: " + e); }
        //}





        ///// 
        ///// UTILIDADES
        ///// 

        /////
        //public static void actualizarBoletas(double CBFC, double CBA, double CBCG, long IdActual)
        //{
        //    string textSQL = "UPDATE tbosp SET bfielcumplimiento = '" + Math.Round(CBFC, 3).ToString().Replace(",", ".") +
        //            "', badelanto = '" + Math.Round(CBA, 3).ToString().Replace(",", ".") +
        //            "', bcalidadygarantia = '" + Math.Round(CBCG, 3).ToString().Replace(",", ".") +
        //            "' WHERE id = '" + IdActual + "'";
        //    int res = RepositorioBase.EjecutarSQLComando(textSQL);
        //}

        ///// <summary>
        ///// Buscar las revisiones de Oferta.NCRM en la base de datos
        ///// </summary>
        ///// <returns>ListaRevisiones<Oferta></returns>
        //public static List<Oferta> buscar(string ncrm)
        //{
        //    string textSQL = "SELECT id, ncrm, rev FROM tbosp WHERE ncrm = '" + ncrm + "' ORDER BY rev ASC;";
        //    DataTable dtRevisiones = RepositorioBase.EjecutarSQL(textSQL);

        //    List<Oferta> ListaRevisiones = new List<Oferta>();

        //    foreach (DataRow dr in dtRevisiones.Rows)
        //    {
        //        Oferta oferta = new Oferta();
        //        oferta.Id = Convert.ToInt32(dr["id"].ToString());
        //        oferta.NCRM = dr["ncrm"].ToString();
        //        oferta.Rev = Convert.ToInt32(dr["rev"]);

        //        ListaRevisiones.Add(oferta);
        //    }
        //    return ListaRevisiones;
        //}

        ///// <summary>
        ///// Revisa si la oferta que se intenta de ingresar/eliminar existe o no
        ///// </summary>
        ///// <param name="Oferta"></param>
        ///// <returns>DataTable con las ofertas de la BBDD que tengan el mismo CRM</returns>
        //public static DataTable revisarSiExiste(Oferta Oferta)
        //{
        //    string textSQL = "SELECT id, idbu, ncrm, rev, estado FROM tbosp WHERE ncrm = '" + Oferta.NCRM + "';";
        //    DataTable dtSP = RepositorioBase.EjecutarSQL(textSQL);
        //    return dtSP;
        //}

        ///// <summary>
        ///// Trae los cambios de la ultima oferta (maxid)
        ///// </summary>
        ///// <param name="Id"></param>
        ///// <returns>ListaCambios</returns>
        //public static Oferta ultimasMonedas(int Id)
        //{
        //    string filtro = " (SELECT MAX(id) from tbosp) ";
        //    if (Id != 0) { filtro = Id.ToString(); }
        //    string textSQL = "SELECT eur, gbp, clp, brl, sol FROM tbosp WHERE id = " + filtro; // + IdActual;
        //    DataTable dtMonedas = RepositorioBase.EjecutarSQL(textSQL);
        //    Oferta ListaCambios = new Oferta();

        //    if (dtMonedas.Rows.Count > 0)
        //    {
        //        foreach (DataRow dr in dtMonedas.Rows)
        //        {
        //            if (dr["eur"] != DBNull.Value) { ListaCambios.EUR = Convert.ToDouble(dr["eur"]); }
        //            if (dr["gbp"] != DBNull.Value) { ListaCambios.GBP = Convert.ToDouble(dr["gbp"]); }
        //            if (dr["sol"] != DBNull.Value) { ListaCambios.PEN = Convert.ToDouble(dr["sol"]); }
        //            if (dr["clp"] != DBNull.Value) { ListaCambios.CLP = Convert.ToDouble(dr["clp"]); }
        //            if (dr["brl"] != DBNull.Value) { ListaCambios.BRL = Convert.ToDouble(dr["brl"]); }
        //        }
        //    }
        //    return ListaCambios;
        //}

        ///// <summary>
        ///// Actualiza los cambis de la moneda
        ///// </summary>
        ///// <param name="Id"></param>
        ///// <returns>ListaCambios</returns>
        //public static int actualizarMonedas(double EUR, double GBP, double CLP, double PEN, double BRL, double Id)
        //{
        //    NumberFormatInfo nfi = new NumberFormatInfo();
        //    nfi.NumberDecimalSeparator = ".";

        //    string textSQL = "UPDATE tbosp SET " +
        //        "eur = '" + EUR.ToString(nfi) + "', " +
        //        "gbp = '" + GBP.ToString(nfi) + "', " +
        //        "clp = '" + CLP.ToString(nfi) + "', " +
        //        "sol = '" + PEN.ToString(nfi) + "', " +
        //        "brl = '" + BRL.ToString(nfi) + "' " +
        //        " WHERE id = '" + Id + "'; ";

        //    textSQL.Replace(",", ".");
        //    textSQL.Replace("''", "NULL");

        //    int res = RepositorioBase.EjecutarSQLComando(textSQL);

        //    return res;
        //}

        ///// <summary>
        ///// Revisa si se está consolidando y traer las informaciones de FechaOC, FechaEntrega, OC
        ///// </summary>
        ///// <param name="Oferta"></param>
        ///// <returns></returns>
        //public static Oferta revisarSiConsolidando(Oferta Oferta)
        //{
        //    string textSQL = "Select fechaoc, fechaemisionoc, oc, fechaentrega, npv " +
        //            "From tbosp WHERE id = " + Oferta.Id;

        //    DataTable dtOferta = RepositorioBase.EjecutarSQL(textSQL);

        //    if (dtOferta.Rows.Count > 0)
        //    {
        //        foreach (DataRow dr in dtOferta.Rows)
        //        {
        //            if (dr["fechaoc"] != DBNull.Value) { Oferta.FechaOC = Convert.ToDateTime(dr["fechaoc"]); }
        //            if (dr["fechaemisionoc"] != DBNull.Value) { Oferta.FechaEmisionOC = Convert.ToDateTime(dr["fechaemisionoc"]); }
        //            if (dr["fechaentrega"] != DBNull.Value) { Oferta.FechaEntrega = Convert.ToDateTime(dr["fechaentrega"]); }
        //            if (dr["oc"] != DBNull.Value) { Oferta.OC = (dr["oc"]).ToString(); }
        //        }
        //    }

        //    return Oferta;
        //}

        #endregion RepositorioOfertas Repos


        #region Quitar de aqui? RepositorioEquipos

        //public static List<Equipo> baseInstalada(string Filtro = "0")
        //{
        //    List<Equipo> ListaEquipos = new List<Equipo>();
        //    List<Equipo> ListaEquiposTemp = new List<Equipo>();

        //    DataTable dtEquiposIns = new DataTable();
        //    string textSQL = "SELECT tbequipos.id as Id, nserie as NSerie, modelo as Modelo, refcliente as RefCliente, tbeu.planta as Planta, " +
        //        "tbeu.cliente as Cliente, tbeu.pais as Pais, tbeu.rut as Rut, modelodet as DetallesModelo, especificaciones as Especificaciones, " +
        //        "tbeu.ciudad as CiudadCliente, tbeu.direccion as DireccionEU, tbbu.id as IdBU, tbbu.acron as BU, tbbu.nombre as NombreBU, tbbu.pais as PaisBU, " +
        //        "tbbu.direccion as DireccionBU, tbbu.telefono as TelefonoBU, tbbu.ciudad as CiudadBU, tbsegmentos.industry as Industria, " +
        //        "tbbu.doc as BUDOC, tbbu.valordoc as ValorDOC, tbbu.curr as MonedaDOC, tbsegmentos.subindustry as SubIndustria, " +
        //        "tbsegmentos.reference as RefIndustria, tbsegmentos.market as Mercado, tbequiposcrm.idequipocrm as EquipoCRM, " +
        //        "tbequiposcrm.tipoequipo as TipoMaquina, tbequiposcrm.maquina as Maquina, tbequipos.familia as Familia, " +
        //        "tbequipos.contractno as NContrato, tbequipos.marca as Marca, tbeu.telefono as TelefonoEU, " +
        //        "tbequipos.estado as EstadoOperacion, tbequiposcrm.producto as Producto, tbinformaciones.descripcion as Proceso, " +
        //        "tbeu.direccionof as DireccionOf, tbeu.region as Region, tbeu.codigopostal as CPostal, tbeu.paginaweb as PWeb " +
        //        "FROM tbequipos " +
        //        "INNER JOIN tbeu ON tbeu.id = tbequipos.ideu " +
        //        "INNER JOIN tbbu ON tbbu.id = tbequipos.idbu " +
        //        "INNER JOIN tbsegmentos ON tbsegmentos.id = tbeu.idmercado " +
        //        "INNER JOIN tbequiposcrm ON tbequiposcrm.id = tbequipos.idcrm " +
        //        "LEFT JOIN tbinformaciones ON tbinformaciones.id = tbequipos.proceso " +
        //        "WHERE 1 = 1  ORDER BY cliente ASC";

        //    dtEquiposIns = RepositorioBase.EjecutarSQL(textSQL);

        //    foreach (DataRow dr in dtEquiposIns.Rows)
        //    {
        //        Equipo tabla = new Equipo();
        //        tabla.IdEquipo = Convert.ToInt32(dr["Id"].ToString());
        //        tabla.Planta = dr["Planta"].ToString();
        //        tabla.Cliente = dr["Cliente"].ToString();
        //        tabla.NSerie = dr["NSerie"].ToString();
        //        tabla.Modelo = dr["Modelo"].ToString();
        //        tabla.ModeloDet = dr["Modelo"].ToString() + dr["Especificaciones"].ToString();
        //        tabla.PaisEU = dr["Pais"].ToString();
        //        tabla.RutEU = dr["Rut"].ToString();
        //        tabla.TipoEquipo = dr["TipoMaquina"].ToString();
        //        tabla.Familia = dr["Familia"].ToString();
        //        tabla.Marca = dr["Marca"].ToString();
        //        tabla.NContrato = dr["NContrato"].ToString();
        //        tabla.EstadoOperacion = dr["EstadoOperacion"].ToString();
        //        /// tabla.AnoInstalacion = Convert.ToDateTime(dr["AnoInstalacion"]);
        //        tabla.Proceso = dr["Proceso"].ToString();
        //        tabla.Industria = dr["Industria"].ToString();
        //        tabla.Subindustria = dr["SubIndustria"].ToString();
        //        tabla.RefIndustria = dr["RefIndustria"].ToString();
        //        tabla.Mercado = dr["Mercado"].ToString();
        //        tabla.Producto = dr["Producto"].ToString();
        //        tabla.CiudadEU = dr["CiudadCliente"].ToString();
        //        tabla.DireccionEU = dr["DireccionEU"].ToString();
        //        tabla.DireccionOfEU = dr["DireccionOf"].ToString();
        //        tabla.RegionEU = dr["Region"].ToString();
        //        tabla.CPostalEU = dr["CPostal"].ToString();
        //        tabla.PWebEU = dr["PWeb"].ToString();
        //        tabla.TelefonoEU = dr["TelefonoEU"].ToString();
        //        tabla.EquiposCRM = dr["EquipoCRM"].ToString();
        //        tabla.Maquina = dr["Maquina"].ToString();
        //        tabla.RefCliente = dr["RefCliente"].ToString();
        //        tabla.IdBU = Convert.ToInt32(dr["IdBU"].ToString());
        //        tabla.AcronimoBU = dr["BU"].ToString();
        //        tabla.CiudadBU = dr["CiudadBU"].ToString();
        //        tabla.DireccionBU = dr["DireccionBU"].ToString();
        //        tabla.TelefonoBU = dr["TelefonoBU"].ToString();
        //        tabla.PaisBU = dr["PaisBU"].ToString();
        //        tabla.NombreBU = dr["NombreBU"].ToString();
        //        tabla.Documento = dr["BUDOC"].ToString() + ": " + dr["MonedaDOC"].ToString() + " " + dr["ValorDOC"].ToString();
        //        if (Filtro == "0") { ListaEquipos.Add(tabla); }
        //        if (Filtro == "1") { ListaEquiposTemp.Add(tabla); }
        //    }

        //    return ListaEquipos;
        //}

        ///// <summary>
        ///// Trae equipos linkeados al crear nueva revision
        ///// </summary>
        ///// <param name="Oferta"></param>
        ///// <param name="IdBase"></param>
        //public static void linkear(Oferta Oferta, int IdBase)
        //{
        //    string textSQLequipos = "SELECT * FROM tboequipos WHERE idofertasp = " + Oferta.Id;
        //    DataTable dtEquipos = RepositorioBase.EjecutarSQL(textSQLequipos);
        //    if (dtEquipos.Rows.Count == 0)
        //    {
        //        string textSQLequiposBase = "SELECT * FROM tboequipos WHERE idofertasp = " + IdBase;
        //        DataTable dtEquiposBase = RepositorioBase.EjecutarSQL(textSQLequiposBase);

        //        if (dtEquiposBase.Rows.Count > 0)
        //        {
        //            string textSQLinserteq = "INSERT INTO tboequipos (idofertasp, idequipo) VALUES ";

        //            for (int i = 0; i < dtEquiposBase.Rows.Count; i++)
        //            {
        //                string IdEquipo = dtEquiposBase.Rows[i]["idequipo"].ToString();

        //                textSQLinserteq = textSQLinserteq + "('" + Oferta.Id + "', '" + IdEquipo + "')";

        //                if (i != dtEquiposBase.Rows.Count - 1) { textSQLinserteq = textSQLinserteq + ", "; }
        //                else { textSQLinserteq = textSQLinserteq + ";"; }
        //            }
        //            string textSQLinsertnull = textSQLinserteq.Replace("''", "NULL");
        //            int res = RepositorioBase.EjecutarSQLComando(textSQLinsertnull);

        //            if (res <= 0) { MessageBox.Show("Algún error hubo trayendo los equipos linkeados"); }
        //        }
        //        else { MessageBox.Show("La revisión base no presenta ningún equipo linkeado"); }
        //    }
        //}

        //public static List<Equipo> actualizar(Oferta Oferta)
        //{
        //    string textSQL = "SELECT tboequipos.id, idofertasp, idequipo, tbequipos.modelo, tbequipos.nserie, tbequipos.refcliente " +
        //            "FROM tboequipos " +
        //            "LEFT JOIN tbequipos ON tboequipos.idequipo = tbequipos.id " +
        //            "WHERE idofertasp = '" + Oferta.Id + "';";

        //    DataTable dtequipos = RepositorioBase.EjecutarSQL(textSQL);
        //    List<Equipo> ListaEquipos = new List<Equipo>();
        //    foreach (DataRow dr in dtequipos.Rows)
        //    {
        //        Equipo equipo = new Equipo();
        //        equipo.Modelo = dr["modelo"].ToString();
        //        equipo.NSerie = dr["nserie"].ToString();
        //        equipo.RefCliente = dr["refcliente"].ToString();
        //        ListaEquipos.Add(equipo);
        //    }

        //    return ListaEquipos;
        //}

        ///// <summary>
        ///// Inserta en tbvequipos, equipos y npv de venta
        ///// </summary>
        ///// <param name="Venta"></param>
        ///// <returns></returns>
        //public static int insertarEquipos(Oferta Venta)
        //{
        //    int res = 0;
        //    string textSQL = "SELECT idofertasp, idofertasv, idequipo FROM tboequipos WHERE idofertasp = " + Venta.Id + ";";
        //    DataTable dtEquipos = RepositorioBase.EjecutarSQL(textSQL);

        //    foreach (DataRow dr in dtEquipos.Rows)
        //    {
        //        Equipo equipo = new Equipo();
        //        equipo.IdEquipo = (dr["idequipo"] != DBNull.Value) ? Convert.ToInt32(dr["idequipo"].ToString()) : 0;
        //        textSQL = "INSERT INTO tbvequipo (idequipo, idvsp, idvsv) VALUES ('" + equipo.IdEquipo + "', '" + Venta.NPV + "', NULL)";
        //        res += RepositorioBase.EjecutarSQLComando(textSQL);
        //    }

        //    return res;
        //}


        //public static List<Equipo> Productos()
        //{
        //    string textSQLj = "SELECT id, idequipocrm, tipoequipo, producto FROM tbequiposcrm ORDER BY tipoequipo ASC ";
        //    DataTable dtProducto = RepositorioBase.EjecutarSQL(textSQLj);
        //    List<Equipo> ListaProducto = new List<Equipo>();
        //    foreach (DataRow dr in dtProducto.Rows)
        //    {
        //        Equipo categoria = new Equipo();
        //        categoria.Id = Convert.ToInt32(dr["id"].ToString());
        //        categoria.TipoEquipo = dr["tipoequipo"].ToString();
        //        categoria.EquiposCRM = dr["idequipocrm"].ToString();
        //        categoria.Producto = dr["producto"].ToString() + " (" + dr["idequipocrm"].ToString() + ")";
        //        categoria.Maquina = dr["tipoequipo"].ToString() + " - " + dr["producto"].ToString() + " (" + dr["idequipocrm"].ToString() + ")";
        //        ListaProducto.Add(categoria);
        //    }
        //    return ListaProducto;
        //}
        #endregion


        #region Eliminar? RepositorioRepuestos

        ///// <summary>
        ///// Querys para informacion de Repuestos
        ///// </summary>
        ///// <returns>DataTable Clientes&Vendors</returns>
        //public static DataTable tablaRepuestos(string cuanto, int filtro = 0)
        //{

        //    DataTable dtRepuestos = new DataTable();
        //    string textSQL = "SELECT tbrepuestos.id as Id, tbrepuestos.descripcion as Descripcion, nparte as NParte, tbrepuestos.qty as Qty, " +
        //            "costounit, ventaunit, drw, drwitem, hscode, tbrepuestos.comentarios as ComentarioSP, tbrepuestos.refcliente as RefClienteSP, " +
        //            "tbrepuestos.gm as GM, plazoentrega, plazoentrega, part,  tbrepuestos.spcurr as CurrId, ocurr.descripcion as CurrVenta, tbrepuestos.nsp, tbrepuestos.idosp ";


        //    if (cuanto == "normal")
        //    {
        //        textSQL += " FROM tbrepuestos " +
        //          "INNER JOIN tbinformaciones AS ocurr on tbrepuestos.spcurr = ocurr.id " +
        //          "WHERE idosp = '" + OSP.Oferta.Id + "';";
        //    }
        //    else if (cuanto == "full")
        //    {
        //        textSQL += ", tbvsp.idcliente as IdClienteVenta, tbvsp.idvendor as IdVendorVenta, tbvsp.id as Idventa, tbvsp.crm as NCRMVenta, tbvsp.pv as PV, " +
        //            "entregavt.descripcion as EntregaVenta, tbosp.idcliente as IdClienteOferta, tbosp.id, tbosp.idrep1, " +
        //            "tbosp.idvendor as IdVendorOferta, tbosp.ncrm as NCRMOferta, ocurr.descripcion as CurrOferta, entregaof.descripcion as EntregaOferta, " +
        //            "veu.planta as PlantaClienteVenta, veu.cliente as ClienteVenta, veu.pais as PaisClienteVenta, " +
        //            "vvendor.cliente as VendorVenta, vvendor.pais as PaisVendorVenta, tbequipos.modelo as ModelosVenta, oequipo.modelo as ModelosOferta, " +
        //            "tbrepuestos.idvsp as IdVenta, oeu.planta as PlantaClienteOferta, oeu.cliente as ClienteOferta, " +
        //            "oeu.pais as PaisClienteOferta, ovendor.cliente as VendorOferta, ovendor.pais as PaisVendorOferta  " +
        //            "From tbrepuestos " +
        //            "LEFT JOIN tbvsp ON tbvsp.pv = tbrepuestos.idvsp " +
        //            "LEFT JOIN tbosp ON tbosp.id = tbrepuestos.idosp " +
        //            "LEFT JOIN tbeu AS oeu ON oeu.id = tbosp.idcliente " +
        //            "LEFT JOIN tbeu AS veu ON veu.id = tbvsp.idcliente " +
        //            "LEFT JOIN tbvendor AS orep ON orep.id = tbosp.idrep1 " +
        //            "LEFT JOIN tbvendor AS ovendor ON ovendor.id = tbosp.idvendor " +
        //            "LEFT JOIN tbvendor AS vvendor ON vvendor.id = tbvsp.idvendor " +
        //            "LEFT JOIN tboequipos ON tboequipos.idofertasp = tbosp.id " +
        //            "LEFT JOIN tbvequipo ON tbvequipo.idvsp = tbvsp.pv " +
        //            "LEFT JOIN tbequipos ON tbequipos.id = tbvequipo.idequipo " +
        //            "LEFT JOIN tbequipos AS oequipo ON oequipo.id = tboequipos.idequipo " +
        //            "LEFT JOIN tbinformaciones AS ocurr ON ocurr.id = tbrepuestos.spcurr " +
        //            "LEFT JOIN tbinformaciones AS entregaof ON entregaof.id = tbosp.entrega " +
        //            "LEFT JOIN tbinformaciones AS entregavt ON entregavt.id = tbvsp.entrega ";

        //        if (filtro > 0) { textSQL += " WHERE tbosp.id = '" + filtro + "'; "; }
        //    }

        //    dtRepuestos = RepositorioBase.EjecutarSQL(textSQL);

        //    return dtRepuestos;
        //}

        ///// <summary>
        ///// Transforma DataTable OfertasFull en ListaOfertas<cOferta>
        ///// </summary>
        ///// <returns>ListaOfertas<cOferta></returns>
        //public static List<Repuesto> listaRepuestos(string cuanto, int filtro = 0)
        //{
        //    DataTable dtRepuestos = tablaRepuestos(cuanto, filtro);

        //    List<Repuesto> ListaRepuestos = new List<Repuesto>();

        //    foreach (DataRow dr in dtRepuestos.Rows)
        //    {
        //        Repuesto repuesto = new Repuesto();
        //        repuesto.Id = Convert.ToInt32(dr["Id"].ToString());
        //        repuesto.IdOSP = (dr["idosp"] != DBNull.Value) ? Convert.ToInt32(dr["idosp"]) : 0;
        //        repuesto.NParte = dr["NParte"].ToString();
        //        repuesto.NSP = (dr["nsp"] != DBNull.Value) ? Convert.ToInt32(dr["nsp"]) : Convert.ToInt32(dtRepuestos.Rows.IndexOf(dr)) + 1;
        //        repuesto.Descripcion = dr["Descripcion"].ToString();
        //        repuesto.HSCode = dr["hscode"].ToString();
        //        repuesto.Drw = dr["drw"].ToString();
        //        repuesto.DrwItem = dr["drwitem"].ToString();
        //        repuesto.Qty = float.Parse(dr["Qty"].ToString());
        //        repuesto.CostoUnit = float.Parse(dr["costounit"].ToString());
        //        repuesto.VentaUnit = float.Parse(dr["ventaunit"].ToString());
        //        repuesto.Comentarios = dr["ComentarioSP"].ToString();
        //        repuesto.RefCliente = dr["RefClienteSP"].ToString();
        //        repuesto.GMUnit = float.Parse(dr["GM"].ToString()) / 100;
        //        repuesto.CurrId = Convert.ToInt32(dr["CurrId"].ToString());

        //        repuesto.Tipo = "SP";

        //        if (cuanto == "normal")
        //        {
        //            repuesto.Curr = dr["CurrVenta"].ToString();
        //            repuesto.PlazoEntrega = Convert.ToInt32(dr["plazoentrega"].ToString());
        //            repuesto.PartUnit = Convert.ToDouble(dr["part"].ToString());
        //            ListaRepuestos.Add(repuesto);
        //        }
        //        else if (cuanto == "full")
        //        {
        //            repuesto.Moneda = dr["CurrOferta"].ToString();
        //            if (dr["IdVenta"].ToString() != "")
        //            {
        //                repuesto.NCRM = dr["NCRMVenta"].ToString();
        //                repuesto.TipoEntrega = dr["EntregaVenta"].ToString();
        //                repuesto.PV = dr["PV"].ToString();
        //                repuesto.Modelo = dr["ModelosVenta"].ToString();
        //                if (dr["IdClienteVenta"].ToString() != "" && dr["IdVendorVenta"].ToString() == "") { repuesto.Cliente = dr["ClienteVenta"].ToString() + " - " + dr["PlantaClienteVenta"].ToString(); }
        //                else if (dr["IdClienteVenta"].ToString() == "" && dr["IdVendorVenta"].ToString() != "") { repuesto.Cliente = dr["VendorVenta"].ToString(); }
        //                else if (dr["IdClienteVenta"].ToString() != "" && dr["IdVendorVenta"].ToString() != "") { repuesto.Cliente = dr["ClienteVenta"].ToString() + " - " + dr["PlantaClienteVenta"].ToString() + " (por " + dr["VendorVenta"].ToString() + ")"; }
        //            }
        //            else
        //            {
        //                repuesto.NCRM = dr["NCRMOferta"].ToString();
        //                repuesto.TipoEntrega = dr["EntregaOferta"].ToString();
        //                repuesto.PV = "N/A";
        //                repuesto.Modelo = dr["ModelosOferta"].ToString();
        //                if (dr["IdClienteOferta"].ToString() != "" && dr["IdVendorOferta"].ToString() == "") { repuesto.Cliente = dr["ClienteOferta"].ToString() + " - " + dr["PlantaClienteOferta"].ToString(); }
        //                else if (dr["IdClienteOferta"].ToString() == "" && dr["IdVendorOferta"].ToString() != "") { repuesto.Cliente = dr["VendorOferta"].ToString(); }
        //                else if (dr["IdClienteOferta"].ToString() != "" && dr["IdVendorOferta"].ToString() != "") { repuesto.Cliente = dr["ClienteOferta"].ToString() + " - " + dr["PlantaClienteOferta"].ToString() + " (por " + dr["VendorOferta"].ToString() + ")"; }
        //            }

        //            if (repuesto.IdOSP != OSP.Oferta.Id) { ListaRepuestos.Add(repuesto); }
        //        }
        //    }

        //    return ListaRepuestos;
        //}

        ///// <summary>
        ///// Querys para informacion de OfertasFull
        ///// </summary>
        ///// <returns>DataTable Clientes&Vendors</returns>
        //public static DataTable tablaServicio()
        //{
        //    DataTable dtServicios = new DataTable();
        //    string textSQL = "SELECT tbservicios.id, tbservicios.descripcion, costosv, ventasv, tipo, " +
        //        "tbinformaciones.descripcion as currsp, tbservicios.curr AS CurrId, tbservicios.nsp " +
        //        "FROM tbservicios " +
        //        "INNER JOIN tbinformaciones on tbservicios.curr = tbinformaciones.id " +
        //        "WHERE idosp = '" + OSP.Oferta.Id + "';";
        //    dtServicios = RepositorioBase.EjecutarSQL(textSQL);

        //    return dtServicios;
        //}

        ///// <summary>
        ///// Transforma DataTable OfertasFull en ListaOfertas<cOfertas>
        ///// </summary>
        ///// <returns>ListaOfertas<cOfertas></returns>
        //public static List<Repuesto> listaServicios()
        //{
        //    DataTable dtServicios = tablaServicio();

        //    List<Repuesto> ListaServicios = new List<Repuesto>();

        //    foreach (DataRow dr in dtServicios.Rows)
        //    {
        //        Repuesto rep = new Repuesto();
        //        rep.Id = Convert.ToInt32(dr["id"].ToString());
        //        rep.NSP = (dr["nsp"] != DBNull.Value) ? Convert.ToInt32(dr["nsp"]) : Convert.ToInt32(dtServicios.Rows.IndexOf(dr)) + 1;
        //        rep.Curr = dr["currsp"].ToString();
        //        rep.CurrId = Convert.ToInt32(dr["CurrId"].ToString());
        //        rep.TipoSV = dr["tipo"].ToString();
        //        rep.Qty = 1;
        //        if (!string.IsNullOrEmpty(dr["costosv"].ToString())) { rep.CostoUnit = Convert.ToDouble(dr["costosv"].ToString()); }
        //        if (!string.IsNullOrEmpty(dr["ventasv"].ToString())) { rep.VentaUnit = Convert.ToDouble(dr["ventasv"].ToString()); }
        //        rep.Descripcion = dr["descripcion"].ToString();

        //        rep.Tipo = "SV";

        //        ListaServicios.Add(rep);
        //    }

        //    return ListaServicios;
        //}

        //public static int insertarRepuesto(Repuesto repuesto, long idActual)
        //{
        //    ///Cambia separador de decimal, para agregar a BBDD
        //    NumberFormatInfo nfi = new NumberFormatInfo();
        //    nfi.NumberDecimalSeparator = ".";

        //    try
        //    {
        //        string textSQL = "INSERT INTO tbrepuestos (idosp, descripcion, nparte, drw, drwitem, hscode, qty, costounit, comentarios, spcurr, plazoentrega, nsp) VALUES ('" + idActual + "', '" +
        //            repuesto.Descripcion + "', '" + repuesto.NParte + "', '" + repuesto.Drw + "', '" + repuesto.DrwItem + "', '" + repuesto.HSCode + "', '" + repuesto.Qty.ToString(nfi) + "', '" +
        //             repuesto.CostoUnit.ToString(nfi) + "', '" + repuesto.Comentarios + "', '" + repuesto.CurrId + "', '" + repuesto.PlazoEntrega + "', '" + repuesto.NSP + "'); select last_insert_rowid();";
        //        textSQL.Replace("''", "NULL");
        //        long res = RepositorioBase.EjecutarSQLScalar(textSQL);

        //        return (int)res;
        //    }
        //    catch (Exception ex) { MessageBox.Show("Se presentó algún error en la conexión a la base de datos. Intentelo de nuevo. Error: " + ex); return -1; };
        //}

        //public static int insertarServicio(Repuesto servicio, long idActual)
        //{
        //    ///Cambia separador de decimal, para agregar a BBDD
        //    NumberFormatInfo nfi = new NumberFormatInfo();
        //    nfi.NumberDecimalSeparator = ".";

        //    try
        //    {
        //        string textSQL = "INSERT INTO tbservicios (idosp, descripcion, descripcionsv, tipo, ntecnicos, costohh, dhabil, dsabado, ddomingo, hextra, " +
        //        "hentrenamiento, hcapacitacion, hmmooq, hmmooc, hhingq, hhingc, movq, movc, pasajesq, pasajesc, docq, docc, autoq, autoc, alojamientoq, alojamientoc, " +
        //        "alimentacionq, alimentacionc, trasladoq, trasladoc, apsq, apsc, whq, whc, otro1d, otro1q, otro1c, otro2d, otro2q, otro2c, curr, costosv) VALUES ('" +
        //        idActual + "', '" + servicio.Descripcion + "', '" + servicio.DescripcionSV + "', '" + servicio.TipoSV + "', '" + servicio.NTecnicos + "', '" +
        //        servicio.CostoHH.ToString().Replace(",", ".") + "', '" + servicio.DiasHabiles + "', '" + servicio.DiasSabado + "', '" + servicio.DiasDomingo + "', '" + servicio.HHExtra + "', '" +
        //        servicio.HHEntrenamiento + "', '" + servicio.HHCapacitacion + "', '" + servicio.HMOQty + "', '" + servicio.HMOCosto.ToString().Replace(",", ".") + "', '" + servicio.HIngQty + "', '" +
        //        servicio.HIngCosto.ToString().Replace(",", ".") + "', '" + servicio.MovQty + "', '" + servicio.MovCosto.ToString().Replace(",", ".") + "', '" + servicio.PasajesQty + "', '" + servicio.PasajeCosto.ToString().Replace(",", ".") + "', '" +
        //        servicio.DocQty + "', '" + servicio.DocCosto + "', '" + servicio.CarroQty + "', '" + servicio.CarroCosto.ToString().Replace(",", ".") + "', '" + servicio.AlojamientoQty + "', '" +
        //        servicio.AlojamientoCosto.ToString().Replace(",", ".") + "', '" + servicio.AlimentacionQty + "', '" + servicio.AlimentacionCosto.ToString().Replace(",", ".") + "', '" + servicio.TrasladoQty + "', '" + servicio.TrasladoCosto.ToString().Replace(",", ".") + "', '" +
        //        servicio.APSQty + "', '" + servicio.APSCosto.ToString().Replace(",", ".") + "', '" + servicio.WHQty + "', '" + servicio.WHCosto.ToString().Replace(",", ".") + "', '" + servicio.Otro1Desc + "', '" + servicio.Otro1Qty + "', '" +
        //        servicio.Otro1Costo.ToString().Replace(",", ".") + "', '" + servicio.Otro2Desc + "', '" + servicio.Otro2Qty + "', '" + servicio.Otro2Costo.ToString().Replace(",", ".") + "', '" + servicio.CurrId + "', '" + servicio.CostoTotal.ToString().Replace(",", ".") + "'); " +
        //        "select last_insert_rowid();";
        //        textSQL.Replace("''", "NULL");
        //        long res = RepositorioBase.EjecutarSQLScalar(textSQL);

        //        return (int)res;
        //    }
        //    catch (Exception ex) { MessageBox.Show("Se presentó algún error en la conexión a la base de datos. Intentelo de nuevo. Error: " + ex); return -1; };
        //}

        //public static void insertarRepuestosRevBase(Oferta Oferta, int IdBase)
        //{
        //    string textSQLrep = "SELECT * FROM tbrepuestos WHERE idosp = " + Oferta.Id;
        //    DataTable dtRepuestos = RepositorioBase.EjecutarSQL(textSQLrep);
        //    if (dtRepuestos.Rows.Count == 0)
        //    {
        //        string textSQLrepbase = "SELECT * FROM tbrepuestos WHERE idosp = " + IdBase;
        //        DataTable dtRepuestosBase = RepositorioBase.EjecutarSQL(textSQLrepbase);

        //        if (dtRepuestosBase.Rows.Count > 0)
        //        {
        //            string textSQLinsert = "INSERT INTO tbrepuestos (descripcion, nparte, idosp, spcurr, qty, costounit, ventaunit, gm, drw, drwitem, hscode, comentarios, refcliente, plazoentrega, nsp) VALUES ";

        //            for (int i = 0; i < dtRepuestosBase.Rows.Count; i++)
        //            {
        //                string desc = dtRepuestosBase.Rows[i]["descripcion"].ToString();
        //                string nparte = dtRepuestosBase.Rows[i]["nparte"].ToString();
        //                double qty = Convert.ToDouble(dtRepuestosBase.Rows[i]["qty"]);
        //                int nsp = (dtRepuestosBase.Rows[i]["nsp"] != DBNull.Value) ? Convert.ToInt32(dtRepuestosBase.Rows[i]["nsp"]) : 0;
        //                double costounit = Convert.ToDouble(dtRepuestosBase.Rows[i]["costounit"]);
        //                double ventaunit = Convert.ToDouble(dtRepuestosBase.Rows[i]["ventaunit"]);
        //                double gm = Convert.ToDouble(dtRepuestosBase.Rows[i]["gm"]);
        //                string drw = dtRepuestosBase.Rows[i]["drw"].ToString();
        //                string drwitem = dtRepuestosBase.Rows[i]["drwitem"].ToString();
        //                string hscode = dtRepuestosBase.Rows[i]["hscode"].ToString();
        //                string comentario = dtRepuestosBase.Rows[i]["comentarios"].ToString();
        //                string refcliente = dtRepuestosBase.Rows[i]["refcliente"].ToString();
        //                string spcurr = dtRepuestosBase.Rows[i]["spcurr"].ToString();
        //                string plazo = dtRepuestosBase.Rows[i]["plazoentrega"].ToString();
        //                string qtyuni = "";
        //                string costouni = "";
        //                string ventauni = "";
        //                string gmuni = "";

        //                NumberFormatInfo nfi = new NumberFormatInfo();
        //                nfi.NumberDecimalSeparator = ".";

        //                if (qty.ToString() == "") { qtyuni = null; }
        //                else { qtyuni = Math.Round(qty, 2).ToString(nfi); };
        //                if (costounit.ToString() == "") { costouni = null; }
        //                else { costouni = Math.Round(costounit, 2).ToString(nfi); };
        //                if (ventaunit.ToString() == "") { ventauni = null; }
        //                else { ventauni = Math.Round(ventaunit, 2).ToString(nfi); };
        //                if (gm.ToString() == "") { gmuni = null; }
        //                else { gmuni = Math.Round(gm, 4).ToString(nfi); };


        //                textSQLinsert = textSQLinsert + "('" + desc + "', '" + nparte + "', '" + Oferta.Id + "', '" + spcurr + "', '" + qtyuni + "', '" + costouni + "', '" +
        //                    ventauni + "', '" + gmuni + "', '" + drw + "', '" + drwitem + "', '" + hscode + "', '" + comentario + "', '" + refcliente + "', '" + plazo + "', '" + nsp + "')";
        //                if (i != dtRepuestosBase.Rows.Count - 1) { textSQLinsert = textSQLinsert + ", "; }
        //                else { textSQLinsert = textSQLinsert + ";"; }
        //            }
        //            string textSQLinsertnull = textSQLinsert.Replace("''", "NULL");
        //            int res = RepositorioBase.EjecutarSQLComando(textSQLinsertnull);
        //        }
        //    }
        //}

        //public static void insertarServiciosRevBase(Oferta Oferta, int IdBase)
        //{
        //    string textSQLrep = "SELECT * FROM tbservicios WHERE idosp = " + Oferta.Id;
        //    DataTable dtServicios = RepositorioBase.EjecutarSQL(textSQLrep);

        //    if (dtServicios.Rows.Count == 0)
        //    {
        //        string textSQLrepbase = "SELECT * FROM tbservicios WHERE idosp = " + IdBase;
        //        DataTable dtServiciosBase = RepositorioBase.EjecutarSQL(textSQLrepbase);

        //        if (dtServiciosBase.Rows.Count > 0)
        //        {
        //            string textSQLinsert = "INSERT INTO tbservicios (descripcion, idosp, tipo, descripcionsv, ntecnicos, costohh, ventahh, dhabil, dsabado, ddomingo, hextra, hentrenamiento, hcapacitacion, " +
        //            "hmmooq, hmmooc, hhingq, hhingc, movq, movc, pasajesq, pasajesc, docq, docc, autoq, autoc, alojamientoq, alojamientoc, alimentacionq, alimentacionc, trasladoq, trasladoc, " +
        //            "apsq, apsc, whq, whc, otro1q, otro1c, otro1d, otro2q, otro2c, otro2d, curr, costosv, ventasv) VALUES ";

        //            for (int i = 0; i < dtServiciosBase.Rows.Count; i++)
        //            {
        //                NumberFormatInfo nfi = new NumberFormatInfo();
        //                nfi.NumberDecimalSeparator = ".";

        //                string descripcion = dtServiciosBase.Rows[i]["descripcion"].ToString();
        //                string tipo = dtServiciosBase.Rows[i]["tipo"].ToString();
        //                string descripcionsv = dtServiciosBase.Rows[i]["descripcionsv"].ToString();
        //                string ntecnicos = (dtServiciosBase.Rows[i]["ntecnicos"] != DBNull.Value) ? Math.Round(Convert.ToDouble(dtServiciosBase.Rows[i]["ntecnicos"]), 2).ToString(nfi) : "0";
        //                string costohh = (dtServiciosBase.Rows[i]["costohh"] != DBNull.Value) ? Math.Round(Convert.ToDouble(dtServiciosBase.Rows[i]["costohh"]), 2).ToString(nfi) : "0";
        //                string ventahh = (dtServiciosBase.Rows[i]["ventahh"] != DBNull.Value) ? Math.Round(Convert.ToDouble(dtServiciosBase.Rows[i]["ventahh"]), 2).ToString(nfi) : "0";
        //                string dhabil = (dtServiciosBase.Rows[i]["dhabil"] != DBNull.Value) ? Math.Round(Convert.ToDouble(dtServiciosBase.Rows[i]["dhabil"]), 2).ToString(nfi) : "0";
        //                string dsabado = (dtServiciosBase.Rows[i]["dsabado"] != DBNull.Value) ? Math.Round(Convert.ToDouble(dtServiciosBase.Rows[i]["dsabado"]), 2).ToString(nfi) : "0";
        //                string ddomingo = (dtServiciosBase.Rows[i]["ddomingo"] != DBNull.Value) ? Math.Round(Convert.ToDouble(dtServiciosBase.Rows[i]["ddomingo"]), 2).ToString(nfi) : "0";
        //                string hextra = (dtServiciosBase.Rows[i]["hextra"] != DBNull.Value) ? Math.Round(Convert.ToDouble(dtServiciosBase.Rows[i]["hextra"]), 2).ToString(nfi) : "0";
        //                string hentrenamiento = (dtServiciosBase.Rows[i]["hentrenamiento"] != DBNull.Value) ? Math.Round(Convert.ToDouble(dtServiciosBase.Rows[i]["hentrenamiento"]), 2).ToString(nfi) : "0";
        //                string hcapacitacion = (dtServiciosBase.Rows[i]["hcapacitacion"] != DBNull.Value) ? Math.Round(Convert.ToDouble(dtServiciosBase.Rows[i]["hcapacitacion"]), 2).ToString(nfi) : "0";
        //                string hmmooq = (dtServiciosBase.Rows[i]["hmmooq"] != DBNull.Value) ? Math.Round(Convert.ToDouble(dtServiciosBase.Rows[i]["hmmooq"]), 2).ToString(nfi) : "0";
        //                string hmmooc = (dtServiciosBase.Rows[i]["hmmooc"] != DBNull.Value) ? Math.Round(Convert.ToDouble(dtServiciosBase.Rows[i]["hmmooc"]), 2).ToString(nfi) : "0";
        //                string hhingq = (dtServiciosBase.Rows[i]["hhingq"] != DBNull.Value) ? Math.Round(Convert.ToDouble(dtServiciosBase.Rows[i]["hhingq"]), 2).ToString(nfi) : "0";
        //                string hhingc = (dtServiciosBase.Rows[i]["hhingc"] != DBNull.Value) ? Math.Round(Convert.ToDouble(dtServiciosBase.Rows[i]["hhingc"]), 2).ToString(nfi) : "0";
        //                string movq = (dtServiciosBase.Rows[i]["movq"] != DBNull.Value) ? Math.Round(Convert.ToDouble(dtServiciosBase.Rows[i]["movq"]), 2).ToString(nfi) : "0";
        //                string movc = (dtServiciosBase.Rows[i]["movc"] != DBNull.Value) ? Math.Round(Convert.ToDouble(dtServiciosBase.Rows[i]["movc"]), 2).ToString(nfi) : "0";
        //                string pasajesq = (dtServiciosBase.Rows[i]["pasajesq"] != DBNull.Value) ? Math.Round(Convert.ToDouble(dtServiciosBase.Rows[i]["pasajesq"]), 2).ToString(nfi) : "0";
        //                string pasajesc = (dtServiciosBase.Rows[i]["pasajesc"] != DBNull.Value) ? Math.Round(Convert.ToDouble(dtServiciosBase.Rows[i]["pasajesc"]), 2).ToString(nfi) : "0";
        //                string docq = (dtServiciosBase.Rows[i]["docq"] != DBNull.Value) ? Math.Round(Convert.ToDouble(dtServiciosBase.Rows[i]["docq"]), 2).ToString(nfi) : "0";
        //                string docc = (dtServiciosBase.Rows[i]["docc"] != DBNull.Value) ? Math.Round(Convert.ToDouble(dtServiciosBase.Rows[i]["docc"]), 2).ToString(nfi) : "0";
        //                string autoq = (dtServiciosBase.Rows[i]["autoq"] != DBNull.Value) ? Math.Round(Convert.ToDouble(dtServiciosBase.Rows[i]["autoq"]), 2).ToString(nfi) : "0";
        //                string autoc = (dtServiciosBase.Rows[i]["autoc"] != DBNull.Value) ? Math.Round(Convert.ToDouble(dtServiciosBase.Rows[i]["autoc"]), 2).ToString(nfi) : "0";
        //                string alojamientoq = (dtServiciosBase.Rows[i]["alojamientoq"] != DBNull.Value) ? Math.Round(Convert.ToDouble(dtServiciosBase.Rows[i]["alojamientoq"]), 2).ToString(nfi) : "0";
        //                string alojamientoc = (dtServiciosBase.Rows[i]["alojamientoc"] != DBNull.Value) ? Math.Round(Convert.ToDouble(dtServiciosBase.Rows[i]["alojamientoc"]), 2).ToString(nfi) : "0";
        //                string alimentacionq = (dtServiciosBase.Rows[i]["alimentacionq"] != DBNull.Value) ? Math.Round(Convert.ToDouble(dtServiciosBase.Rows[i]["alimentacionq"]), 2).ToString(nfi) : "0";
        //                string alimentacionc = (dtServiciosBase.Rows[i]["alimentacionc"] != DBNull.Value) ? Math.Round(Convert.ToDouble(dtServiciosBase.Rows[i]["alimentacionc"]), 2).ToString(nfi) : "0";
        //                string trasladoq = (dtServiciosBase.Rows[i]["trasladoq"] != DBNull.Value) ? Math.Round(Convert.ToDouble(dtServiciosBase.Rows[i]["trasladoq"]), 2).ToString(nfi) : "0";
        //                string trasladoc = (dtServiciosBase.Rows[i]["trasladoc"] != DBNull.Value) ? Math.Round(Convert.ToDouble(dtServiciosBase.Rows[i]["trasladoc"]), 2).ToString(nfi) : "0";
        //                string apsq = (dtServiciosBase.Rows[i]["apsq"] != DBNull.Value) ? Math.Round(Convert.ToDouble(dtServiciosBase.Rows[i]["apsq"]), 2).ToString(nfi) : "0";
        //                string apsc = (dtServiciosBase.Rows[i]["apsc"] != DBNull.Value) ? Math.Round(Convert.ToDouble(dtServiciosBase.Rows[i]["apsc"]), 2).ToString(nfi) : "0";
        //                string whq = (dtServiciosBase.Rows[i]["whq"] != DBNull.Value) ? Math.Round(Convert.ToDouble(dtServiciosBase.Rows[i]["whq"]), 2).ToString(nfi) : "0";
        //                string whc = (dtServiciosBase.Rows[i]["whc"] != DBNull.Value) ? Math.Round(Convert.ToDouble(dtServiciosBase.Rows[i]["whc"]), 2).ToString(nfi) : "0";
        //                string otro1d = (dtServiciosBase.Rows[i]["otro1d"] != DBNull.Value) ? Math.Round(Convert.ToDouble(dtServiciosBase.Rows[i]["otro1d"]), 2).ToString(nfi) : "0";
        //                string otro1q = (dtServiciosBase.Rows[i]["otro1q"] != DBNull.Value) ? Math.Round(Convert.ToDouble(dtServiciosBase.Rows[i]["otro1q"]), 2).ToString(nfi) : "0";
        //                string otro1c = (dtServiciosBase.Rows[i]["otro1c"] != DBNull.Value) ? Math.Round(Convert.ToDouble(dtServiciosBase.Rows[i]["otro1c"]), 2).ToString(nfi) : "NULL";
        //                string otro2d = (dtServiciosBase.Rows[i]["otro2d"] != DBNull.Value) ? Math.Round(Convert.ToDouble(dtServiciosBase.Rows[i]["otro2d"]), 2).ToString(nfi) : "0";
        //                string otro2q = (dtServiciosBase.Rows[i]["otro2q"] != DBNull.Value) ? Math.Round(Convert.ToDouble(dtServiciosBase.Rows[i]["otro2q"]), 2).ToString(nfi) : "0";
        //                string otro2c = (dtServiciosBase.Rows[i]["otro2c"] != DBNull.Value) ? Math.Round(Convert.ToDouble(dtServiciosBase.Rows[i]["otro2c"]), 2).ToString(nfi) : "NULL";
        //                string curr = (dtServiciosBase.Rows[i]["curr"] != DBNull.Value) ? Math.Round(Convert.ToDouble(dtServiciosBase.Rows[i]["curr"]), 2).ToString(nfi) : "0";
        //                string costosv = (dtServiciosBase.Rows[i]["costosv"] != DBNull.Value) ? Math.Round(Convert.ToDouble(dtServiciosBase.Rows[i]["costosv"]), 2).ToString(nfi) : "0";
        //                string ventasv = (dtServiciosBase.Rows[i]["ventasv"] != DBNull.Value) ? Math.Round(Convert.ToDouble(dtServiciosBase.Rows[i]["ventasv"]), 2).ToString(nfi) : "0";


        //                textSQLinsert += "('" + descripcion + "', '" + Oferta.Id + "', '" + tipo + "', '" + descripcionsv + "', '" + ntecnicos + "', '" + costohh + "', '" +
        //                    ventahh + "', '" + dhabil + "', '" + dsabado + "', '" + ddomingo + "', '" + hextra + "', '" + hentrenamiento + "', '" + hcapacitacion + "', '" + hmmooq + "', '" +
        //                    hmmooc + "', '" + hhingq + "', '" + hhingc + "', '" + movq + "', '" + movc + "', '" + pasajesq + "', '" + pasajesc + "', '" + docq + "', '" + docc + "', '" + autoq + "', '" +
        //                    autoc + "', '" + alojamientoq + "', '" + alojamientoc + "', '" + alimentacionq + "', '" + alimentacionc + "', '" + trasladoq + "', '" + trasladoc + "', '" + apsq + "', '" + apsc + "', '" + whq + "', '" + whc + "', '" + otro1q + "', '" +
        //                    otro1c + "', '" + otro1d + "', '" + otro2q + "', '" + otro2c + "', '" + otro2d + "', '" + curr + "', '" + costosv + "', '" + ventasv + "')";

        //                if (i != dtServiciosBase.Rows.Count - 1) { textSQLinsert = textSQLinsert + ", "; }
        //                else { textSQLinsert = textSQLinsert + ";"; }
        //            }
        //            string textSQLinsertnull = textSQLinsert.Replace("''", "NULL");
        //            int res = RepositorioBase.EjecutarSQLComando(textSQLinsertnull);
        //        }
        //    }
        //}

        //public static int guardarRepuestos(List<Repuesto> ListaRepuestos, Oferta Oferta)
        //{
        //    int res = 0;

        //    foreach (Repuesto osp in ListaRepuestos)
        //    {
        //        string textSQL = "";
        //        if (osp.TipoSV != null && osp.TipoSV != "")
        //        {
        //            textSQL = "UPDATE tbservicios " +
        //                "SET " +
        //                "descripcion = '" + osp.Descripcion + "', " +
        //                "costosv = '" + osp.CostoTotal.ToString("0.00", CultureInfo.CreateSpecificCulture("en-US")) + "', " +
        //                "ventasv = '" + osp.VentaTotal.ToString("0.00", CultureInfo.CreateSpecificCulture("en-US")) + "', " +
        //                "nsp = '" + osp.NSP + "', " +
        //                "curr = '" + osp.CurrId + "' " +
        //                "WHERE idosp = " + Oferta.Id +
        //                " AND id = " + osp.Id;
        //        }
        //        else
        //        {
        //            textSQL = "UPDATE tbrepuestos " +
        //                "SET " +
        //                "qty = '" + osp.Qty.ToString("0.00", CultureInfo.CreateSpecificCulture("en-US")) + "', " +
        //                "descripcion = '" + osp.Descripcion + "', " +
        //                "nparte = '" + osp.NParte + "', " +
        //                "nsp = '" + osp.NSP + "', " +
        //                "drw = '" + osp.Drw + "', " +
        //                "drwitem = '" + osp.DrwItem + "', " +
        //                "hscode = '" + osp.HSCode + "', " +
        //                "spcurr = '" + osp.CurrId + "', " +
        //                "plazoentrega = '" + osp.PlazoEntrega + "', " +
        //                "costounit = '" + osp.CostoUnit.ToString("0.00", CultureInfo.CreateSpecificCulture("en-US")) + "', " +
        //                "ventaunit = '" + osp.VentaUnit.ToString("0.00", CultureInfo.CreateSpecificCulture("en-US")) + "', " +
        //                "gm = '" + (osp.GMUnit * 100).ToString("0.00", CultureInfo.CreateSpecificCulture("en-US")) + "', " +
        //                "comentarios = '" + osp.Comentarios + "', " +
        //                "part = '" + osp.PartUnit.ToString("0.00", CultureInfo.CreateSpecificCulture("en-US")) + "', " +
        //                "refcliente = '" + osp.RefCliente + "' " +
        //                "WHERE idosp = '" + Oferta.Id +
        //                "' AND id = " + osp.Id;

        //        }
        //        res += RepositorioBase.EjecutarSQLComando(textSQL);
        //    }

        //    return res;
        //}

        //public static int eliminarRepuesto(Repuesto item)
        //{
        //    int res = 0;

        //    if (item.Tipo == "SV")
        //    {
        //        string textSQL = "DELETE FROM tbservicios WHERE id = '" + Convert.ToInt32(item.Id) + "'";
        //        res += RepositorioBase.EjecutarSQLComando(textSQL);
        //    }
        //    else
        //    {
        //        string textSQL = "DELETE FROM tbrepuestos WHERE id = '" + Convert.ToInt32(item.Id) + "'";
        //        res += RepositorioBase.EjecutarSQLComando(textSQL);
        //    }

        //    return res;
        //}

        #endregion
    }
}
