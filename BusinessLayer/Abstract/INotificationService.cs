﻿using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract {
    public interface INotificationService :IGenericService<Notification> {
        int TNotificationCountByStatusFalse();
        List<Notification> TGetAllNotificationByStatusFalse();
        void TNotificationChangeToTrue(int id); // Okundu olarak işaretle
        void TNotificationChangeToFalse(int id);
        void TDeleteAllNotificationByTrue();
    }
}
