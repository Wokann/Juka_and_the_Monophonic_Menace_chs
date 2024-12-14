/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2018-8-31
 * 时间: 14:39
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Timers;
using System.Drawing.Text;

namespace Final_JuKa_
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			#region 文件操作
			
			string autopath = Directory.GetCurrentDirectory();

            //string ini_path = autopath + "\\" + "Data" + "\\" + "Final(JuKa).ini";
            string ini_path = autopath + "\\..\\..\\"+ "data" + "\\" + "Final(JuKa).ini";

            if (!(File.Exists(@ini_path))){
				MessageBox.Show("Final(JuKa).ini配置文件不存在","告警！", MessageBoxButtons.OK,MessageBoxIcon.Warning);
				System.Environment.Exit(0);
			}
			
			FileStream ini = new FileStream(@ini_path,FileMode.Open,FileAccess.Read);
			StreamReader set_ini = new StreamReader(ini);
			
			string rom_name = set_ini.ReadLine();
			rom_name = set_ini.ReadLine();
            //string rom_name1 = autopath + "\\" + "Data" + "\\" + rom_name;
            //string rom_name2 = autopath + "\\" + rom_name;
            string rom_name1 = autopath + "\\..\\..\\rom\\" + rom_name;
            string rom_name2 = autopath + "\\..\\..\\" + rom_name;

            string txt_name1 = set_ini.ReadLine();
			txt_name1 = set_ini.ReadLine();
            //txt_name1 = autopath + "\\" + txt_name1;
            txt_name1 = autopath + "\\..\\..\\" + "strings" + "\\" + txt_name1;

            string txt_name2 = set_ini.ReadLine();
            //txt_name2 = autopath + "\\" + txt_name2;
            txt_name2 = autopath + "\\..\\..\\" + "strings" + "\\" + txt_name2;

            string tbl_name1 = set_ini.ReadLine();
			tbl_name1 = set_ini.ReadLine();
            //tbl_name1 = autopath + "\\" + "Data" + "\\" + tbl_name1;
            tbl_name1 = autopath + "\\..\\..\\" + "data" + "\\" + tbl_name1;

            string tbl_name2 = set_ini.ReadLine();
            //tbl_name2 = autopath + "\\" + "Data" + "\\" + tbl_name2;
            tbl_name2 = autopath + "\\..\\..\\" + "data" + "\\" + tbl_name2;

            string fy_name = set_ini.ReadLine();
			fy_name = set_ini.ReadLine();
            //fy_name = autopath + "\\" + fy_name;
            fy_name = autopath + "\\..\\..\\" + fy_name;

            string jd_name = set_ini.ReadLine();
			jd_name = set_ini.ReadLine();
            //jd_name = autopath + "\\" + jd_name;
            jd_name = autopath + "\\..\\..\\" + jd_name;
            /*MessageBox.Show($"读取到的 ini_path: {ini_path}\n" +
				$"读取到的 rom_name1: {rom_name1}\n" +
				$"读取到的 rom_name2: {rom_name2}\n" +
				$"读取到的 txt_name1: {txt_name1}\n" +
				$"读取到的 txt_name2: {txt_name2}\n" +
				$"读取到的 tbl_name1: {tbl_name1}\n" +
				$"读取到的 tbl_name2: {tbl_name2}\n" +
				$"读取到的 fy_name: {fy_name}\n" +
				$"读取到的 jd_name: {jd_name}\n", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);*/
            set_ini.Close();
			ini.Close();
			
			if (!(File.Exists(@rom_name1)))
			{
				MessageBox.Show("ROM文件不存在，请检查ini文件配置并确认rom文件是否存在！","告警！", MessageBoxButtons.OK,MessageBoxIcon.Warning);
				System.Environment.Exit(0);
			}
			
			if (!(File.Exists(@txt_name1)))
			{
				MessageBox.Show("导入文本不存在，请检查ini文件配置并确认导入文本是否存在！","告警！", MessageBoxButtons.OK,MessageBoxIcon.Warning);
				System.Environment.Exit(0);
			}
			
			if (!(File.Exists(@txt_name2)))
			{
				MessageBox.Show("导入文本不存在，请检查ini文件配置并确认导入文本是否存在！","告警！", MessageBoxButtons.OK,MessageBoxIcon.Warning);
				System.Environment.Exit(0);
			}
			
			if (!(File.Exists(@tbl_name1)))
			{
				MessageBox.Show("原码表文本不存在，请检查ini文件配置并确认tbl文本是否存在！","告警！", MessageBoxButtons.OK,MessageBoxIcon.Warning);
				System.Environment.Exit(0);
			}
			
			FileStream OG_Rom = new FileStream(@rom_name1,FileMode.Open,FileAccess.ReadWrite);
			BinaryWriter OG_Rom_Writedata = new BinaryWriter(OG_Rom);
			
			File.Copy(@rom_name1,@rom_name2,true);
			
			OG_Rom_Writedata.Close();
			OG_Rom.Close();
			
			FileStream Rom = new FileStream(@rom_name2,FileMode.Open,FileAccess.Write);
			BinaryWriter Rom_Writedata = new BinaryWriter(Rom);
			
			FileStream txt_File = new FileStream(@txt_name1,FileMode.Open,FileAccess.Read);
			StreamReader txtStream = new StreamReader(txt_File);
			
			FileStream txt_File1 = new FileStream(@txt_name2,FileMode.Open,FileAccess.Read);
			StreamReader txtStream1 = new StreamReader(txt_File1);
			
			FileStream tbl_File = new FileStream(@tbl_name2,FileMode.Create,FileAccess.Write);
			StreamWriter tblStream = new StreamWriter(tbl_File);
			
			FileStream tbl_File1 = new FileStream(@tbl_name1,FileMode.Open,FileAccess.Read);
			StreamReader tblStream1 = new StreamReader(tbl_File1);
			
			FileStream fy_File = new FileStream(@fy_name,FileMode.Create,FileAccess.Write);
			StreamWriter fyStream = new StreamWriter(fy_File);
			
			FileStream jd_File = new FileStream(@jd_name,FileMode.Append,FileAccess.Write);
			StreamWriter jdStream = new StreamWriter(jd_File);
			
			#endregion
			
			#region 初始化码表＋读取原文码表
			
			//注：码表需要保存成UTF-8格式，否则读取到的码表是乱码
			
			//由于JuKa字库不大，所以懒得用链表，直接写个0x85的循环读取，这个是我偷懒……
			
			//大写字库的码表和使用次数
			string[] tbl1 = new string[6000];
			int[] shu1 =new int[6000];
			
			//小写字库的码表和使用次数
			string[] tbl2 = new string[6000];
			int[] shu2 =new int[6000];
			
			//原字库的码表，原ROM的大、小字库及其他字库都是用这个码表
			string[] tbl3 = new string[150];
			
			for (int i = 0; i < 0x85; i++) {
				
				string linestring = tblStream1.ReadLine();
				tbl3[i] = linestring.Substring(3,1);
			}
			#endregion
			
			#region 读取译文，生成新码表
			
			//生成16×16大字库文本码表
			string Xb = "—————译文—————";
			string CD = "—————结束—————";
			
			string Wb1 = txtStream.ReadLine();
			if (Wb1.StartsWith("\uFEFF"))	//utf8 with bom 检查
			{
				Wb1 = Wb1.Substring(1); // 去掉 BOM
			}
			
			while (Wb1!=null){
				
				if (Wb1.Length == Xb.Length){

					if (string.Compare(Xb,Wb1) == 0){

						Wb1 = txtStream.ReadLine();

						if (Wb1.Length > 0){
							
							while (string.Compare(CD,Wb1) != 0) {
								
								char[] Ls = Wb1.ToCharArray();
								
								for (int k = 0; k < Ls.Length; k++){
									
									string rt = Ls[k].ToString();
									
									if (string.Compare("[",rt) == 0){
										
										k++;
										
										string gt = Ls[k].ToString();
										
										string gt2 = gt;
										
										while (string.Compare("]",gt) != 0){
											
											k++;
											
											gt = Ls[k].ToString();
											
											gt2 = gt2 + gt;
											
										}
										
									}
									else{
										
										int n1 = 0;
										
										while (string.Compare(tbl3[n1],rt) != 0) {
											
											if (n1 == 0x85) {
												break;
											}
											
											n1++;
										}
										
										if (n1 == 0x85) {
											
											n1 = 0;
											
											while (string.Compare(tbl1[n1],rt) != 0){
												
												if (tbl1[n1]==null){
													
													tbl1[n1] = rt;
													
													break;
												}
												
												n1++;
												
											}
											
										}
										
									}
									
								}
								
								for (int k2 = 0; k2 < Ls.Length; k2++) {
									
									string rt = Ls[k2].ToString();
									
									if (string.Compare("[",rt) == 0){
										
										k2++;
										
										string gt = Ls[k2].ToString();
										
										string gt2 = gt;
										
										while (string.Compare("]",gt) != 0){
											
											k2++;
											
											gt = Ls[k2].ToString();
											
											gt2 = gt2 + gt;
											
										}
										
									}
									else{
										
										int n1 = 0;
										
										while (string.Compare(tbl3[n1],rt) != 0) {
											
											if (n1 == 0x85) {
												break;
											}
											
											n1++;
										}
										if (n1 == 0x85) {
											
											n1 = 0;
											
											while (string.Compare(tbl1[n1],rt)!=0) {
												
												n1++;
												
											}
											
											shu1[n1] = shu1[n1] + 1;
										}
									}
								}
								
								Wb1 = txtStream.ReadLine();
								
							}
							
						}

					}
				}
				
				Wb1 = txtStream.ReadLine();
				
			}
			
			
			//生成13×13小字库文本码表
			Xb = "－－－－译文－－－－";
			CD = "－－－－结束－－－－";
			
			Wb1 = txtStream1.ReadLine();
			if (Wb1.StartsWith("\uFEFF"))	//utf8 with bom 检查
			{
				Wb1 = Wb1.Substring(1); // 去掉 BOM
			}
			
			while (Wb1!=null){
				
				if (Wb1.Length == Xb.Length){

					if (string.Compare(Xb,Wb1) == 0){

						Wb1 = txtStream1.ReadLine();

						if (Wb1.Length > 0){
							
							while (string.Compare(CD,Wb1) != 0) {
								
								char[] Ls = Wb1.ToCharArray();
								
								for (int k = 0; k < Ls.Length; k++){
									
									string rt = Ls[k].ToString();
									
									if (string.Compare("[",rt) == 0){
										
										k++;
										
										string gt = Ls[k].ToString();
										
										string gt2 = gt;
										
										while (string.Compare("]",gt) != 0){
											
											k++;
											
											gt = Ls[k].ToString();
											
											gt2 = gt2 + gt;
											
										}
										
									}
									else{
										
										int n1 = 0;
										
										while (string.Compare(tbl3[n1],rt) != 0) {
											
											if (n1 == 0x85) {
												break;
											}
											
											n1++;
										}
										
										if (n1 == 0x85) {
											
											n1 = 0;
											
											while (string.Compare(tbl2[n1],rt) != 0){
												
												if (tbl2[n1]==null){
													
													tbl2[n1] = rt;
													
													break;
												}
												
												n1++;
												
											}
											
										}
										
									}
									
								}
								
								for (int k2 = 0; k2 < Ls.Length; k2++) {
									
									string rt = Ls[k2].ToString();
									
									if (string.Compare("[",rt) == 0){
										
										k2++;
										
										string gt = Ls[k2].ToString();
										
										string gt2 = gt;
										
										while (string.Compare("]",gt) != 0){
											
											k2++;
											
											gt = Ls[k2].ToString();
											
											gt2 = gt2 + gt;
											
										}
										
									}
									else{
										
										int n1 = 0;
										
										while (string.Compare(tbl3[n1],rt) != 0) {
											
											if (n1 == 0x85) {
												break;
											}
											
											n1++;
										}
										if (n1 == 0x85) {
											
											n1 = 0;
											
											while (string.Compare(tbl2[n1],rt)!=0) {
												
												n1++;
												
											}
											
											shu2[n1] = shu2[n1] + 1;
										}
									}
								}
								
								Wb1 = txtStream1.ReadLine();
								
							}
							
						}

					}
				}
				
				Wb1 = txtStream1.ReadLine();
				
			}
			#endregion
			
			#region　码表按照使用频率重新排序
			
			for (int i = 0; i < shu1.Length; i++){
				
				int k = i;
				
				for (int j = i + 1; j < shu1.Length; j++){
					
					if (shu1[j] > shu1[k]){
						
						k = j;
						
					}
				}
				
				if (i != k){
					
					int temp = shu1[i];
					shu1[i] = shu1[k];
					shu1[k] = temp;
					
					string stmp = tbl1[i];
					tbl1[i] = tbl1[k];
					tbl1[k] = stmp;
					
				}
				
			}
			
			for (int i = 0; i < shu2.Length; i++){
				
				int k = i;
				
				for (int j = i + 1; j < shu2.Length; j++){
					
					if (shu2[j] > shu2[k]){
						
						k = j;
						
					}
				}
				
				if (i != k){
					
					int temp = shu2[i];
					shu2[i] = shu2[k];
					shu2[k] = temp;
					
					string stmp = tbl2[i];
					tbl2[i] = tbl2[k];
					tbl2[k] = stmp;
					
				}
				
			}
			
			#endregion
			
			#region 按CT2格式写出新码表
			
			for (int p = 0; p < tbl2.Length; p++)
			{
				if (shu2[p]!=0)
				{
					tblStream.WriteLine("{0:X4}={1}", p + 0x6C00, tbl2[p]);
				}
			}
			
			for (int p = 0; p < tbl1.Length; p++)
			{
				if (shu1[p]!=0)
				{
					tblStream.WriteLine("{0:X4}={1}", p + 0x7000, tbl1[p]);
				}
			}
			
			#endregion
			
			#region　写入字库
			
			int Addr_Zk = 0xF7CC10 + 0x087300;
			
			int Addr_Pk = 0x10B5624 + 0x087300;
			
			int Addr_Zkxr = 0;
			
			Bitmap FontBitBmp = new Bitmap(300, 300);
			
			pictureBox1.Image = FontBitBmp;
			
			Graphics showfontbitmap = Graphics.FromImage(FontBitBmp);
			
			showfontbitmap.Clear(Color.Black);
			
			PrivateFontCollection newfont = new PrivateFontCollection();
			
			//newfont.AddFontFile(autopath + @"\Data\SIMSUN-XP.TTC");//加载路径的字体
			newfont.AddFontFile(autopath + @"\..\..\data\SIMSUN-XP.TTC");//加载路径的字体
			
			Font st = new Font(newfont.Families[2], 10);//0=宋体 2=新宋体
			
