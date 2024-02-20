using SalesWebMvc.Models;
using SalesWebMvc.Models.Enum;

namespace SalesWebMvc.Data
{
    public class SeedingService
    {
        private SalesWebMvcContext _context;

        public SeedingService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Department.Any() ||
                _context.Sellers.Any() ||
                _context.SalesRecord.Any())
            {
                return;
            }

            Department d1 = new Department("Computadores");
            Department d2 = new Department("Books");
            Department d3 = new Department("Fashion");

            Seller s1 = new Seller("Rodrigo Viana", "rodrigoviana@gmail.com", new DateTime(1979, 11, 08), 8500, d1);
            Seller s2 = new Seller("Kevin Lima ", "kevinlima@gmail.com", new DateTime(1996, 08, 28), 6500, d2);
            Seller s3 = new Seller("Jose Laune", "jlaune@gmail.com", new DateTime(1976, 08, 13), 10789, d3);
            Seller s4 = new Seller("Gabriel Dev ", "gabrieldev@gmail.com", new DateTime(1997, 10, 28), 8500, d1);

            SalesRecord r1 = new SalesRecord( new DateTime(2024, 01, 01), 123, SalesStatus.Pending, s1);
            SalesRecord r2 = new SalesRecord(new DateTime(2024, 01, 02), 234, SalesStatus.Billed, s2);
            SalesRecord r3 = new SalesRecord( new DateTime(2024, 01, 03), 345, SalesStatus.Canceled, s3);
            SalesRecord r4 = new SalesRecord(new DateTime(2024, 01, 04), 567, SalesStatus.Pending, s1);
            SalesRecord r5 = new SalesRecord( new DateTime(2024, 01, 05), 789, SalesStatus.Billed, s4);
            /*
            SalesRecord r6 = new SalesRecord(6, new DateTime(2024, 01, 06), 890, SalesStatus.Pending, s2);
            SalesRecord r7 = new SalesRecord(7, new DateTime(2024, 01, 07), 123, SalesStatus.Canceled, s3);
            SalesRecord r8 = new SalesRecord(8, new DateTime(2024, 01, 03), 456, SalesStatus.Billed, s2);
            SalesRecord r9 = new SalesRecord(9, new DateTime(2024, 01, 09), 654, SalesStatus.Pending, s1);
            SalesRecord r10 = new SalesRecord(10, new DateTime(2024, 01, 10), 876, SalesStatus.Canceled, s4);
            SalesRecord r11 = new SalesRecord(11, new DateTime(2024, 01, 11), 321, SalesStatus.Billed, s3);
            SalesRecord r12 = new SalesRecord(12, new DateTime(2024, 01, 12), 543, SalesStatus.Pending, s2);
            SalesRecord r13 = new SalesRecord(13, new DateTime(2024, 01, 13), 765, SalesStatus.Canceled, s1);
            SalesRecord r14 = new SalesRecord(14, new DateTime(2024, 01, 14), 987, SalesStatus.Billed, s2);
            SalesRecord r15 = new SalesRecord(15, new DateTime(2024, 01, 15), 210, SalesStatus.Pending, s3);
            SalesRecord r16 = new SalesRecord(16, new DateTime(2024, 01, 16), 432, SalesStatus.Canceled, s4);
            SalesRecord r17 = new SalesRecord(17, new DateTime(2024, 01, 17), 654, SalesStatus.Billed, s1);
            SalesRecord r18 = new SalesRecord(18, new DateTime(2024, 01, 18), 876, SalesStatus.Pending, s2);
            SalesRecord r19 = new SalesRecord(19, new DateTime(2024, 01, 19), 321, SalesStatus.Canceled, s3);
            SalesRecord r20 = new SalesRecord(20, new DateTime(2024, 01, 20), 543, SalesStatus.Billed, s4);
            SalesRecord r21 = new SalesRecord(21, new DateTime(2024, 01, 21), 765, SalesStatus.Pending, s1);
            SalesRecord r22 = new SalesRecord(22, new DateTime(2024, 01, 22), 987, SalesStatus.Canceled, s2);
            SalesRecord r23 = new SalesRecord(23, new DateTime(2024, 01, 23), 210, SalesStatus.Billed, s3);
            SalesRecord r24 = new SalesRecord(24, new DateTime(2024, 01, 24), 432, SalesStatus.Pending, s4);
            SalesRecord r25 = new SalesRecord(25, new DateTime(2024, 01, 25), 654, SalesStatus.Canceled, s1);
            SalesRecord r26 = new SalesRecord(26, new DateTime(2024, 01, 26), 876, SalesStatus.Billed, s2);
            SalesRecord r27 = new SalesRecord(27, new DateTime(2024, 01, 27), 321, SalesStatus.Pending, s3);
            SalesRecord r28 = new SalesRecord(28, new DateTime(2024, 01, 28), 543, SalesStatus.Canceled, s4);
            SalesRecord r29 = new SalesRecord(29, new DateTime(2024, 01, 29), 765, SalesStatus.Billed, s1);
            SalesRecord r30 = new SalesRecord(30, new DateTime(2024, 01, 30), 987, SalesStatus.Pending, s2);
            */
            _context.Department.AddRange(d1, d2, d3);

            _context.Sellers.AddRange(s1, s2, s3, s4);

            _context.SalesRecord.AddRange(r1, r2, r3, r4, r5);
     /*
     r7, r8, r9, r10,
     r11, r12, r13, r14, r15, r16, r17, r18, r19, r20,
     r21, r22, r23, r24, r25, r26, r27, r28, r29, r30*/
 
            _context.SaveChanges();

        }
    }
}
