﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SQLPerformaceAndORMsDemo
{
    [Table("Track")]
    [Index(nameof(AlbumId), Name = "IFK_TrackAlbumId")]
    [Index(nameof(GenreId), Name = "IFK_TrackGenreId")]
    [Index(nameof(MediaTypeId), Name = "IFK_TrackMediaTypeId")]
    public partial class Track
    {
        public Track()
        {
            InvoiceLines = new ObservableCollection<InvoiceLine>();
            PlaylistTracks = new ObservableCollection<PlaylistTrack>();
        }

        [Key]
        public virtual int TrackId { get; set; }
        [Required]
        [StringLength(200)]
        public virtual string Name { get; set; }
        public virtual int? AlbumId { get; set; }
        public virtual int MediaTypeId { get; set; }
        public virtual int? GenreId { get; set; }
        [StringLength(220)]
        public virtual string Composer { get; set; }
        public virtual int Milliseconds { get; set; }
        public virtual int? Bytes { get; set; }
        [Column(TypeName = "numeric(10, 2)")]
        public virtual decimal UnitPrice { get; set; }

        [ForeignKey(nameof(AlbumId))]
        [InverseProperty("Tracks")]
        public virtual Album Album { get; set; }
        [ForeignKey(nameof(GenreId))]
        [InverseProperty("Tracks")]
        public virtual Genre Genre { get; set; }
        [ForeignKey(nameof(MediaTypeId))]
        [InverseProperty("Tracks")]
        public virtual MediaType MediaType { get; set; }
        [InverseProperty(nameof(InvoiceLine.Track))]
        public virtual ICollection<InvoiceLine> InvoiceLines { get; set; }
        [InverseProperty(nameof(PlaylistTrack.Track))]
        public virtual ICollection<PlaylistTrack> PlaylistTracks { get; set; }
    }
}