//			tblStream.WriteLine(newfont.Families[1].ToString ());
			
//			Font st = new Font("新宋体", 9);
			
			
			
			for (int i2 = 0; i2 < tbl1.Length; i2++){
				
				if (shu1[i2] != 0){
					
					Addr_Zkxr = Addr_Zk + (i2*0x100);
					
					string Lx = tbl1[i2];
					
					showfontbitmap.DrawString(Lx, st, Brushes.Green, 0, 0);//↑
					showfontbitmap.DrawString(Lx, st, Brushes.Green, -1, 1);//←
					showfontbitmap.DrawString(Lx, st, Brushes.Green, 0, 2);//↓
					showfontbitmap.DrawString(Lx, st, Brushes.Green, 1, 1);//→
//					showfontbitmap.DrawString(Lx, st, Brushes.Green, -1, 0);//↖
//					showfontbitmap.DrawString(Lx, st, Brushes.Green, -1, 2);//↙
//					showfontbitmap.DrawString(Lx, st, Brushes.Green, 1, 0);//↗
//					showfontbitmap.DrawString(Lx, st, Brushes.Green, 1, 2);//↘
					
					showfontbitmap.DrawString(Lx, st, Brushes.White, 0, 1);
					
					//showfontbitmap.DrawImage(FontBitBmp ,new RectangleF(0,0,244,300));

					long[,] intLt = new long[16, 16];
					
					int ma = 0;
					
					int[] shuLt = new int[256];
					
					for (int i = 0; i < 16; i++){
						
						for (int j = 0; j < 16; j++){
							
							Color Lt = FontBitBmp.GetPixel(j, i);
							
							intLt[j, i] = Lt.ToArgb();
							
							switch (intLt[j, i]) {
									
								case -16744448:
									
									shuLt[ma] = 0xC;
									
									ma = ma + 1;
									
									break;
									
								case -1:
									
									shuLt[ma] = 4;
									
									ma = ma + 1;
									
									break;
									
								case -16777216:
									
									shuLt[ma] = 0;
									
									ma = ma + 1;
									
									break;
									
								default:
									
									break;
							}
							
						}
						
					}
					
					Rom.Seek(Addr_Zkxr, SeekOrigin.Begin);
					
					for (int z = 0; z < 0x100; z++) {
						
						Rom_Writedata.Write((byte)shuLt[z]);
					}
					
					//写出这个字的偏移量地址
					
					Addr_Zkxr = Addr_Pk + (i2*0x4);
					
					Rom.Seek(Addr_Zkxr, SeekOrigin.Begin);
					
					Rom_Writedata.Write((ushort)i2);
					
					Rom_Writedata.Write((ushort)0x0110);
					
				}
				
				showfontbitmap.Clear(Color.Black);
				
			}
			
			//写入小字库
			Addr_Zk = 0x10BA7A8 + 0x087300;
			
			Addr_Pk = 0x10E66F8 + 0x087300;
			
			Addr_Zkxr = 0;
			
			showfontbitmap.Clear(Color.Black);
			
			st = new Font(newfont.Families[2], 9);//0=宋体 2=新宋体
			
			
			for (int i2 = 0; i2 < tbl2.Length; i2++)	{
				
				if (shu2[i2]!=0) {
					
					Addr_Zkxr = Addr_Zk + (i2*0xB0);
					
					string Lx = tbl2[i2];
					
					showfontbitmap.DrawString(Lx, st, Brushes.Green, -1, 0);
					showfontbitmap.DrawString(Lx, st, Brushes.Green, -1, 1);
					showfontbitmap.DrawString(Lx, st, Brushes.Green, -2, 1);
					
					showfontbitmap.DrawString(Lx, st, Brushes.White, -2, 0);

					long[,] intLt = new long[16, 16];
					
					int ma = 0;
					
					int[] shuLt = new int[256];
					
					for (int i = 0; i < 16; i++){
						
						for (int j = 0; j < 16; j++){
							
							Color Lt = FontBitBmp.GetPixel(j, i);
							
							intLt[j, i] = Lt.ToArgb();
							
							switch (intLt[j, i]) {
									
								case -16744448:
									
									shuLt[ma] = 0xC;
									
									ma = ma + 1;
									
									break;
									
								case -1:
									
									shuLt[ma] = 4;
									
									ma = ma + 1;
									
									break;
									
								case -16777216:
									
									shuLt[ma] = 0;
									
									ma = ma + 1;
									
									break;
									
								default:
									
									break;
							}
							
						}
						
					}
					
					Rom.Seek(Addr_Zkxr, SeekOrigin.Begin);
					
					int ap = 0;
					
					ma = 0;
					
					for (int z = 0; z < 169; z++) {
						
						Rom_Writedata.Write((byte)shuLt[ma]);
						
						ap = ap + 1;
						
						if (ap == 13) {
							
							ma = ma + 3;
							
							ap = 0;
						}
						
						ma = ma + 1;
					}
					
					//写出这个字的偏移量地址
					
					Addr_Zkxr = Addr_Pk + (i2*0x4);
					
					Rom.Seek(Addr_Zkxr, SeekOrigin.Begin);
					
					Rom_Writedata.Write((ushort)i2);
					
					Rom_Writedata.Write((ushort)0x010D);
					
				}
				
				showfontbitmap.Clear(Color.Black);
			}
			
			#endregion
			
			#region 写入文本数据
			
			Xb = "指针地址：";
			CD = "—————译文—————";
			
			string Wb2 = "";
			
			uint dizhi = 0;
			uint wbdizhi = 0;
			uint ckdizhi = 0x10E76E8 + 0x872A8;
			uint xdizhi = 0;
			
			int changdu = 0;
			
			int m = 0;
			
			int hm = 0;
			
			int hs = 0;
			
			int hpd = 0;
			
			float  zhs = 0;
			float fyhs = 0;
			
			string warntxt = "";
			
			txt_File.Seek(0,SeekOrigin.Begin);
			
			Wb1 = txtStream.ReadLine();
			if (Wb1.StartsWith("\uFEFF"))	//utf8 with bom 检查
			{
				Wb1 = Wb1.Substring(1); // 去掉 BOM
			}
			
			while ( Wb1 != null) {
				
				if (Wb1.Length > 12) {
					
					Wb2 = Wb1.Substring(0,5);
					
					if (string.Compare(Xb,Wb2) == 0) {
						
						zhs = zhs + 1;
						
						string Wb21 = Wb1.Substring(7,6);
						dizhi = Convert.ToUInt32(Wb21,16);//取得指针地址
						
						Wb1 = txtStream.ReadLine();
						Wb21 = Wb1.Substring(7,6);
						wbdizhi = Convert.ToUInt32(Wb21,16);//取得写入文本数据的起始地址
						
						Wb1 = txtStream.ReadLine();
						while (string.Compare(CD,Wb1) != 0)	{
							
							Wb1 = txtStream.ReadLine();
						}
						
						Wb1 = txtStream.ReadLine();
						
						ushort[] XR_Val = new ushort[2000];
						
						uint XR_n = 0;
						
						hs = 0;
						
						while (string.Compare("—————结束—————",Wb1) != 0)	{
							
							changdu = 0;
							
							if (hs > 0) {
								
								if (XR_n == 0) {
									
									XR_Val[XR_n] = 0xFE;//换行符
									
									XR_n++;
									
//									changdu = changdu + 1;
									
								} else {
									
									
									
									XR_n = XR_n - 1;
									
									if (XR_Val[XR_n] == 0x00FC) {

										XR_n = XR_n + 1;
										
										hpd = 0;
									}
									else {
										
										XR_n = XR_n - 1;
										
										if (hpd > 2 && hs > 2) {
											
											XR_n = XR_n + 2;
											
											XR_Val[XR_n] = 0x00FC;//换页符
											
											XR_n++;
											
											hpd = 0;
											
										}
										else {
											
											XR_n = XR_n + 2;

											XR_Val[XR_n] = 0x00FE;//换行符

											XR_n++;
										}
										
									}
									
//									changdu = changdu + 1;
									
								}
								
							}

							if (Wb1.Length > 0) {
								
								char[] Ls = Wb1.ToCharArray();
								
								int n = 0;
								
								for (int k = 0; k < Ls.Length; k++) {
									
									string rt = Ls[k].ToString();
									
									if (string.Compare("[",rt)==0) {
										
										k++;
										
										string gt = Ls[k].ToString();
										
										string kzf = "";
										
										ushort kzf_val = 0;
										
										while (string.Compare("]",gt)!=0) {

											kzf = kzf + gt;
											
											k++;
											
											gt = Ls[k].ToString();
											
										}
										
										kzf_val = Convert.ToByte(kzf,16);
										
										XR_Val[XR_n] = kzf_val;
										
										XR_n++;
										
										//k++;
										
									}
									else {

										m = 0;
										
										while (string.Compare(tbl3[m],rt) != 0) {
											
											if (m == 0x85) {
												break;
											}
											
											m++;
										}
										
										if (m == 0x85) {
											
											m = 0;
											
											while (string.Compare(tbl1[m],rt) != 0) {
												
												m++;
											}
											
											m = m + 0x7000;
											
											hm = m & 0xFF00;
											
											hm = hm >> 8;
											
											XR_Val[XR_n] = (ushort)hm;
											
											XR_n++;
											
											XR_Val[XR_n] = (ushort)(m & 0xFF);
											
											XR_n++;
											
											n = n + 2;
											
											changdu = changdu + 1;
										}
										else {
											
											XR_Val[XR_n] = (ushort)m;
											
											XR_n++;
											
											changdu = changdu + 1;
										}
										
									}
									
								}
								
//								XR_n = XR_n - 1;
								
//								if (XR_Val[XR_n] == 0xFC) {
//									
//									XR_n++;
//								}
//								else {
//									
//									XR_n++;
//									
//									XR_Val[XR_n] = 0xFE;//换行符
//									
//									XR_n++;
//								}
								
								if (changdu > CD.Length) {
									jdStream.WriteLine("指针地址：" + dizhi.ToString("X8"));
									jdStream.WriteLine("第" + (hs+1).ToString() + "行长度为" + changdu.ToString("D2") + "超过每行长度" + CD.Length.ToString ("D2") + "的限制！");
									jdStream.WriteLine("出错文本：" + Wb1);
									jdStream.WriteLine("导入时间：" + DateTime.Now.ToString());
									jdStream.WriteLine("");
//									MessageBox.Show("指针地址：" + dizhi.ToString("X8") + "\n" + "第" + (hs+1).ToString() + "行长度为" + changdu.ToString("D2") + "超过每行长度" + CD.Length.ToString ("D2") + "的限制！","文本错误！", MessageBoxButtons.OK,MessageBoxIcon.Warning);
									
									warntxt = warntxt + "指针地址：" + dizhi.ToString("X8") + "\n" + "第" + (hs+1).ToString() + "行长度为" + changdu.ToString("D2") + "超过每行长度" + CD.Length.ToString ("D2") + "的限制！" + "\n";
									
//									#region 关闭文件
//									
//									Rom_Writedata.Close();
//									Rom.Close();
//									
//									txtStream.Close();
//									txt_File.Close();
//									
//									txtStream1.Close();
//									txt_File1.Close();
//									
//									tblStream.Close();
//									tbl_File.Close();
//									
//									tblStream1.Close();
//									tbl_File1.Close();
//									
//									fyStream.Close();
//									fy_File.Close();
//									
//									jdStream.Close();
//									jd_File.Close();
//									
//									#endregion
//									System.Environment.Exit(0);
								}
								
								
							}
							
							Wb1 = txtStream.ReadLine();
							
							hs = hs + 1;
							
							hpd = hpd + 1;
						}

						
						
						if (XR_n > 0) {
							
//							XR_n = XR_n - 1;
							
							XR_Val[XR_n] = 0xFF;//结束符
							
							XR_n = XR_n + 1;
							
							fyhs = fyhs + 1;
							
							//说明一下：0x1135000，这个地址是新文本的写入地址，因为大、小字库的显示程序魔改后，译文的的编码变成为单、双混合字节，这样的话，译文的长度会超过原文的长度，只能把译文写到其他地方，然后修改对应的文本指针，把译文关联过去
							
							//第一段文本写到这里0x1135000，然后后面的文本接着上一句的末尾继续写
							
							if (ckdizhi == (0x10E76E8 + 0x872A8))	{
								
								Rom.Seek(ckdizhi, SeekOrigin.Begin);
								
								for (int w = 0; w < XR_n; w++) {
									
									Rom_Writedata.Write((byte)XR_Val[w]);
								}

								xdizhi = ckdizhi + XR_n;
								
								Rom.Seek(dizhi, SeekOrigin.Begin);
								
								Rom_Writedata.Write((int)(ckdizhi + 0x08000000));
								
								ckdizhi = 0;
								
							}
							else {
								
								Rom.Seek(dizhi, SeekOrigin.Begin);
								
								Rom_Writedata.Write((int)(xdizhi + 0x08000000));
								
								Rom.Seek(xdizhi, SeekOrigin.Begin);
								
								for (int w = 0; w < XR_n; w++) {
									
									Rom_Writedata.Write((byte)XR_Val[w]);
								}

								xdizhi = xdizhi + XR_n;
								
								
							}

						}

					}

				}

				Wb1 = txtStream.ReadLine();
			}
			
			
			//写入小字库文本
			Xb = "指针地址：";
			CD = "－－－－译文－－－－";
			
			
			m = 0;
			
			hm = 0;
			
			txt_File1.Seek(0,SeekOrigin.Begin);
			
			Wb1 = txtStream1.ReadLine();
			if (Wb1.StartsWith("\uFEFF"))	//utf8 with bom 检查
			{
				Wb1 = Wb1.Substring(1); // 去掉 BOM
			}
			
			while ( Wb1 != null) {
				
				if (Wb1.Length > 12) {
					
					Wb2 = Wb1.Substring(0,5);
					
					if (string.Compare(Xb,Wb2) == 0) {
						
						zhs = zhs + 1;
						
						string Wb21 = Wb1.Substring(7,6);
						dizhi = Convert.ToUInt32(Wb21,16);//取得指针地址
						
						Wb1 = txtStream1.ReadLine();
						Wb21 = Wb1.Substring(7,6);
						wbdizhi = Convert.ToUInt32(Wb21,16);//取得写入文本数据的起始地址
						
						Wb1 = txtStream1.ReadLine();
						while (string.Compare(CD,Wb1) != 0)	{
							
							Wb1 = txtStream1.ReadLine();
						}
						
						Wb1 = txtStream1.ReadLine();
						
						ushort[] XR_Val = new ushort[2000];
						
						uint XR_n = 0;
						
						while (string.Compare("－－－－结束－－－－",Wb1) != 0)	{

							if (Wb1.Length > 0) {
								
								char[] Ls = Wb1.ToCharArray();
								
								int n = 0;
								
								for (int k = 0; k < Ls.Length; k++) {
									
									string rt = Ls[k].ToString();
									
									if (string.Compare("[",rt)==0) {
										
										k++;
										
										string gt = Ls[k].ToString();
										
										string kzf = "";
										
										ushort kzf_val = 0;
										
										while (string.Compare("]",gt)!=0) {

											kzf = kzf + gt;
											
											k++;
											
											gt = Ls[k].ToString();
											
										}
										
										kzf_val = Convert.ToByte(kzf,16);
										
										XR_Val[XR_n] = kzf_val;
										
										XR_n++;
										
										//k++;
										
									}
									else {

										m = 0;
										
										while (string.Compare(tbl3[m],rt) != 0) {
											
											if (m == 0x85) {
												break;
											}
											
											m++;
										}
										
										if (m == 0x85) {
											
											m = 0;
											
											while (string.Compare(tbl2[m],rt) != 0) {
												
												m++;
											}
											
											m = m + 0x6C00;
											
											hm = m & 0xFF00;
											
											hm = hm >> 8;
											
											XR_Val[XR_n] = (ushort)hm;
											
											XR_n++;
											
											XR_Val[XR_n] = (ushort)(m & 0xFF);
											
											XR_n++;
											
											n = n + 2;
										}
										else {
											
											XR_Val[XR_n] = (ushort)m;
											
											XR_n++;
										}
										
									}
									
								}
								
								XR_n = XR_n - 1;
								
								if (XR_Val[XR_n] == 0xFC) {
									
									XR_n++;
								}
								else {
									
									XR_n++;
									
									XR_Val[XR_n] = 0xFE;//换行符
									
									XR_n++;
								}
								
								
								
								
							}
							
							Wb1 = txtStream1.ReadLine();
						}

						
						
						if (XR_n > 0) {
							
							XR_n = XR_n - 1;
							
							XR_Val[XR_n] = 0xFF;//结束符
							
							XR_n = XR_n + 1;
							
							fyhs = fyhs + 1;
							
							//说明一下：0x1135000，这个地址是新文本的写入地址，因为大、小字库的显示程序魔改后，译文的的编码变成为单、双混合字节，这样的话，译文的长度会超过原文的长度，只能把译文写到其他地方，然后修改对应的文本指针，把译文关联过去
							
							//第一段文本写到这里0x1135000，然后后面的文本接着上一句的末尾继续写
							
							if (ckdizhi == 0x10E76E8 + 0x872A8)	{
								
								Rom.Seek(ckdizhi, SeekOrigin.Begin);
								
								for (int w = 0; w < XR_n; w++) {
									
									Rom_Writedata.Write((byte)XR_Val[w]);
								}

								xdizhi = ckdizhi + XR_n;
								
								Rom.Seek(dizhi, SeekOrigin.Begin);
								
								Rom_Writedata.Write((int)(ckdizhi + 0x08000000));
								
								ckdizhi = 0;
								
							}
							else {
								
								Rom.Seek(dizhi, SeekOrigin.Begin);
								
								Rom_Writedata.Write((int)(xdizhi + 0x08000000));
								
								Rom.Seek(xdizhi, SeekOrigin.Begin);
								
								for (int w = 0; w < XR_n; w++) {
									
									Rom_Writedata.Write((byte)XR_Val[w]);
								}

								xdizhi = xdizhi + XR_n;
								
								
							}

						}

					}

				}

				Wb1 = txtStream1.ReadLine();
			}
			#endregion
			
			#region 导出翻译备忘录
			
			txt_File.Seek(0,SeekOrigin.Begin);
			
			Xb = "指针地址：";
			
			CD = "—————结束—————";
			
			string xhstr = "";
			string dzstr = "";
			
			Wb1 = txtStream.ReadLine();
			
			while ( Wb1 != null) {
				
				if (Wb1.Length == 13) {
					
					Wb2 = Wb1.Substring(0,5);
					
					if (string.Compare(Xb,Wb2) == 0) {
						
						xhstr = Wb1;//取得文本序号
						
						dzstr = txtStream.ReadLine();//取得文本指针地址

						Wb1 = txtStream.ReadLine();
						
						while (string.Compare(CD,Wb1) != 0)	{
							
							Wb1 = txtStream.ReadLine();
						}
						
						Wb1 = txtStream.ReadLine();
						
						if (Wb1.Length > 0) {

							fyStream.WriteLine(xhstr);
							
							fyStream.WriteLine(dzstr);

							fyStream.WriteLine("—————备注—————");
							
							while (string.Compare("—————备注—————",Wb1) != 0)	{
								
								fyStream.WriteLine(Wb1);
								
								Wb1 = txtStream.ReadLine();
							}
							
							fyStream.WriteLine("—————结束—————");
							
							fyStream.WriteLine("");
							
							fyStream.WriteLine("");
						}
					}
				}
				
				Wb1 = txtStream.ReadLine();
			}
			
			//小字库备忘
			txt_File1.Seek(0,SeekOrigin.Begin);
			
			Xb = "指针地址：";
			
			CD = "－－－－结束－－－－";
			
			xhstr = "";
			dzstr = "";
			
			Wb1 = txtStream1.ReadLine();
			
			while ( Wb1 != null) {
				
				if (Wb1.Length == 13) {
					
					Wb2 = Wb1.Substring(0,5);
					
					if (string.Compare(Xb,Wb2) == 0) {
						
						xhstr = Wb1;//取得文本序号
						
						dzstr = txtStream1.ReadLine();//取得文本指针地址

						Wb1 = txtStream1.ReadLine();
						
						while (string.Compare(CD,Wb1) != 0)	{
							
							Wb1 = txtStream1.ReadLine();
						}
						
						Wb1 = txtStream1.ReadLine();
						
						if (Wb1.Length > 0) {

							fyStream.WriteLine(xhstr);
							
							fyStream.WriteLine(dzstr);

							fyStream.WriteLine("－－－－备注－－－－");
							
							while (string.Compare("－－－－备注－－－－",Wb1) != 0)	{
								
								fyStream.WriteLine(Wb1);
								
								Wb1 = txtStream1.ReadLine();
							}
							
							fyStream.WriteLine("－－－－结束－－－－");
							
							fyStream.WriteLine("");
							
							fyStream.WriteLine("");
						}
					}
				}
				
				Wb1 = txtStream1.ReadLine();
			}
			#endregion
			
			#region 写出翻译统计数据
			
			jdStream.WriteLine("文本总量：" + zhs.ToString());
			jdStream.WriteLine("已翻译文本：" + fyhs.ToString());
			jdStream.WriteLine("完成率：" + (fyhs / zhs).ToString("0.000%"));
			jdStream.WriteLine("导入时间：" + DateTime.Now.ToString());
			jdStream.WriteLine("");
			
			#endregion
			
			#region 关闭文件
			
			Rom_Writedata.Close();
			Rom.Close();
			
			txtStream.Close();
			txt_File.Close();
			
			txtStream1.Close();
			txt_File1.Close();
			
			tblStream.Close();
			tbl_File.Close();
			
			tblStream1.Close();
			tbl_File1.Close();
			
			fyStream.Close();
			fy_File.Close();
			
			jdStream.Close();
			jd_File.Close();

            #endregion

            //MessageBox.Show("Juka and the Monophonic Menace (C)文本智能导入完成！！" + "\n" + warntxt, "魔导成功！", MessageBoxButtons.OK,MessageBoxIcon.Warning);
            System.Environment.Exit(0);
			//
		}
	}
}
