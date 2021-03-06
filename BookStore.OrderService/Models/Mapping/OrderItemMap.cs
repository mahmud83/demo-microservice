﻿/**
 * Copyright (C) 2018 Kamarudin (http://coding4ever.net/)
 *
 * Licensed under the Apache License, Version 2.0 (the "License"); you may not
 * use this file except in compliance with the License. You may obtain a copy of
 * the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
 * WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the
 * License for the specific language governing permissions and limitations under
 * the License.
 *
 * The latest version of this file can be found at https://github.com/k4m4r82/demo-ocelot-microservice2
 */

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.OrderService.Models.Mapping
{
    public class OrderItemMap : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("order_item");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedNever();

            builder.Property(e => e.BookId).HasColumnName("book_id");

            builder.Property(e => e.OrderId).HasColumnName("order_id");

            builder.Property(e => e.Price).HasColumnName("price");

            builder.Property(e => e.Quantity).HasColumnName("quantity");

            builder.HasOne(d => d.Order)
                .WithMany(p => p.OrderItem)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("order_item_fk");            
        }
    }
}
