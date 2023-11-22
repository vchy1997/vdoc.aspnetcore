### 创建非聚集索引

```SQL
CREATE NONCLUSTERED INDEX [IndexName]
ON [Table]([Field])
```

### 创建唯一约束

```sql
ALTER TABLE CommodityInfo
ADD CONSTRAINT AK_HeadOfficeId_BelonglenId_SPH_CLY UNIQUE (HeadofficeID,BelonglenID,Refractive,Astigmatism);
```

``
