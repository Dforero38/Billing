use Billing
select Description,Price from Product
go

use Billing
select Product.Description  as NombreProducto, Residue.Stok as SaldoActual,Product.Price as PrecioProducto  
from dbo.Residue,dbo.Product
where Residue.IdProduct=Product.Id and Residue.Stok<6
go

use Billing
select * from dbo.MovementBill, dbo.Customer 
where (year(Customer.RegistrationDate)>(2022-35) and DATEDIFF(day,MovementBill.Date,'2000/01/02')<0 and DATEDIFF(day,MovementBill.Date,'2000/05/25')>0 and MovementBill.IdCustomer=Customer.Id)
go

use Billing
select MovementProduct.IdProduct as IdProducto, sum(TotalValue) as TotalVentas 
from dbo.MovementProduct, dbo.Product 
where MovementProduct.IdProduct=Product.Id and year(MovementProduct.Date)=2000  
group by MovementProduct.IdProduct order by MovementProduct.IdProduct
go



use Billing
SELECT	cus.Id as Cliente1,
		cus.BusinessName,	
		dateadd(day,datediff ( day , min(Date) , max(Date) ) /((COUNT(*))*1440),Date) as fechaEStimada 
from	MovementBill		AS mbl
INNER	JOIN dbo.Customer	AS cus ON mbl.IdCustomer = cus.Id
group by cus.Id, Date, cus.BusinessName
go