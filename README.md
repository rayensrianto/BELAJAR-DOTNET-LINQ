
# ARSITEKTUR LINQ

## Linq adalah?

Linq adalah Language Integrated Query.
Dengan linq, sebuah query dapat di gunakan untuk mendapatkan data dari berbagai jenis datasource,
seperti SQL Server, XML document, ADO.NET dataset, dan object di memory seperti collection, generic dsbg.

- Kenapa harus menggunakan Linq?
1. Jika aplikasi membutuhkan data dari SQL Server, maka kita harus mengerti ADO.NET dan query Sql server
agar bisa mengambil/mengolah data dari Sql Server. Jika database nya oracle, maka kita juga perlu mempelajari
query syntax Oracle. 
2. Jika aplikasi membutuhkan data dari XML Document, maka kita harus mengerti query XPath dan XSLT
3. Jika aplikasi membutuhkan data object yang ada di memory seperti List, maka kita harus mengerti cara mengolah 
data object yang di memory.

## Bagaimana Linq berkerja?

.NET(C#,VB.NET, others) --> LINQ QUERIES --> LINQ PROVIDERS --> DATA SOURCE

Linq menggunakan Linq Providers sebagai jembatan antaran Linq Query dengan datasource.
Linq Providers akan menerjemahkan dari Linq Query ke Query DataSource yang di tuju.

Linq Providers adalah sebuah software yang mengimplementasi interface IQueryProvider dan IQueryAble untuk datasource tertentu.
Jadi jika kita ingin membuat/mengcustom Linq Providers harus menggunakan interface tersebut.

Berikut contoh beberapa Linq Provider yang sudah tersedia saat ini:
1. Linq To Objects: untuk mengolah data object yang di memory seperti array, list, generic dll
2. Linq To SQL (DLINQ): untuk mengolah data dari Sql Server
3. dsbg

## Kekurangan dan Kelebihan LINQ.

Kelebihan
* kita tidak perlu mempelajarin syntax query yang berbeda-beda dari datasource yang berbeda-beda.
* code yang di tulis lebih sedikit
* support intelligence di vistud
* linq providers menyediakan method untuk filtering, ordering, grouping dsbg
* query dapat digunakan kembali/reused

Kekurangan
* linq sulit digunakan untuk menulis query yang rumit
* linq tidak support sql feautre seperti cache execution seperti store proc
* akan sangat mempengaruhi performa apps jika tidak di tulis dgn baik dan benar
* jika kita mengubah code linq, maka kita harus mengcompile apps ulang dan redeploy

# CARA MENULIS LINQ QUERY

Ada 3 cara dalam membuat atau menulis query Linq.
Secara performa, ke 3 cara ini tidak ada perbedaan nya.
Tetapi, linq query selalu di transalte dulu menjadi lambda expression sebelum di compile.

## 1. Linq Query Syntax
Ini adalah cara termudah untuk membuat linq query, karena hampir mirip dengan sql query.

format nya adalah seperti dibawah ini:
from OBJECT in DATASOURCE
where CONDITION
select OBJECT

contoh: 001_Contoh_LinqQuerySyntax.cs


## 2. Linq Method Syntax
Method Syntax menggunakan lambda expression untuk mendefiniskan condition query.
Biasanya digunakan untuk keperlua read data source.

formatnya:
DATASOURCE.CONDITIONMETHOD().SELECTIONMETHOD()

contoh: 002.cs

## 3. Linq Mixed Syntax
Ini adalah kombinasi antara Query Syntax dengan Method Syntax

format nya:
(from OBJECT in DataSource
where CONDITION 
select OBJECT).Method()
----------------------------------------------------------------------------------------------------------------------------

# IENUMERABLE dan IQUERYABLE di C#

Pada code 001_Contoh.cs, terdapat code seperti ini:

```c#
var QuerySyntax = from obj in integerList
				where obj > 5
				select obj;
```
Jika didebug, maka variable QuerySyntax bertipe "IEnumberable<int> QuerySyntax"
Jadi, code di atas bisa juga di tulis seperti ini:

		IEnumberable<int> QuerySyntax = from obj in integerList
									where obj > 5
									select obj;

1. Apa itu IEnumberable?
IEnumberable adalah sebuah interface yang terdapat pada namespace System.Collection.
Tipe dari interface ini adalah Iterator Design Pattern, artinya kita bisa membuat iterasi/pengulangan dari tipe IEnumerable.
Interface ini memiliki satu method bernama GetEnumerator, yg akan me-return IEnumerator yang meng iterasi collection
Interace IEnumarable memilki child class generic interface yaitu IEnumerable<T>

Penting untuk di ingat:
semua class collection baik generin dan non generic yg ada di c# mengimplementasi interface IEnumerable.

Note:
IEnumerable dan IEnumerable<T> seharusnya hanya digunakan untuk data memory object. nanti di bahas gengs.

Contoh: 004.Contoh.cs


2. Apa itu IQueryable?
IQueryable adalah sebuah interface yang terdapat pada namespace System.Linq
Interface ini merupakan turunan dari Interface IEnumerable, sehingga kita menyimpan IQueryable ke dalam variable IEnumerable.
Interace ini memiliki property bernama Porvider, dan property ini bertipe Interface IQueryProvider.
Dan method2 yang terdapat pada interface IQueryProvider berfungsi untuk membuat semua Linq Provider.
Jadi ini pilihan terbaik untuk data provider lain seperti Linq To SQL, Linq To Entities, dsbg

Contoh code: 005_Contoh_IQueryAble.cs


3. Perbedaan antara IEnumerable dengan IQueryable ?
IEnumerable:
- IEnumerable adalah sebuah interface yg berasal dari namespace System.Collection
- Saat melakukan query data dari database, IEnumerable meng eksekusi "select statement" di server side(database server)
lalu memuat data ke memory di client side, lalu hanya melakukan filter sesuai data yang sudah di dapat saja.
- Jadi ini di rekomendasikan untuk digunakan saat mengquery data dari memory collection seperti List, Array, dsbg
- IEnumerable paling banyak digunakan untuk Linq To Object dan Linq To XML
- IEnumerable tidak support lazy loading dan custom queries.

IQueryable:
- IQueryable adalah interface yang berasal dari namespace System.Linq
- Saat melakukan query data dari database, IQueryable meng eksekusi "select query" yang mengaplikasi filter pada server side, 
setelah itu baru di retrieve data nya.
- Jadi ini di rekomendasikan untuk digunakan saat meng query data dari luar memory seperti remote database, service dsbg
- IQueryable paling banyak digunakan untuk Linq To Sql dan Linq To Entities
- Support custom queries dengan menggunakan method CreateQuery dan Executes Method.
- Support lazy loading
----------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------

### LINQ OPERATOR

1. Apa itu Linq Operator?
Adalah kumpulan-kumpulan extension method linq yang dapat digunakan untuk membuat query linq.
Extension method linq ini terdapat banyak fitur yang bisa di apply ke datasource.
Antara lain seperti: filtering data, sorting data, grouping data, dsbg.

Di Linq, operator di bagi beberapa kategori, antara lain:

Projection Operators
Ordering Operators
Filtering Operators
Set Operators
Quantifier Operators
Grouping Operators
Partitioning Operators
Equality Operators
Element Operators
Conversion Operators
Concatenation Operators
Aggregation Operators
Generation Operators
Join Operators
Custom Sequence Operators
Miscellaneous Operators
----------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------

### PROJECTION OPERATOS (Select Data)

1. Apa itu Projection Operator?
Adalah mekanisme yang digunakan untuk melakukan select terhadap data source.
Projection method/operator ada dua:
	1. Select
	2. SelectMany


2. Select Operator

- Select All (Select *)
----------------------------------------------------------------------------------------------------------------------------
Contoh query syntax seperti di bawah ini:

			IEnumerable<Employee> querySyntax = (from emp in Employee.GetEmployees()
											     select emp);
----------------------------------------------------------------------------------------------------------------------------
Contoh di atas adalah kita hanya membuat sebuah query tetapi tidak di execute.
Untuk meng-execute query yang sudah di buat, kita perlu method tambahan yaitu ToList() atau kita loop dengan foreach loop.
Jika kita tidak menggunakan method ToList() maka tipe data hanya menjadi IEnumerable<Employee>

Contoh execute query syntax seperti di bawah ini:
----------------------------------------------------------------------------------------------------------------------------
			List<Employee> querySyntax = (from emp in Employee.GetEmployees()
											     select emp).ToList();
----------------------------------------------------------------------------------------------------------------------------
Contoh execute method syntax seperti di bawah ini:
----------------------------------------------------------------------------------------------------------------------------
			IEnumerable<Employee> methodSyntax = Employee.GetEmployee().ToList();
----------------------------------------------------------------------------------------------------------------------------

- Select Single Property

query syntax
----------------------------------------------------------------------------------------------------------------------------
			List<int> querySyntax = (from emp in Employee.GetEmployees()
								 select emp.ID).ToList();
----------------------------------------------------------------------------------------------------------------------------
pada code di atas, kita menggunakan List<int> karena kita memanggil method ToList(), sehingga langsung di execute saat itu 
juga query nya, jadi bisa di tampung di List<int> 

method syntax
----------------------------------------------------------------------------------------------------------------------------
			IEnumerable<int> methodSyntax = Employee.GetEmployees().Select(emp => emp.ID);
----------------------------------------------------------------------------------------------------------------------------
sedangkan pada contoh code di atas, kita tidak bisa menggunakan List<int>, tetapi harus menggunakan IEnumerable<int> karna
query tersebut belum di execute, kita tidak memanggil method ToList() pada method tersebut. meskipun begitu, kita bisa tetap 
meng execute query tersebut menggunakan foreach

- Select Multiple Property
query syntax
----------------------------------------------------------------------------------------------------------------------------
			IEnumerable<Employee> selectQuery = (from emps in Employee.GetEmployees()
											 select new Employee()
											 {
											 	FirstName = emps.FirstName,
											 	LastName = emps.LastName,
											 	Salary = emps.Salary
											 });
----------------------------------------------------------------------------------------------------------------------------

method syntax
----------------------------------------------------------------------------------------------------------------------------
					List<Employee> methodQuery = Employee.GetEmployees().
											 Select(emps => new Employee()
											 {
											 	FirstName = emps.FirstName,
											 	LastName = emps.LastName,
											 	Salary = emps.Salary
											 }).ToList();
----------------------------------------------------------------------------------------------------------------------------

----------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------

### PROJECTION OPERATOS (Select Many)

SelectMany method digunakan untuk menjorok setiap element dari sebuah urutuan ke IEnumerable<T> dan meratakan urutan yang di hasilkan
menjadi satu urutan saja.